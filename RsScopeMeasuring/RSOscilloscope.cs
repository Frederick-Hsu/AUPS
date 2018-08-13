using System;
using System.Text.RegularExpressions;

using Ivi.Driver;
using Ivi.Scope;
using RohdeSchwarz.RsScope;

namespace RsScopeMeasuring
{
    public class RSOscilloscope
    {
        private RsScope driver;

        public RSOscilloscope(string visaAddr)
        {
            /* Initializing a new session is performed by creating a RsScope object */
            driver = new RsScope(visaAddr, true, true, "Simulation=False");
            driver.Utility.Reset();     /* Specify whether to reset the instrument during the initialization */

            // driver.Utility.Lock();      /* multi-thread locking of the session */
            driver.DriverOperation.Simulate = false;
            string ioRsrc = driver.DriverOperation.IOResourceDescriptor;
            string logName = driver.DriverOperation.LogicalName;

            driver.DriverOperation.RangeCheck = true;
            driver.DriverOperation.QueryInstrumentStatus = false;
        }

        public enum ChannelIndex
        {
            CH1 = 0,
            CH2 = 1,
            CH3 = 2,
            CH4 = 3
        }
        public int ChannelCount
        {
            get { return driver.System.ChannelCount; }
        }
        public string FirmwareVersion
        {
            get { return driver.System.FirmwareVersion; }
        }

        #region Direct SCPI write/query
        public int GetInstrumentIdentifier(out string idn)
        {
            bool oldStatus = driver.DriverOperation.QueryInstrumentStatus;
            driver.DriverOperation.QueryInstrumentStatus = false;

            driver.UtilityFunctions.WriteCommand("*IDN?");
            idn = driver.UtilityFunctions.ReadCommand();
            // idn = driver.UtilityFunctions.IDQueryResponse;
            driver.DriverOperation.QueryInstrumentStatus = oldStatus;
            return 0;
        }
        #endregion

        #region Channels setup, using repeated capabilities
        public int ConfigureHorizontalScale(int acquisitionTime /* unit : us*/)
        {
            driver.Acquisition.HorizontalRecordSelection = RecordSelection.RecordTime;
            driver.Acquisition.HorizontalTimePerRecord = Ivi.Driver.PrecisionTimeSpan.FromMicroseconds(acquisitionTime);
            driver.Acquisition.HorizontalRecordLength = 1002;
            return 0;
        }
        #endregion

        #region Configure the user-specific channel
        public IRsScopeChannel Channel(ChannelIndex index)
        {
            string channelName;
            switch (index)
            {
                case ChannelIndex.CH1:
                    channelName = "CH1"; break;
                case ChannelIndex.CH2:
                    channelName = "CH2"; break;
                case ChannelIndex.CH3:
                    channelName = "CH3"; break;
                case ChannelIndex.CH4:
                    channelName = "CH4"; break;
                default:
                    channelName = "CH1"; break;
            }
            IRsScopeChannel ch = driver.Channel[channelName];
            ch.Configure(5.00, 0.0, RohdeSchwarz.RsScope.VerticalCoupling.AC, true);
            return ch;
        }

        public string ChannelName(ChannelIndex index)
        {
            string channelName = "";
            switch (index)
            {
                case ChannelIndex.CH1:
                    channelName = "CH1"; break;
                case ChannelIndex.CH2:
                    channelName = "CH2"; break;
                case ChannelIndex.CH3:
                    channelName = "CH3"; break;
                case ChannelIndex.CH4:
                    channelName = "CH4"; break;
                default:
                    channelName = "CH1"; break;
            }
            return channelName;
        }
        #endregion

        #region Trigger settings
        public IRsScopeTrigger ConfigureTrigger(RohdeSchwarz.RsScope.TriggerModifier mode, 
                                                double timeout,
                                                RohdeSchwarz.RsScope.TriggerSource source,
                                                RohdeSchwarz.RsScope.TriggerType type,
                                                RohdeSchwarz.RsScope.Slope slope,
                                                ChannelIndex chnum,
                                                double triggerLevel)
        {
            IRsScopeTrigger trigger = driver.Trigger["TrigA"];
            trigger.Modifier = mode;
            trigger.Timeout.TimeoutValue = timeout;
            trigger.Source = source;
            trigger.Type = type;
            trigger.Edge.Slope = slope;
            trigger.Channel[ChannelName(chnum)].Level = triggerLevel;

            return trigger;
        }

        public void AcquireWaveform(ChannelIndex chnum)
        {
            IWaveform<double> waveform_CH = null;
            waveform_CH = driver.Channel[ChannelName(chnum)].Waveform["W0"].FetchWaveform(waveform_CH);

            int oldTimeout = driver.UtilityFunctions.OPCTimeout;
            int newRecordLength = 1100;
            driver.Acquisition.HorizontalRecordLength = newRecordLength;
            driver.UtilityFunctions.OPCTimeout = 3000;

            var trigger = driver.Trigger["TrigA"];
            trigger.Source = RohdeSchwarz.RsScope.TriggerSource.Channel2;
            trigger.Channel[ChannelName(chnum)].Level = 0.2;

            double[] samplesArray_CH = new double[waveform_CH.Capacity];
            samplesArray_CH = waveform_CH.GetAllElements();
            // driver.WaveformAcquisition.RunSingle();
        }
        #endregion

