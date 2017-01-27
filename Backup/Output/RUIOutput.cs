using System;
using System.Collections.Generic;
using System.Text;
using RUI;
using RUI.Tasks;

namespace RUI.Output
{
    class RUIOutput
    {
        private int keyStrokes;
        private double distanceTraveled;
        private int rightMouseClicks;
        private int leftMouseClicks;
        private TaskBreakdown taskBreakdown;
        private double totalTimeMilliseconds;

        public double TotalTimeMilliSeconds
        {
            get { return totalTimeMilliseconds; }
            set { totalTimeMilliseconds = value; }
        }

        public TaskBreakdown TaskBreakdown
        {
            get { return taskBreakdown; }
            set { taskBreakdown = value; }
        }

        public int KeyStrokes
        {
            get { return keyStrokes; }
            set { keyStrokes = value; }
        }        

        public double DistanceTraveled
        {
            get { return distanceTraveled; }
            set { distanceTraveled = value; }
        }        

        public int RightMouseClicks
        {
            get { return rightMouseClicks; }
            set { rightMouseClicks = value; }
        }        

        public int LeftMouseClicks
        {
            get { return leftMouseClicks; }
            set { leftMouseClicks = value; }
        }
    }
}
