using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class SignalAnalyzer_N9020A
    {
        #region Input/Output Functions
        /* :SENS:FEED RF
         * 
         * only RF, AIQ and EMIXer 3 options are available.
         */
        public int SelectInputPort(string inputPort = "RF")
        {
            int error = 0, count = 0;
            string command = ":SENSe:FEED " + inputPort + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FEED? */
        public int QueryWhichInputPortToBeSelected(out string inputPort)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FEED?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            inputPort = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :INPUT:MIXER? */
        public int QueryWhichMixerToBeChoosen(out string mixerType)
        {
            int error = 0, count = 0;
            string command = ":INPut:MIXer?\n";
            byte[] response = new byte[32];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 32, out count);
            mixerType = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :INPut:MIXer EXTernal | INTernal */
        public int ChooseInputMixerType(string mixerType)
        {
            int error = 0, count = 0;
            string command = ":INPut:MIXer " + mixerType + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENSe:CORRection:IMPedance:INPut:MAGNitude 50 */
        public int SetRFInputImpedanceCorrection(Impedance imp)
        {
            int error, count;
            string command = ":SENSe:CORRection:IMPedance:INPut:MAGNitude " + Convert.ToInt32(imp) + "\n", response;
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
            string result = Encoding.ASCII.GetString(response, 0, count - 1);
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
            coupling = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :SENS:FEED:RF:PORT:INP RFIN | RFIN2 | RFIO1 | RFIO2 | RFIO3 | RFIO4 | RFHD | RFFD */
        public int SpecifyRFInputPortNumber(string inputPortNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FEED:RF:PORT:INPut " + inputPortNumber + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FEED:RF:PORT:INP? */
        public int QueryRFInputPortNumber(out string inputPortNumber)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FEED:RF:PORT:INPut?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            inputPortNumber = Encoding.ASCII.GetString(response, 0, count - 1);
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
            calibrator = Encoding.ASCII.GetString(response, 0, count - 1);
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

        /* :SYST:DEF INP */
        public int RestoreAllInputOutputToFactoryDefaults()
        {
            int error = 0, count = 0;
            string command = ":SYST:DEF INP\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:CSET1:STAT ON */
        public int TurnOnOffSelectedCorrectionState(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:CSET1:STAT " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:CORR:CSET1:STAT? */
        public int QuerySelectedCorrectionState(out string state)
        {
            int error = 0, count = 0;
            string command = ":SENSe:CORRection:CSET1:STATe?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            state = ((Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count - 1)) == 1) ? "ON" : "OFF");
            return error;
        }

        /* :SENS:CORR:CSET1:ANT:UNIT GAUS */
        public enum PowerFieldStrenghUnit
        {
            NOConversion = 0,       /* dBm    - RF signal power unit */
            GAUSs = 1,       /* Gausss - Electromagnetic field strength unit, dBG */
            PTESla = 2,       /* pTesla - Electromagnetic field strength unit, dBpT */
            UVM = 3,       /* dBuV/m - the unit of signal power or field strength */
            UAM = 4,       /* dBuA/m - the unit of signal power or field strength */
            UA = 5        /* dBuA   - signal power unit */
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
            unit = Encoding.ASCII.GetString(response, 0, count - 1);
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

            state = ((Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count - 1)) == 1) ? "ON" : "OFF");
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
        #endregion
    }
}