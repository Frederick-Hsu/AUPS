#!/usr/bin/env python
# -*- coding: utf-8 -*- 
# R&S Forum VisaDevice class extension methods and 2 new exception types
#
# Version 1.0.0
# - Initial version

import os
import time
import visa
from Engine.visa_pytron import VisaDevice

# Clears the instrument io buffers and status
def ext_clear_status(device):
    device.instrument.clear()
    device.query('*CLS;*OPC?')

VisaDevice.ext_clear_status = ext_clear_status

class InstrumentErrorException(Exception):
    def __init__(self, errors):
        # Call the base class constructor with the parameters it needs
        message = ''
        if errors is not None and len(errors) > 0:
            message = '\n'.join(errors)
        super(InstrumentErrorException, self).__init__(message)
        
class InstrumentTimeoutException(Exception):
    def __init__(self, message):
        # Call the base class constructor with the parameters it needs
        super(InstrumentTimeoutException, self).__init__(message)


# Function implemented as defined in the Instrument Error Checking chapter
def ext_check_error_queue(device):
    errors = []
    stb = int(device.query('*STB?'))
    if (stb & 4) == 0:
        return errors
    
    while True:
        response = device.query('SYST:ERR?')
        if '"no error"' in response.lower():
            break
        errors.append(response)
        if len(errors) > 50:
            # safety stop
            errors.append('Cannot clear the error queue')
            break
    if len(errors) == 0:
        return None
    else:
        return errors

VisaDevice.ext_check_error_queue = ext_check_error_queue
    
# This function waits until the instrument responds that the operation is complete
def ext_wait_for_opc(device):
    device.query('*OPC?')

VisaDevice.ext_wait_for_opc = ext_wait_for_opc

# This function calls ReadErrorQueue and raise InstrumentErrorException if any error occured
# If you want to only check for error without generating the exception, use the ext_check_error_queue() function
def ext_error_checking(device):
    errors = device.ext_check_error_queue()
    if errors is not None and len(errors) > 0:
        raise InstrumentErrorException(errors)

VisaDevice.ext_error_checking = ext_error_checking
 
# This function queries a binary data from the instrument and writes them to a file on your PC
def ext_query_bin_data_to_file(device, query, PCfilePath):
    fileData = device.instrument.query_binary_values(query, datatype='s')[0]
    newFile = open(PCfilePath, "wb")
    newFile.write(fileData)
    newFile.close()
    
VisaDevice.ext_query_bin_data_to_file = ext_query_bin_data_to_file
    
# This function sends a binary data from a PC file to the instrument
def ext_send_pc_file_data_to_instrument(device, command, PCfilePath, sendLFatEND=False):
    device.instrument.send_end = False
    
    chunkSize = 1000000 # Transfer is done by 1MB chunks
    pcFile = open(PCfilePath, "rb")
    length = os.path.getsize(PCfilePath)
    lengthString = str(length)
    lenOflength = len(lengthString)
    if lenOflength < 10:
        header = '#{0}{1}'.format(lenOflength, length)
    else:
        header = '#({0})'.format(length)
    
    command = command + header
    device.instrument.send_end = False
    device.instrument.write_raw(command)
    while length > 0:
        if length > chunkSize:
            chunk = pcFile.read(chunkSize)
            device.instrument.write_raw(chunk)
            length = length - chunkSize
        else:
            chunk = pcFile.read(length)
            length = 0
            if sendLFatEND is True:
                device.instrument.write_raw(chunk)
                device.instrument.send_end = True
                device.instrument.write_raw('\n')
            else:
                device.instrument.send_end = True
                device.instrument.write_raw(chunk)

    pcFile.close()

VisaDevice.ext_send_pc_file_data_to_instrument = ext_send_pc_file_data_to_instrument

# This function transfers a file from the PC file to the instrument
def ext_copy_pc_file_to_instrument(device, PCfilePath, InstrFilePath, sendLFatEND=False):
    command = ':MMEM:DATA \'{0}\','.format(InstrFilePath)
    device.ext_send_pc_file_data_to_instrument(command, PCfilePath, sendLFatEND)
    
