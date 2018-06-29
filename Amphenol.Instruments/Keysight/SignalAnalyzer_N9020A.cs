using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    public class SignalAnalyzer_N9020A
    {
        private int resourceMrg;
        private int session;

        public SignalAnalyzer_N9020A()
        {
            resourceMrg = 0;
            session = 0;
        }

        public int Open(string visaAddress)
        {
            int viError = visa32.viOpenDefaultRM(out resourceMrg);
            if (viError != visa32.VI_SUCCESS)
            {
                return viError;
            }
            viError = visa32.viOpen(resourceMrg, visaAddress, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out session);
            if (viError != visa32.VI_SUCCESS)
                return viError;

            StringBuilder attrValue = new StringBuilder();
            viError = visa32.viGetAttribute(session, visa32.VI_ATTR_RSRC_CLASS, attrValue);
            viError = visa32.viSetAttribute(session, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_TRUE);
            viError = visa32.viSetAttribute(session, visa32.VI_ATTR_TMO_VALUE, 20000);
            return viError;
        }

        public int Close()
        {
            int viError = visa32.viClose(session);
            session = 0;
            viError = visa32.viClose(resourceMrg);
            resourceMrg = 0;
            return viError;
        }

        #region Properties
        public enum State
        {
            OFF = 0,
            ON = 1
        }
        public enum Impedance
        {
            IMPEDANCE_50Ohms = 50,
            IMPEDANCE_75Ohms = 75
        }
        public enum RFCoupling
        {
            AC = 0,
            DC = 1
        }
        #endregion

        #region SCPI Command Functions
        /* *IDN? */
        public int GetInstrumentIdentifier(out string idn)
        {
#if false
            int error;
            int count;
            string command = "*IDN?\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
            {
                idn = "";
                return error;
            }
            error = visa32.viRead(session, out response, 256);
            if (error != visa32.VI_SUCCESS)
            {
                idn = "";
                return error;
            }
            idn = response;
            return error;
#else
            int error, count;
            string command = "*IDN?\n";     /* [NOTICE]!!!!!! [TOP CRITICAL AND IMPORTANT]
                                             * every command MUST contain the "\n" at the end of line.
                                             * otherwise it won't work in the condition of socket VISA address like 
                                             * "TCPIP0::192.168.1.142::5025::SOCKET"
                                             * 
                                             * NEVER FORGET!
                                             */
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            // idn = new string(Encoding.ASCII.GetChars(response), 0, count);
            idn = Encoding.ASCII.GetString(response, 0, count);
            return error;
#endif
        }

        /* :DISP:WIND:FORM:ZOOM */
        public int SetWindowZoom()
        {
            int error;
            string command = ":DISPlay:WINDow:FORMat:ZOOM\n";
            byte[] result = new byte[128];
            int count;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            if (error != visa32.VI_SUCCESS)
                return error;
            command = "SYSTem:ERRor?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 128, out count);
            string response = new string(Encoding.ASCII.GetChars(result), 0, count);

            if (error != visa32.VI_SUCCESS)
                return error;

            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:FORM:TILE */
        public int SetWindowTiled()
        {
            int error, count;
            string command = ":DISPlay:WINDow:FORMat:TILE\n";
            byte[] result = new byte[128];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 128, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:SEL 2 */
        public int SelectActiveWindowAt(int windowNo)
        {
            int error, count;
            string command = ":DISPlay:WINDow:SELect " + windowNo + "\n";
            byte[] result = new byte[128];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            command = "SYSTem:ERRor?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 128, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            string[] array = response.Split(',');
            return Convert.ToInt32(array[0]);
        }

        /* SYSTem:ERRor? */
        public int QuerySystemError(out string errorMesg)
        {
            int error, count;
            string command = "SYSTem:ERRor?\n";
            byte[] result = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 256, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            string[] array = response.Split(',');
            errorMesg = array[1];
            return Convert.ToInt32(array[0]);
        }

        /* :DISP:WIND:SEL? */
        public int QueryWhichWindowToBeSelected(out int windowNo)
        {
            int error, count;
            string command = ":DISPlay:WINDow:SELect?\n";
            byte[] result = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 64, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            windowNo = Convert.ToInt32(response);
            return error;
        }

        /* :DISP:FSCR:STAT ON */
        public int TurnOnOffFullDisplay(State state)
        {
            int error, count;
            string command = ":DISPlay:FSCReen:STATe " + state + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = QuerySystemError(out response);
            return error;
        }

        /* *CLS */
        public int ClearStatusAndErrorQueue()
        {
            int error, count;
            string command = "*CLS\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = QuerySystemError(out response);
            return error;
        }                

        /* :CAL:ALL? */
        public int AlignEntireSystem()
        {
            int error, count;
            string command = ":CALibration:ALL\n";
            byte[] result = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = "*OPC?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, result, 64, out count);

            string response = new string(Encoding.ASCII.GetChars(result), 0, count);
            if (error == visa32.VI_SUCCESS_TERM_CHAR)
            {
                return Convert.ToInt32(response);
            }
            return error;
        }

        /* *TST? */
        public int SelfTestQuery(out int result)
        {
            int error, count;
            string command = "*TST?\n";
            byte[] resp = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, resp, 256, out count);

            string response = new string(Encoding.ASCII.GetChars(resp), 0, count);
            result = Convert.ToInt32(response);
            return error;
        }

        /* :SENSe:CORRection:IMPedance:INPut:MAGNitude 50 */
        public int SetRFInputImpedanceCorrection(Impedance imp)
        {
            int error, count;
            string command = ":SENSe:CORRection:IMPedance:INPut:MAGNitude " + imp + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENSe:CORRection:IMPedance:INPut:MAGNitude? */
        public int GetRFInputImpedanceCorrection(out Impedance imp)
        {
            int error, count;
            string command = ":SENSe:CORRection:IMPedance:MAGNitude?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            string result = Encoding.ASCII.GetString(response, 0, count-1);
            imp = (Impedance)Convert.ToInt32(Convert.ToDouble(result));
            return error;
        }

        /* :INP:COUP AC */
        public int SelectRFInputCoupling(RFCoupling coupling)
        {
            int error, count;
            string coup = (coupling == RFCoupling.AC) ? "AC" : "DC";
            string command = ":INPut:COUPling " + coup + "\n", response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INP:COUP? */
        public int QueryRFInputCoupling(out string coupling)
        {
            int error, count;
            string command = ":INPut:COUPling?\n";
            byte[] response = new byte[64];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            coupling = Encoding.ASCII.GetString(response, 0, count-1);
            return error;
        }

        /* :SENS:FEED:AREFerence OFF        // turn the calibrator off
         * :SENS:FEED:AREFerence REF50      // select the 50MHz amplitude reference as the signal input
         * :SENS:FEED:AREFerence REF4800    // select the 4.8GHz amplitude reference as the signal input
         */
        public int SelectRFCalibrator(string calibrator = "OFF" /* only 3 options "REF50", "REF4800", and "OFF" */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FEED:AREFerence " + calibrator + "\n", response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FEED:AREF? */
        public int QueryRFCalibrator(out string calibrator)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FEED:AREFerence?\n";
            byte[] response = new byte[64];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            calibrator = Encoding.ASCII.GetString(response, 0, count-1);
            return error;
        }

        /* :SENS:CORR:MS:RF:GAIN 10 */
        public int SetExternalGainForMobileStationTests(double gainValue /* range = [-100, 100]dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:MS:RF:GAIN " + gainValue + "\n", response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:MS:RF:GAIN? */
        public int QueryExternalGainForMobileStationTests(out double gainValue /* unit : dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:MS:RF:GAIN?\n";
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            gainValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENS:CORR:MS:RF:LOSS -15 */
        public int SetExternalAttenuationForMobileStationTests(double lossValue /* range = [100, 100]dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:MS:RF:LOSS " + lossValue + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:MS:RF:LOSS? */
        public int QueryExternalAttenuationForMobileStationTests(out double lossValue /* unit : dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:MS:RF:LOSS?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            lossValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENS:CORR:BTS:RF:GAIN 10 */
        public int SetExternalGainForBaseTransceiverStationTests(double gainValue /* range = [-100, 100]dB */)
        {
            int error, count;
            string command = ":SENSe:CORRection:BTS::RF:GAIN " + gainValue + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:BTS:RF:GAIN? */
        public int QueryExternalGainForBaseTransceiverStationTests(out double gainValue /* unit : dB */)
        {
            int error, count;
            string command = ":SENSe:CORRection:BTS:RF:GAIN?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            gainValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENS:CORR:BTS:RF:LOSS 10 */
        public int SetExternalAttenuationForBasetransceiverStationTests(double lossValue /* min. 100dB, max. -100dB */)
        {
            int error, count;
            string command = ":SENSe:CORRection:BTS:RF:LOSS " + lossValue + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:BTS:RF:LOSS? */
        public int QueryExternalAttenuationForBaseTransceiverStationTests(out double lossValue /* unit : dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:BTS:RF:LOSS?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            lossValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENS:CORR:SA:RF:GAIN 50 */
        public int SetExtPreampGainForSA(double gainValue /* min. -120dB, max. 120dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:SA:RF:GAIN " + gainValue + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:SA:RF:GAIN? */
        public int GetExtPreampGainForSA(out double gainValue)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:SA:RF:GAIN?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            gainValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENS:CORR:CSET1:ANT:UNIT GAUS */
        public enum PowerFieldStrenghUnit
        {
            NOConversion = 0,       /* dBm    - RF signal power unit */
            GAUSs        = 1,       /* Gausss - Electromagnetic field strength unit, dBG */
            PTESla       = 2,       /* pTesla - Electromagnetic field strength unit, dBpT */
            UVM          = 3,       /* dBuV/m - the unit of signal power or field strength */
            UAM          = 4,       /* dBuA/m - the unit of signal power or field strength */
            UA           = 5        /* dBuA   - signal power unit */
        }
        public int SetAntennaFieldStrengthUnit(PowerFieldStrenghUnit unit)
        {
            string conversionUnit = "";
            switch (unit)
            {
                case PowerFieldStrenghUnit.NOConversion:
                    conversionUnit = "NOConversion";
                    break;
                case PowerFieldStrenghUnit.GAUSs:
                    conversionUnit = "GAUSs";
                    break;
                case PowerFieldStrenghUnit.PTESla:
                    conversionUnit = "PTESla";
                    break;
                case PowerFieldStrenghUnit.UVM:
                    conversionUnit = "UVM";
                    break;
                case PowerFieldStrenghUnit.UAM:
                    conversionUnit = "UAM";
                    break;
                case PowerFieldStrenghUnit.UA:
                    conversionUnit = "UA";
                    break;
            }
            string command = ":SENSe:CORRection:CSET:ANTenna:UNIT " + conversionUnit + "\n", response;
            int error = 0, count = 0;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:CSET:ANT:UNIT? */
        public int GetAntennaFieldStrengthUnit(out string unit)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:CSET:ANTenna:UNIT?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            unit = Encoding.ASCII.GetString(response, 0, count-1);
            return error;
        }   
        
        /* :SENSe:CORRection:CSET:ALL:STATe ON */
        public int ApplyAmplitudeCorrectionsOnOff(State state)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:CSET:ALL:STATe " + state + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }       
        
        /* :SENS:CORR:CSET:ALL:STAT? */ 
        public int QueryAmplitudeCorrectionsState(out string state)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:CSET:ALL:STATe?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);

            state = ((Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count)) == 1) ? "ON" : "OFF");
            return error;
        }   
        
        /* :SENS:CORR:CSET:ALL:DEL */
        public int EraseAllAmplitudeCorrections()
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:CSET:ALL:DELete\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INSTrument:SELect SA
         * 
         * [Notice] only the below modes can be selected, whether it can be activated depends on the software options
         *          you purchased the license for this Agilent MXA Signal Analyzer N9020A.
         * The available modes are :
         * SA,          RTSA,       SEQAN,          EMI,            BASIC
         * WCDMA,       EDGEGAM,    WIMAXOFDMA,     VSA,            PNOISE
         * NFIGure,     ADEMOD,     BTooth,         TDSCDMA,        CDMA2K
         * CDMA1XEV,    LTE,        LTETDD,         LTEAFDD,        LTEATDD
         * MSR,         DVB,        DTMB,           DCTV,           ISDBT
         * CMMB,        WLAN,       CWLAN,          CWIMAXOFDM,     WIMAXFIXED
         * IDEN,        RLC,        SCPILC,         VSA89601
         */
        public int SelectMeasurementMode(string mode)
        {
            int error = 0, count = 0;
            string command = ":INSTrument:SELect " + mode.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INST:SEL? */
        public int QueryWhichModeToBeSelected(out string mode)
        {
            int error = 0, count = 0;
            string command = ":INSTrument:SELect?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            mode = Encoding.ASCII.GetString(response, 0, count-1);
            return error;
        }

        /* :INST:CAT? */
        public int QueryInstalledApplicationModeCatalog(out string[] modes)
        {
            int error = 0, count = 0;
            string command = ":INSTrument:CATalog?\n";
            byte[] response = new byte[512];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 512, out count);

            string catalog = Encoding.ASCII.GetString(response, 0, count);
            modes = catalog.Substring(1, catalog.Length - 3).Split(',');
            return error;
        }

        /* :SYST:APPL? */
        public int QueryCurrentApplicationModelName(out string modelName)
        {
            int error = 0, count = 0;
            string command = ":SYSTem:APPLication:CURRent:NAME?\n";
            byte[] respone = new byte[64];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, respone, 64, out count);
            modelName = Encoding.ASCII.GetString(respone, 0, count-1);
            return error;
        }

        /* :SYST:APPL:REV? */
        public int QueryCurrentApplicationRevision(out string revision)
        {
            int error = 0, count = 0;
            string command = ":SYSTem:APPLication:CURRent:REVision?\n";
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            revision = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :SYST:APPL:OPT? */
        public int QueryCurrentApplicationOptions(out string options)
        {
            int error = 0, count = 0;
            string command = ":SYSTem:APPLication:CURRent:OPTion?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            options = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :SENS:RAD:STAN:SEL NONE 
         * 
         * Only these standards can be selected : NONE,  JSTD,  IS95a,  IS97D, IS98D, 
         * GSM,  W3GPP,  C2000MC1,  C20001X,  NADC,  PDC,  BLUEtooth, TETRa,  WL802DOT11A,
         * WL802DOT11B, WL802DOT11G,  HIPERLAN2, DVBTLSN,  DVBTGPN,  DVBTIPN, FCC15, SDMBSE,
         * UWBINDOOR, LTEB1M4, LTEB3M,  LTEB5M, LTEB10M, LTEB15M, LTEB20M,  WL11N20M, WL11N40M,
         * WL11AC20M,  WL11AC40M,  WL11AC80M, WL11AC160M, WL11AD2G
         */
        public int SelectRadioStandardInSpectrumAnalyzerMode(string radioStandard)
        {
            int error = 0, count = 0;
            string command = ":SENSe:RADio:STANdard:SELect " + radioStandard.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* SENS:RAD:STAN:SEL? */
        public int QueryWhichRadioStandardToBeSelected(out string radioStandard)
        {
            int error = 0, count = 0;
            string command = ":SENSe:RADio:STANdard:SELect?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            radioStandard = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :SENS:RAD:STAN:DEV BTS */
        public int SpecifyRadioStandardDeviceType(string deviceType /* only "BTS"(Base Transceiver Station) and "MS"(Mobile Station) options */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:RADio:STANdard:DEVice " + deviceType + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* SENSe:RADio:STANdard:DEVice? */
        public int QueryRadioStandardDeviceType(out string deviceType)
        {
            int error = 0, count = 0;
            string command = ":SENSe:RADio:STANdard:DEVice?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            deviceType = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :SENS:RAD:STAN:EAM NO */
        public int EnableNonStandardMeasurements(string yes_no)
        {
            int error = 0, count = 0;
            string command = ":SENSe:RADio:STANdard:EAMeas " + yes_no.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INSTrument:DEFault */
        public int RestoreModeDefaults()
        {
            int error = 0, count = 0;
            string command = ":INSTrument:DEFault\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SYST:PRESet:TYPE FACTory */
        public int SelectSystemPresetType(string presetType /* only "FACTORY", "MODE" and "USER" 3 options are available. */)
        {
            int error = 0, count = 0;
            string command = ":SYSTem:PRESet:TYPE " + presetType.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SYST:PRES:TYPE? */
        public int QuerySystemPresetType(out string presetType)
        {
            int error = 0, count = 0;
            string command = ":SYSTem:PRESet:TYPE?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            presetType = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :CALibration:ALL? */
        public int QueryAllCalibrationDone(out int done)
        {
            int error = 0, count = 0;
            string command = ":CALibration:ALL?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            done = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :DISP:WIND1:TRAC:Y:SCAL:RLEV 20 dBm */
        public int SetAmplitudeYScaleReferenceLevel(int windowNo = 1, 
                                                    double refLevel = 0.00, 
                                                    string unit = "dBm" /* unit options : dBm, mV, uV, uA are available */)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow" + windowNo + ":TRACe:Y:SCALe:RLEVel " + refLevel + " " + unit + "\n";
            string response;

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :DISP:WIND1:TRAC:Y:SCAL:RLEV? */
        public int QueryAmplitudeYScaleReferenceLevel(int windowNo, out double refLevel /*unit : dBm */)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow" + windowNo + ":TRACe:Y:SCALe:RLEVel?\n";
            byte[] response = new byte[256];

            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            refLevel = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:POW:RF:ATT 20 */
        public int SetAmplitudeYScaleAttenuation(uint attenuatorValue)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:ATTenuation " + attenuatorValue + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:POW:RF:ATT? */
        public int QueryAmplitudeYScaleAttenuation(out uint attenuatorValue)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:ATTenuation?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            attenuatorValue = Convert.ToUInt32(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:POW:RF:ATT:AUTO ON */
        public int EnableAmplitudeYScaleAttenuationAuto(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:ATTenuation:AUTO " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:POW:RF:ATT:STEP:INCR 2 dB */
        public int ControlMechanicAttenuationStepSize(string stepSize = "2 dB" /* only "2 dB" and "10 dB" can be selected. */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:ATTenuation:STEP:INCRement " + stepSize + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:POW:RF:ATT:STEP:INCR? */
        public int QueryMechanicAttenuationStepSize(out int stepSize /* unit : dB */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:ATTenuation:STEP:INCRement?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            stepSize = (int)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:POW:RF:MIX:RANG:UPP -15 dBm */
        public int SetAmplitudeYAttenuationMaxMixerLevel(string maxMixerLevel = "-10 dBm")
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:MIXer:RANGe:UPPer " + maxMixerLevel + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:POW:RF:MIX:RANG:UPP? */
        public int QueryAmplitudeYAttenuationMaxMixerLevel(out double maxMixerLevel /* unit : dBm */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:MIXer:RANGe:UPPer?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            maxMixerLevel = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :DISP:WIND1:TRAC:Y:SCAL:SPAC LOG */
        public int ChooseAmplitudeYScaleType(string scaleType = "LOG" /* Only "LOG" and "LIN" can be chosen. */)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow:TRACe:Y:SCALe:SPACing " + scaleType + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :DISP:WIND:TRAC:Y:SCAL:SPAC? */
        public int QueryAmplitudeYScaleType(out string scaleType)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow:TRACe:Y:SCALe:SPACing?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            scaleType = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }
#endregion
    }
}
