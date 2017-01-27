using System;
using System.Collections.Generic;
using System.Text;
using CarlosAg.ExcelXmlWriter;

namespace RUI.Output
{
    class ExcelLogger : IRUILogger
    {
        private String fileName;
        private Workbook book;
        private Worksheet sheet;
        private LogTimeType logTimeType;
        private DateTime startTime;

        public ExcelLogger(String fileName, LogTimeType logType)
        {
            this.fileName = fileName;
            logTimeType = logType;
            startTime = DateTime.Now;

            book = new Workbook();
            sheet = book.Worksheets.Add("RUI-Log");
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add("Time");
            row.Cells.Add("Action");
            row.Cells.Add("Key");
            row.Cells.Add("Modifier");
            row.Cells.Add("MouseClick");
            row.Cells.Add("X");
            row.Cells.Add("Y");
            row.Cells.Add("Task");
        }

        #region IRUILogger Members

        public void LogKeyStroke(DateTime time, string key, string modifier)
        {
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add(this.GetTime(time).ToString());
            row.Cells.Add("Key");
            row.Cells.Add(key);
            row.Cells.Add(modifier);
        }

        public void LogMousePosition(DateTime time, int x, int y)
        {
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add(this.GetTime(time).ToString());
            row.Cells.Add("Move");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add(x.ToString());
            row.Cells.Add(y.ToString());
        }

        public void LogMouseClick(DateTime time, string mouseInput, MouseInputType inputType)
        {
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add(this.GetTime(time).ToString());

            if(inputType.Equals(MouseInputType.Released))
            {
                row.Cells.Add("Released");
            }
            else
            {
                row.Cells.Add("Pressed");
            }
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add(mouseInput);
        }

        public void StopLogging()
        {
            book.Save(fileName);
        }

        public void LogTaskBreakDown(string taskBreakdown)
        {
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add("");
            row.Cells.Add("Task Breakdown");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add(taskBreakdown);
        }

        public void LogTaskSwitch(string newTask)
        {
            WorksheetRow row = sheet.Table.Rows.Add();
            row.Cells.Add("");
            row.Cells.Add("Task Switch");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add("");
            row.Cells.Add(newTask);
        }

        #endregion

        private string GetTime(DateTime time)
        {

            string milliSec = time.Millisecond.ToString();

            if (milliSec.Length == 2)
            {
                milliSec = "0" + milliSec;
            }
            else if (milliSec.Length == 1)
            {
                milliSec = "00" + milliSec;
            }

            if (this.logTimeType.Equals(LogTimeType.Absolute))
            {
                //lastLoggedTime = time;
                return time.ToString("s") + ":" + milliSec;
            }
            else if (this.logTimeType.Equals(LogTimeType.Relative))
            {
                //DateTime stopTime;
                TimeSpan elapsedTime;
                string TimeInString = "";
                //stopTime = DateTime.Now;
                elapsedTime = time.Subtract(startTime);

                int hour = elapsedTime.Hours;
                int min = elapsedTime.Minutes;
                int sec = elapsedTime.Seconds;
                int milli = elapsedTime.Milliseconds;
                TimeInString = (hour < 10) ? "0" + hour.ToString() : hour.ToString();
                TimeInString += ":" + ((min < 10) ? "0" + min.ToString() : min.ToString());
                TimeInString += ":" + ((sec < 10) ? "0" + sec.ToString() : sec.ToString());
                TimeInString += ":" + ((milli < 10) ? "0" + milli.ToString() : milli.ToString());

                return TimeInString;
            }

            //lastLoggedTime = time;

            return null;
        }
    }
}
