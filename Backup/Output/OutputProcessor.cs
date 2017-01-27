using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using RUI.Tasks;

namespace RUI.Output
{
    class OutputProcessor
    {
        public OutputProcessor()
        {
        }

        private double GetDistanceBetweenPoints(int startXPoint, int startYPoint, int endXPoint, int endYPoint)
        {
            int a = 0;
            int b = 0;

            if (startXPoint > endXPoint)
            {
                a = startXPoint - endXPoint;
            }
            else
            {
                a = endXPoint - startXPoint;
            }


            if (startYPoint > endYPoint)
            {
                b = startYPoint - endYPoint;
            }
            else
            {
                b = endYPoint - startYPoint;
            }

            int aSquared = a * a;
            int bSquared = b * b;

            int cSquared = aSquared + bSquared;

            double c = Math.Sqrt(Double.Parse(cSquared.ToString()));
            
            return c;
        }

        public RUIOutput ProcessRUIOutput(string fileLoc)
        {
            //return
            RUIOutput output = new RUIOutput();

            if (true)
            {
                double distanceTraveled = 0;
                int keyStrokes = 0;
                int rightMouseClicks = 0;
                int leftMouseClicks = 0;

                StreamReader reader = new StreamReader(fileLoc);
                string buf;

                string xpart, ypart, action;
                string extractTime;
                int startX = -1;
                int startY = -1;

                int endX;
                int endY;
                Point pt = Cursor.Position;
                string delimStr = "\t";
                char[] delimiter = delimStr.ToCharArray();
                string[] parts;

                //variable to hold task breakdown
                Tasks.TaskBreakdown currentTaskBreakDown = new Tasks.TaskBreakdown();
                Task currentTask = new Task();

                //variable to store previous time
                string previousTime = null;
                //variable to store total time
                double totalTimeMilliSec = 0;

                long sleeptime;
                buf = reader.ReadLine();
                buf = reader.ReadLine();
                buf = reader.ReadLine();
                buf = reader.ReadLine();
                int turn = 0;
                try
                {
                    do
                    {
                        buf = reader.ReadLine();

                        if (buf != "")
                        {
                            parts = buf.Split(delimiter);
                            action = parts[1];
                            //get the time
                            string currentTime = parts[0];

                            if (currentTime != null)
                            {
                                if (previousTime == null || previousTime == " " || previousTime == "")
                                {
                                    //do nothing since this is starting time
                                    previousTime = currentTime;
                                }
                                //this is task switch if currentTime is null
                                else if (currentTime == null || currentTime == " " || currentTime == "")
                                {
                                    //set previous time to null so will not record time between task switching
                                    previousTime = null;
                                }
                                else
                                {
                                    //find length between time
                                    double elapsedTime = this.getElapsedTime(previousTime, currentTime);

                                    totalTimeMilliSec += elapsedTime;

                                    //update previos time
                                    previousTime = currentTime;

                                    //add time to task if needed
                                    if (currentTask != null)
                                    {
                                        if (currentTask.OutputStats == null)
                                        {
                                            currentTask.OutputStats = new RUIOutput();
                                        }

                                        currentTask.OutputStats.TotalTimeMilliSeconds += elapsedTime;
                                    }
                                }
                            }

                            if (action == "Moved")
                            {
                                xpart = parts[2];
                                ypart = parts[3];

                                if (startX == -1 && startY == -1)
                                {
                                    startX = System.Convert.ToInt32(xpart);
                                    startY = System.Convert.ToInt32(ypart);
                                }
                                else
                                {
                                    endX = System.Convert.ToInt32(xpart);
                                    endY = System.Convert.ToInt32(ypart);

                                    double mouseMoveLenght;

                                    mouseMoveLenght = this.GetDistanceBetweenPoints(startX, startY, endX, endY);

                                    distanceTraveled += Math.Round(mouseMoveLenght);                                    

                                    startX = endX;
                                    startY = endY;

                                    if (currentTask != null)
                                    {
                                        if (currentTask.OutputStats == null)
                                        {
                                            currentTask.OutputStats = new RUIOutput();
                                        }

                                        currentTask.OutputStats.DistanceTraveled += Math.Round(mouseMoveLenght);// distanceTraveled;
                                    }
                                }

                                /*
                                xpart = parts[2];
                                ypart = parts[3];

                                turn = turn + 1;
                                extractTime = parts[0];
                                x = System.Convert.ToInt32(xpart);
                                y = System.Convert.ToInt32(ypart);
                                pt.X = x;
                                pt.Y = y;
                                Cursor.Position = pt;
                                sleeptime = GetSleepTime(extractTime, turn);
                                if (radioButton2.Checked)
                                    Thread.Sleep(System.Convert.ToInt32(sleeptime));
                                else if (radioButton1.Checked)
                                    Thread.Sleep(System.Convert.ToInt32(sleeptime * 2));
                                else if (radioButton3.Checked)
                                    Thread.Sleep(System.Convert.ToInt32(sleeptime * 0.5));
                                */
                            }
                            else if (action == "Pressed")
                            {
                                xpart = parts[2];

                                if (xpart == "Left")
                                {
                                    leftMouseClicks++;

                                    if (currentTask != null)
                                    {
                                        if (currentTask.OutputStats == null)
                                        {
                                            currentTask.OutputStats = new RUIOutput();
                                        }

                                        currentTask.OutputStats.LeftMouseClicks++;
                                    }
                                }
                                else if (xpart == "Right")
                                {
                                    rightMouseClicks++;

                                    if (currentTask != null)
                                    {
                                        if (currentTask.OutputStats == null)
                                        {
                                            currentTask.OutputStats = new RUIOutput();
                                        }

                                        currentTask.OutputStats.RightMouseClicks++;
                                    }
                                }

                            }
                            else if (action == "Key")
                            {
                                keyStrokes++;

                                if (currentTask != null)
                                {
                                    if (currentTask.OutputStats == null)
                                    {
                                        currentTask.OutputStats = new RUIOutput();
                                    }

                                    currentTask.OutputStats.KeyStrokes++;
                                }
                            }
                            else if (action == "TaskBreakdown")
                            {
                                //get task breakdown used in this log
                                String taskBreakdown = parts[3];

                                BreakdownStorage bs = BreakdownStorage.Instance;

                                Tasks.TaskBreakdown tbd = bs.getBreakdown(taskBreakdown);

                                if (tbd != null)
                                {
                                    this.clearTaskStats(tbd.Task);
                                    currentTaskBreakDown = tbd;
                                    //output.TaskBreakdown = tbd;
                                }
                            }
                            else if (action == "Task")
                            {
                                String taskName = parts[3];

                                //get task from task breakdown
                                currentTask = this.getTaskInBreakdown(currentTaskBreakDown.Task, taskName);                                
                            }
                        }
                    }

                    while (reader.Peek() != -1);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message);
                }
                finally
                {
                    reader.Close();
                }

                output.KeyStrokes = keyStrokes;
                output.DistanceTraveled = distanceTraveled;
                output.RightMouseClicks = rightMouseClicks;
                output.LeftMouseClicks = leftMouseClicks;
                output.TaskBreakdown = currentTaskBreakDown;
                output.TotalTimeMilliSeconds = totalTimeMilliSec;
            }
            else
            {
                MessageBox.Show("Please choose file location first.");
            }

