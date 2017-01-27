using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace RUI.Output
{
    class TextLogger : IRUILogger
    {
        String fileName;
        StreamWriter sw;
        LogTimeType logTimeType;
        DateTime startTime;

        public TextLogger(String file, LogTimeType logType)
        {
            fileName = file;
            logTimeType = logType;
            startTime = DateTime.Now;

            sw = File.AppendText(fileName);            
            sw.Write("Subject Name:");
            sw.WriteLine(file);
            String expDate;
            expDate = DateTime.Now.Date.ToLongDateString();

            sw.Write("File Created: ");
            String fileCreationTime = DateTime.Now.ToString();
            sw.Write(fileCreationTime);
            sw.WriteLine(" ");
            sw.Write("Version: 2.3");
            sw.WriteLine(" ");
            sw.WriteLine("Released: 4/22/2012");            
            sw.WriteLine(" ");
            String labels = "";
            labels += "Elapsed Time " + "\t" +
                "Action " + "\t" + " X" + "\t" + "Y" +
                "\r\n";
            sw.Write(labels);

            sw.AutoFlush = true;
        }

        #region IRUILogger Members

        public void LogKeyStroke(DateTime time, string key, string modifier)
        {
            string dateTime = this.GetTime(time);

            if (modifier == null)
            {
                sw.Write(dateTime + "\t" + "Key" + "\t" + key + "\r\n");
            }
            else
            {
                //sw.Write(dateTime + "\t" + "Key\t " + modifier + " & " + key + " \r\n");
                sw.Write(dateTime + "\t" + "Key\t " + key + "\t" + modifier + "\r\n");
            }
        }

        public void LogMousePosition(DateTime time, int x, int y)
        {
            sw.Write(this.GetTime(time) + "\t" + "Moved" + "\t" + x.ToString() + "\t" + y.ToString() + "\r\n");
        }

        public void LogMouseClick(DateTime time, String mouseInput, MouseInputType inputType, int x, int y)
        {
            sw.Write(this.GetTime(time) + "\t" + inputType.ToString() + " " + mouseInput + "\t" + x.ToString() + "\t" + y.ToString() +  "\r\n");
        }

        public void StopLogging()
        {
            sw.Flush();
            sw.Close();
        }

        public void LogTaskBreakDown(string taskBreakdown)
        {
            try
            {
                sw.Write("\r\n" + " \tTaskBreakdown\t:\t" + taskBreakdown + "\r\n");
            }
            catch (Exception ex)
            {
            }
        }

        public void LogTaskSwitch(string newTask)
        {
            sw.Write("\t" + "Task\t:\t" + newTask + "\r\n");
        }

        #endregion

        private string GetTime(DateTime time)
        {
            string milliSecs = time.Millisecond.ToString();
            if (this.logTimeType.Equals(LogTimeType.Absolute))
            {
                //lastLoggedTime = time;
                return time.ToString("s") + "." + milliSecs;
            }
            else if (this.logTimeType.Equals(LogTimeType.Relative))
            {
                TimeSpan elapsedTime;
                string TimeInString = "";
                elapsedTime = time.Subtract(startTime);             
                
                decimal mil = (System.Convert.ToDecimal(elapsedTime.TotalMilliseconds / 1000));

                TimeInString = String.Format("{0:0.###}", mil);
                
                return TimeInString;
            }

            //lastLoggedTime = time;

            return null;
        }
    }

    enum LogTimeType
    {
        Absolute,
        Relative
    }
}
