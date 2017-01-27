using System;
using System.Collections.Generic;
using System.Text;

namespace RUI.Output
{
    interface IRUILogger
    {
        void LogKeyStroke(DateTime time, String key, String modifier);

        void LogMousePosition(DateTime time, int x, int y);

        void LogMouseClick(DateTime time, String mouseInput, MouseInputType inputType, int x, int y);

        void StopLogging();

        void LogTaskBreakDown(String taskBreakdown);

        void LogTaskSwitch(String newTask);
    }
}