        #region Measurements
        public void PerformMeasurements(out double meas1Amplitude, out double meas2Frequency, out double meas3Amplitude)
        {
            var Meas1 = driver.Measurements["M1"];
            var Meas2 = driver.Measurements["M2"];
            var Meas3 = driver.Measurements["M3"];

            /* Measurement #1 */
            Meas1.AmplitudeTime.MainMeasurement = AmplitudeTimeMeasurementType.Amplitude;
            Meas1.GeneralSettings.Source(WaveformParameter.Channel1Waveform1, WaveformParameter.Channel1Waveform1);
            Meas1.GeneralSettings.Enabled = true;

            /* Measurement #2 */
            Meas2.AmplitudeTime.MainMeasurement = AmplitudeTimeMeasurementType.Frequency;
            Meas2.GeneralSettings.Source(WaveformParameter.Channel1Waveform1, WaveformParameter.Channel1Waveform1);
            Meas2.GeneralSettings.Enabled = true;

            /* Measurement #3 */
            Meas3.AmplitudeTime.MainMeasurement = AmplitudeTimeMeasurementType.Amplitude;
            Meas3.GeneralSettings.Source(WaveformParameter.Channel2Waveform1, WaveformParameter.Channel2Waveform1);
            Meas3.GeneralSettings.Enabled = true;

            /* Continue only when all previous commands were processed */
            int opc = driver.UtilityFunctions.QueryOPC;

            meas1Amplitude = Meas1.Results.FetchMainMeasurement(StatisticsType.Actual);
            meas2Frequency = Meas2.Results.FetchMainMeasurement(StatisticsType.Actual);
            meas3Amplitude = Meas3.Results.FetchMainMeasurement(StatisticsType.Actual);
        }
        #endregion

        #region Hardcopy
        public void CaptureWaveformScreenshot(string scopeFilePath, string hostFilePath)
        {
            var hcpy = driver.HardcopyAndPrinter;
            var hcpy_dest = driver.HardcopyAndPrinter.Destination["DE1"];

            /*
            string scopeFileFolder = @"C:\Temp";
            scopeFilePath = scopeFileFolder + @"\" + "1MA268_screenshot_RTx.png";
            hostFilePath = @"C:\Temp\1MA268_screenshot_RTx.png";
             */

            hcpy_dest.DeviceDestination = HardcopyDevice.File;
            hcpy_dest.Color = true;
            hcpy_dest.DeviceLanguageOutputFormat = HardcopyDeviceLang.png;
            hcpy_dest.WhiteBackground = false;
            hcpy_dest.PrintColorSet = HardcopyPrintColorSet.Default4;
            hcpy_dest.InverseColors = false;
            hcpy.FileName = scopeFilePath;

            /* Make a screenshot now */
            hcpy.Print();
            /* Copy the waveform screenshot file from Scope to host PC. */
            driver.DataManagement.ReadToFileFromInstrument(scopeFilePath, hostFilePath);

            /* Copy the waveform screenshot file from host PC to scope */
            // driver.DataManagement.WriteFromFileToInstrument(hostFilePath, scopeFilePath);
        }
        #endregion

        #region Reading RTx folder list
        public void ReadScopeFolderList()
        {
            string scopeFolder = @"C:\Temp";
            string folderContent = driver.DataManagement.FileDirectoryContent(scopeFolder);
            Match match = new Regex("(\\d+),\\d+,\"[^\"]+\",\"[^\"]+\",(.+)$").Match(folderContent);
            if (match.Success)
            {
                int usedSize = Int32.Parse(match.Groups[1].Value) / 1024;
                string info = match.Groups[2].Value;

                Console.WriteLine("\n\nFolder \"{0}\", size {1} kb, files list:", scopeFolder, usedSize);
                while ((match = new Regex("(\\d+),\\d+,\"[^\"]+\",\"[^\"]+\",(.+)$").Match(info)).Success)
                {
                    info = match.Groups[4].Value;
                    Console.WriteLine("File name: \"{0}\", type \"{1}\", size {2}kb", 
                                      match.Groups[1].Value, 
                                      match.Groups[2].Value,
                                      Int32.Parse(match.Groups[3].Value)/1024);
                }
            }
        }
        #endregion
    }

    public static class Extensions_of_RsScope
    {
        #region RunSingle() with repeat workaround
        public static bool Extended_RunSingleWithRepeat(this RsScope driver, IRsScopeTrigger trigger, int maxRepeats)
        {
            string exceptionMesg = "";
            bool repeat = false;
            bool success = false;
            do
            {
                repeat = false;
                try
                {
                    maxRepeats--;
                    driver.WaveformAcquisition.RunSingle();
                    success = true;
                }
                catch (Ivi.Driver.MaxTimeExceededException exception)
                {
                    exceptionMesg = "\nTimeout occurred:\n" + exception.Message + "\n\nStackTrace\n" + exception.StackTrace;
                }
                catch (Ivi.Driver.IOException exception)
                {
                    exceptionMesg = "\nIO error occurred:\n" + exception.Message + "\n\nStackTrace\n" + exception.StackTrace;
                }
                catch (Ivi.Driver.InstrumentStatusException exception)
                {
                    exceptionMesg = "\nInstrument error occurred:\n" + exception.Message + "\n\nStackTrace\n" + exception.StackTrace;
                }
                catch (Ivi.Driver.DataArrayTooSmallException exception)
                {
                    exceptionMesg = "\nError - waveform array is too small for the data\n" + exception.Message + "\n\nStackTrace\n" + exception.StackTrace;
                }
                catch (Ivi.Driver.OutOfRangeException exception)
                {
                    exceptionMesg = "\nValue out of range exception occurred:\n" + exception.Message + "\n\nStackTrace\n" + exception.StackTrace;
                }
                finally
                {
                    if (exceptionMesg != null)
                        Console.WriteLine(exceptionMesg);
                    Console.WriteLine("\nPress any key to close...");
                    Console.ReadKey();

                    /* close the driver and disposing of the driver object */
                    driver.Dispose();
                }
            }
            while (maxRepeats == 0);
            return success;     
        }
        #endregion
    }
}