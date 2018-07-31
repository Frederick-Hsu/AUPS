using System;
using System.Text;

namespace Amphenol.Instruments.Keysight
{
    partial class SignalAnalyzer_N9020A
    {
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

        #region Swept SA Measurement
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

        /* :DISP:WIND:TRAC:Y:SCAL:PDIV 10*/
        public int SetAmplitudeYScaleDivision(int graticuleDivision = 10)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow:TRACe:y:SCALe:PDIVision " + graticuleDivision + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :DISP:WIND:TRAC:Y:SCAL:PDIV? */
        public int QueryAmplitudeYScaleDivision(out int graticuleDivision)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow:TRACe:Y:SCALe:PDIVision?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            graticuleDivision = (int)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
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

        /* :UNIT:POW DBM */
        public int SetAmplitudeYAxisUnit(string unit = "dBm")
        {
            int error = 0, count = 0;
            string command = ":UNIT:POWer " + unit + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :UNIT:POW? */
        public int QueryAmplitudeYAxisUnit(out string unit)
        {
            int error = 0, count = 0;
            string command = ":UNIT:POWer?\n";
            byte[] response = new byte[32];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 32, out count);
            unit = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :DISP:WIND:TRAC:Y:SCAL:RLEV:OFFS 12.7 */
        public int SetAmplitudeReferenceLevelOffset(double offsetValue /* range = [-327.6, 327.6]dB */)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow:TRACe:Y:SCALe:RLEVel:OFFSet " + offsetValue + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :DISP:WIND:TRAC:Y:SCAL:RLEV:OFFS? */
        public int QueryAmplitudeReferenceLevelOffset(out double offsetValue)
        {
            int error = 0, count = 0;
            string command = ":DISPlay:WINDow:TRACe:Y:SCALe:RLEVel:OFFSet?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            offsetValue = Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count));
            return error;
        }

        /* :SENS:POW:RF:GAIN:STAT ON */
        public int TurnOnOffAmplitudeInternalPreamp(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:GAIN:STATe " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:POW:RF:GAIN:STAT? */
        public int QueryAmplitudeInternalPreampState(out int state)
        {
            int error = 0, count = 0;
            string command = ":SENSe:POWer:RF:GAIN:STATe?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            state = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :COUP ALL */
        public int SetAutoCoupleFeature(string auto_manual_mode /* only "ALL" and "NONE" options.*/ )
        {
            int error = 0, count = 0;
            string command = ":COUPle " + auto_manual_mode + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:RES:AUTO ON */
        public int ToggleResolutionBandwidthAutoManualMode(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:RESolution:AUTO " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* SENS:BAND:RES 240 */
        public int SetResolutionBandwidthValue(uint resBW /* unit : Hz*/)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:RESolution " + resBW + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:RES? */
        public int QueryResolutionBandwidth(out uint resBWInHz)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:RESolution?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            resBWInHz = (uint)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:BAND:VID:AUTO ON */
        public int ToggleVideoBandwidthAutoManualMode(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:VIDeo:AUTO " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:VID: 1000 */
        public int SetVideoBandwidthValue(uint videoBW /* unit : Hz */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:VIDeo " + videoBW + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:VID? */
        public int QueryVideoBandwidth(out uint videoBW)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:VIDeo?\n";
            byte[] response = new byte[128];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 128, out count);
            videoBW = (uint)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:BAND:VID:RAT 2 */
        public int SetVideoBandwidthVersusResBandwidthRatio(int ratio)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:VIDeo:RATio " + ratio + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:VID:RAT? */
        public int QueryVideoBandwidthVsResBandwidthRatio(out int ratio)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:VIDeo:RATio?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            ratio = Convert.ToInt32(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:BAND:VID:RAT:AUTO ON */
        public int EnableVideoBandwidthVersusResBandwidthAutoRatio(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:VIDeo:RATio:AUTO " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:SPAN:BAND:RES:RAT 106 */
        public int SelectSpanVersusResBandwidthRatio(int ratio)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:SPAN:BANDwidth:RESolution:RATio " + ratio + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:SPAN:BAND:RES:RAT? */
        public int QuerySpanVersusResBandwidthRatio(out int ratio)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:SPAN:BANDwidth:RESolution:RATio?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            ratio = (int)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:FREQ:SPAN:BAND:RES:RAT:AUTO ON */
        public int EnableSpanVersusResBandwidthAutoRatio(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:SPAN:BANDwidth:RESolution:RATio:AUTO " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:SHAP GAUS */
        public int SelectShapeOfResBandwidthFilters(string shape = "GAUSsian" /* only "GAUSsian" and "FLATtop" options available */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:SHAPe " + shape + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* SENS:BAND:SHAP? */
        public int QueryShapeOfResBandwidthFilters(out string shape)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:SHAPe?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            shape = Encoding.ASCII.GetString(response, 0, count - 1);
            return error;
        }

        /* :SENS:BAND:TYPE DB3 */
        public int SpecifyFilterWidthForGaussianFilterShape(string width = "DB3")
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:TYPE " + width + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:BAND:TYPE? */
        public int QueryFilterWidthForGaussianFilterShape(out string width)
        {
            int error = 0, count = 0;
            string command = ":SENSe:BANDwidth:TYPE?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            switch (Encoding.ASCII.GetString(response, 0, count - 1))
            {
                case "DB3":
                    width = "-3 dB"; break;
                case "DB6":
                    width = "-6 dB"; break;
                case "IMP":
                    width = "Impulse"; break;
                case "NOIS":
                    width = "Noise"; break;
                default:
                    width = ""; break;
            }
            return error;
        }

        /* :INIT:CONT ON */
        public int SetAnalyzerInContinuousMeasurementOperation(State on_off)
        {
            int error = 0, count = 0;
            string command = ":INITiate:CONTinous " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :INIT:CONT? */
        public int QueryAnalyzerMeasurementOperationState(out string continousState)
        {
            int error = 0, count = 0;
            string command = ":INITiate:CONTinous?\n";
            byte[] response = new byte[32];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 32, out count);
            if (Encoding.ASCII.GetString(response, 0, count - 1) == "1")
                continousState = "ON";
            else
                continousState = "OFF";
            return error;
        }

        /* :SENS:FREQ:TUNE:IMM */
        public int AutoTuneFreqChannel()
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:TUNE:IMMediate\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:TZOom:CENTer? */
        public int QueryZoomCenterFrequencyInTraceZoomView(out long frequency)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:TZOom:CENTer?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            frequency = (long)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:FREQ:CENT 2.4 GHZ */
        public int SetCenterFrequency(string frequency)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:CENTer " + frequency.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:CENT? */
        public int RetrieveCenterFrequency(out long frequency /* unit : Hz */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:CENTer?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            frequency = (long)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:FREQ:RF:CENT 2.4GHZ */
        public int SetRFCenterFrequency(string frequency)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:RF:CENTer " + frequency.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:RF:CENT? */
        public int RetrieveRFCenterFrequency(out long frequency)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:RF:CENTer?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            frequency = (long)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:FREQ:STAR 200 MHZ 
         * :SENS:FREQ:STOP 400 MHZ
         */
        public int SetStartStopFrequency(string startFreq, string stopFreq)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:STARt " + startFreq + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);

            command = ":SENSe:FREQuency:STOP " + stopFreq + "\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:STAR?
         * :SENS:FREQ:STOP?
         */
        public int QueryStartStopFrequency(out long startFreq, out long stopFreq)
        {
            int error = 0, count = 0;
            string command = "::SENSe:FREQuency:STARt?\n";
            byte[] response = new byte[256];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            startFreq = (long)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));

            command = ":SENSe:FREQuency:STOP?\n";
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 256, out count);
            stopFreq = (long)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }

        /* :SENS:FREQ:CENT:STEP:AUTO ON */
        public int EnableStepSizeForCenterFrequency(State on_off)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:CENTer:STEP:AUTO " + on_off + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:OFFS 10MHZ */
        public int SetFrequencyOffset(string offset)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:OFFSet " + offset.ToUpper() + "\n", response;
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            return QuerySystemError(out response);
        }

        /* :SENS:FREQ:OFFS? */
        public int QueryFrequencyOffset(out long offset /* unit : Hz */)
        {
            int error = 0, count = 0;
            string command = ":SENSe:FREQuency:OFFSet?\n";
            byte[] response = new byte[64];
            error = visa32.viWrite(session, Encoding.ASCII.GetBytes(command), command.Length, out count);
            error = visa32.viRead(session, response, 64, out count);
            offset = (long)Convert.ToDouble(Encoding.ASCII.GetString(response, 0, count - 1));
            return error;
        }
        #endregion Swept SA Measurement
    }
}                                                    
