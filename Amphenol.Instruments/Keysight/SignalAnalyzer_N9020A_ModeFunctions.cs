using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class SignalAnalyzer_N9020A
    {
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

        /* :INITiate:SANalyzer 
         * :CONFigure:SANalyzer:NDEFault
         * 
         * For the measurement item, only the following items can be chosen.
         * 
         * Name                   |  Meaning
         * =======================|=====================================================
         * SANalyzer              |  Swept SA measurement
         * =======================|=====================================================
         * CHPower                |  Channel Power measurement
         * =======================|=====================================================
         * OBWidth                |  Occupied Bandwidth measurement
         * =======================|=====================================================
         * ACPower                |  ACP measurement
         * =======================|=====================================================
         * PStatistic             |  Power Stat. CCDF measurement
         * =======================|=====================================================
         * TXPower                |  Burst Power (Transmit Power) measurement
         * =======================|=====================================================
         * SPURious               |  Spurious Emission measurement
         * =======================|=====================================================
         * SEMask                 |  Spectrum Emission measurement
         * =======================|=====================================================
         * TOI                    |  TOI measurement
         * =======================|=====================================================
         * HARMonics              |  Harmonic measurement
         * =======================|=====================================================
         * LIST                   |  List Sweep measurement
         * =======================|=====================================================
         */
        public int SelectMeasurementItemInSignalAnalyzerMode(string measurementName = "SANalyzer")
        {
            int error = 0, count = 0;
            string command = ":CONFigure:" + measurementName + "\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CONFigure:" + measurementName + ":NDEFault\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":CONFigure?\n";
            byte[] response = new byte[256];                                                             
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            string result = Encoding.ASCII.GetString(response, 0, count - 1);

            command = ":INITiate:" + measurementName + "\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            string errstr;
            return QuerySystemError(out errstr);
        }


        /**************************************************************************************************************/

        
        #region Mode Functions
        /* :INST:SEL? */
        public int QueryWhichModeToBeSelected(out string mode)
        {
            int error = 0, count = 0;
            string command = ":INSTrument:SELect?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            mode = Encoding.ASCII.GetString(response, 0, count - 1);
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
            modelName = Encoding.ASCII.GetString(respone, 0, count - 1);
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

        /* :SYSTEM:APPLICATION:CATALOG:NAME? */
        public int QueryModelNameOfInstalledApplication(out string modelName)
        {
            int error = 0, count = 0;
            string command = ":SYSTem:APPLication:CATalog:NAME?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            modelName = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :INST:COUP:DEF */
        public int RestoreAllModesGlobalSettingsToDefault()
        {
            int error = 0, cout = 0;
            string command = ":INSTrument:COUPle:DEFault\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out cout);
            return QuerySystemError(out response);
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

        #endregion
    }
}