            return output;
        }

        private double getElapsedTime(string startTime, string endTime)
        {
            //try getting in absolute format
            try
            {
                TimeSpan span = DateTime.Parse(endTime) - DateTime.Parse(startTime);

                return span.TotalMilliseconds;
            }
            catch (Exception ex)
            {
                
            }

            //if not returned, then in relative format
            
            int hours, min, sec, milli;
            long startMilliseconds, endMilliseconds;
            hours = System.Convert.ToInt32(startTime.Substring(0,2));
            min = System.Convert.ToInt32(startTime.Substring(3,2));
            sec = System.Convert.ToInt32(startTime.Substring(6,2));
            milli = System.Convert.ToInt32(startTime.Substring(9));
            startMilliseconds = milli + (sec * 1000) + (min * 60 * 1000) + (hours * 3600 * 1000);

            hours = System.Convert.ToInt32(endTime.Substring(0,2));
            min = System.Convert.ToInt32(endTime.Substring(3,2));
            sec = System.Convert.ToInt32(endTime.Substring(6,2));
            milli = System.Convert.ToInt32(endTime.Substring(9));
            endMilliseconds = milli + (sec * 1000) + (min * 60 * 1000) + (hours * 3600 * 1000);

            return endMilliseconds - startMilliseconds;
            
        }

        private Task getTaskInBreakdown(Task[] tasks, String name)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                //see if this is current task
                if (tasks[i].Name == name)
                {
                    return tasks[i];
                }
                //look through sub tasks
                if (tasks[i].Task1 != null)
                {
                    Task subTask = this.getTaskInBreakdown(tasks[i].Task1, name);

                    if (subTask != null)
                    {
                        return subTask;
                    }
                }
            }

            return null;
        }

        private void clearTaskStats(Task[] tasks)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i].OutputStats = null;

                //look through sub tasks
                if (tasks[i].Task1 != null)
                {
                    clearTaskStats(tasks[i].Task1);
                }
            }            
        }
    }
}
