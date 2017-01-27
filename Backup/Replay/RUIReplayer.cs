using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RUI.Replay
{
    class RUIReplayer
    {
        private Thread replayThread;
        private bool continueReplay = true;
        private string replayFile;

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        [DllImport("User32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, IntPtr dwExtraInfo);

        private const UInt32 MouseEventLeftDown = 0x0002;
        private const UInt32 MouseEventLeftUp = 0x0004;
        private const UInt32 MouseEventRightDown = 0x0008;
        private const UInt32 MouseEventRightUp = 0x0010;

        private double sleepTimeMod;

        public RUIReplayer(String replayFileName, double sleepTimeModifier)
        {
            this.replayFile = replayFileName;
            this.sleepTimeMod = sleepTimeModifier;
        }

        public void Stop()
        {
            continueReplay = false;
            Thread.Sleep(50);
            //replayThread.Abort();
        }

        public void Run()
        {
            continueReplay = true;
            replayThread = new Thread(new ThreadStart(Replay));
            replayThread.Start();
        } 


        public void Replay()
        {
            StreamReader reader = new StreamReader(replayFile);
            string buf;

            string xpart, ypart, action;
            string extractTime;
            int x;
            int y;
            Point pt = Cursor.Position;
            string delimStr = "\t";
            char[] limiter = delimStr.ToCharArray();
            string[] parts;

            long sleeptime;
            buf = reader.ReadLine();
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

                    if (buf != null && buf != "")
                    {
                        parts = buf.Split(limiter);
                        action = parts[1];

                        extractTime = parts[0];
                        sleeptime = GetSleepTime(extractTime, turn);

                        if (sleepTimeMod == 0)
                            Thread.Sleep(System.Convert.ToInt32(sleeptime));
                        else if (sleepTimeMod == 2)
                            Thread.Sleep(System.Convert.ToInt32(sleeptime * 2));
                        else if (sleepTimeMod == 0.5)
                            Thread.Sleep(System.Convert.ToInt32(sleeptime * 0.5));

                        if (action == "Moved")
                        {
                            xpart = parts[2];
                            ypart = parts[3];

                            turn = turn + 1;
                            //extractTime = parts[0];
                            x = System.Convert.ToInt32(xpart);
                            y = System.Convert.ToInt32(ypart);
                            pt.X = x;
                            pt.Y = y;
                            Cursor.Position = pt;
                        }
                        else
                            if (action == "Pressed")
                            {
                                xpart = parts[2];

                                if (xpart == "Left")
                                {
                                    mouse_event(MouseEventLeftDown, 0, 0, 0, new System.IntPtr());
                                    mouse_event(MouseEventLeftUp, 0, 0, 0, new System.IntPtr());

                                }
                                else if (xpart == "Right")
                                {
                                    mouse_event(MouseEventRightDown, 0, 0, 0, new System.IntPtr());
                                    mouse_event(MouseEventRightUp, 0, 0, 0, new System.IntPtr());
                                }

                            }
                            else if (action == "Key")
                            {
                                String lkey;
                                lkey = parts[2];

                                byte alfa;
                                alfa = GetAscii(lkey);
                                if (alfa != 0)
                                {
                                    keybd_event(alfa, 0, 0, new System.IntPtr());
                                }
                            }
                    }
                }
                while (reader.Peek() != -1 && continueReplay);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error replaying: " + ex);
            }

            finally
            {
                reader.Close();
            }
        }

        public long GetSleepTime(string extractTime, int turn)
        {
            int hours, min, sec, milli;
            long totalMilliseconds;
            long sleepTime = 0;

            //try relative
            try
            {
                hours = System.Convert.ToInt32(extractTime.Substring(0, 2));
                min = System.Convert.ToInt32(extractTime.Substring(3, 2));
                sec = System.Convert.ToInt32(extractTime.Substring(6, 2));
                milli = System.Convert.ToInt32(extractTime.Substring(9));
                totalMilliseconds = milli + (sec * 1000) + (min * 60 * 1000) + (hours * 3600 * 1000);

                sleepTime = 10;

                if (turn == 1) sleepTime = 0;
                else if (turn == 2) sleepTime = 10;
                else sleepTime = totalMilliseconds - globalvar.oldTime;

                globalvar.oldTime = totalMilliseconds;
            }
            catch (Exception ex)
            {

            }

            //try absolute
            try
            {
                hours = System.Convert.ToInt32(extractTime.Substring(11, 2));
                min = System.Convert.ToInt32(extractTime.Substring(14, 2));
                sec = System.Convert.ToInt32(extractTime.Substring(17, 2));
                milli = System.Convert.ToInt32(extractTime.Substring(20));
                totalMilliseconds = milli + (sec * 1000) + (min * 60 * 1000) + (hours * 3600 * 1000);

                sleepTime = 10;

                if (turn == 1) sleepTime = 0;
                else if (turn == 2) sleepTime = 10;
                else sleepTime = totalMilliseconds - globalvar.oldTime;


                globalvar.oldTime = totalMilliseconds;
            }
            catch (Exception ex)
            {

            }

            return (sleepTime);
        }

        public byte GetAscii(string keyValue)
        {
            Keys simKey = (Keys)Enum.Parse(typeof(Keys), keyValue);
            int keyInt = (int)simKey;

            return (byte)keyInt;

            /*
            string lower = letter.ToLower();
            
            if (lower == "space")
            {
                return (32);
            }
            else if (lower == "return")
            {
                return (13);
            }
            else if (lower == "oemcomma")
            {
                return (44);
            }
            else if (lower == "back")
            {
                return (8);
            }
            else if (lower == "oemperiod")
            {
                return (46);
            }

            switch (lower.Trim())
            {
                case "a" : return (65);
                case "b" : return (66);
                case "c" : return (67);
                case "d" : return (68);
                case "e" : return (69);
                case "f" : return (70);
                case "g" : return (71);
                case "h" : return (72);
                case "i" : return (73);
                case "j" : return (74);
                case "k" : return (75);
                case "l" : return (76);
                case "m" : return (77);
                case "n" : return (78);
                case "o" : return (79);
                case "p" : return (80);
                case "q" : return (81);
                case "r" : return (82);
                case "s" : return (83);
                case "t" : return (84);
                case "u" : return (85);
                case "v" : return (86);
                case "w" : return (87);
                case "x" : return (88);
                case "y" : return (89);
                case "z" : return (90);
                default: return 0;
            }
             */
        }

    }
}
