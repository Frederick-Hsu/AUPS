using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;

namespace Amphenol.Project.X577
{
    partial class TestItems
    {
        private static bool OpenCom(List<string> stepParameters,
                                    out string stepResult,
                                    out string stepStatus,
                                    out string stepErrorCode,
                                    out string stepErrorDesc)
        {
            string comnum = stepParameters[0];
            int baud = Convert.ToInt32(stepParameters[1]);
            int databits = Convert.ToInt32(stepParameters[2]);

            SerialPort serial;
            try
            {
                serial = new SerialPort(comnum, baud, Parity.None, databits, StopBits.One);
                serial.Open();
            }
            catch (System.IO.IOException exception)
            {
                stepResult = "NG";
                stepStatus = "Fail";
                stepErrorCode = "COMEXCE";
                stepErrorDesc = exception.Message;
                return false;
            }

            stepResult = "OK";
            stepStatus = "Pass";
            stepErrorCode = "";
            stepErrorDesc = "";
            return true;
        }
    }
}