VisaDevice.ext_copy_pc_file_to_instrument = ext_copy_pc_file_to_instrument

# This function writes a command with STB polling synchronization mechanism
def ext_write_with_stb_poll_sync(device, cmd, timeoutms):
    device.query('*ESR?')
    fullCmd = cmd + ';*OPC'
    device.write(fullCmd)
    exceptionMessage = 'Writing with OPCsync - Timeout occured. Command: "{}", timeout {} ms'.format(cmd, timeoutms)
    _stb_polling(device, exceptionMessage, timeoutms)
    device.query('*ESR?')

VisaDevice.ext_write_with_stb_poll_sync = ext_write_with_stb_poll_sync
    
#STB polling loop internal function
def _stb_polling(device, exceptionMessage, timeoutms):
    timeoutsecs = timeoutms / 1000
    start = time.time()
    #STB polling loop
    while True:
        stb = device.instrument.read_stb()
        if (stb & 32) > 0:
            break
        
        elapsed = time.time() - start
        if elapsed > timeoutsecs:
            raise InstrumentTimeoutException(exceptionMessage)
        else:
            # Progressive delay
            if elapsed > 0.01:
                if elapsed > 0.1:
                    if elapsed > 1:
                        if elapsed > 10:
                            time.sleep(0.5)
                        else:
                            time.sleep(0.1)
                    else:
                        time.sleep(0.01)
                else:
                    time.sleep(0.001)
                    
# This function queries instrument with STB polling synchronization mechanism
def ext_query_with_stb_poll_sync(device, query, timeoutms):
    device.query('*ESR?')
    fullCmd = query + ';*OPC'
    device.write(fullCmd)
    exceptionMessage = 'Querying with OPCsync - Timeout occured. Query: "{}", timeout {} ms'.format(query, timeoutms)
    _stb_polling(device, exceptionMessage, timeoutms)
    response = device.read()
    device.query('*ESR?')
    return response

VisaDevice.ext_query_with_stb_poll_sync = ext_query_with_stb_poll_sync

# This function sends a command with and waits for the service request event
def ext_write_with_srq_sync(device, cmd, timeoutms):
    device.query('*ESR?')
    fullCmd = cmd + ';*OPC'
    device.instrument.discard_events(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_ALL_MECH)
    device.instrument.enable_event(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_QUEUE)
    device.write(fullCmd)
    device.instrument.wait_on_event(visa.constants.VI_EVENT_SERVICE_REQ, timeoutms)
    device.instrument.disable_event(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_QUEUE)
    device.query('*ESR?')

VisaDevice.ext_write_with_srq_sync = ext_write_with_srq_sync
    
# This function sends a query, waits for the service request event and then reads the response
def ext_query_with_srq_sync(device, cmd, timeoutms):
    device.query('*ESR?')
    fullCmd = cmd + ';*OPC'
    device.instrument.discard_events(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_ALL_MECH)
    device.instrument.enable_event(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_QUEUE)
    device.write(fullCmd)
    device.instrument.wait_on_event(visa.constants.VI_EVENT_SERVICE_REQ, timeoutms)
    device.instrument.disable_event(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_QUEUE)
    response = device.read()
    device.query('*ESR?')
    return response

VisaDevice.ext_query_with_srq_sync = ext_query_with_srq_sync

# This function sends a command with the registration of the service request handler
def ext_write_with_srq_event(device, cmd, handler):
    device.query('*ESR?')
    fullCmd = cmd + ';*OPC'
    device.instrument.discard_events(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_ALL_MECH)
    try:
        device.instrument.uninstall_handler(visa.constants.VI_EVENT_SERVICE_REQ, handler)
    except visa.UnknownHandler, e:
        pass
        
    device.instrument.install_handler(visa.constants.VI_EVENT_SERVICE_REQ, handler)
    device.instrument.enable_event(visa.constants.VI_EVENT_SERVICE_REQ, visa.constants.VI_HNDLR, 0)
    device.write(fullCmd)
    
VisaDevice.ext_write_with_srq_event = ext_write_with_srq_event