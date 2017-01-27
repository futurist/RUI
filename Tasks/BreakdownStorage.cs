using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RUI.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace RUI.Tasks
{
    class BreakdownStorage
    {
        private static BreakdownStorage storageInstance = null;
        static readonly object padlock = new object();
        TaskBreakdowns breakdowns = new TaskBreakdowns();

        public TaskBreakdowns Breakdowns
        {
            get { return breakdowns; }
            set { breakdowns = value; }
        }

        private BreakdownStorage()
        {
            //load breakdowns
            FileInfo fi = new FileInfo(Application.StartupPath + "\\TaskBreakdowns.xml");

            if (fi.Exists)
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\TaskBreakdowns.xml", FileMode.Open);
                XmlSerializer s = new XmlSerializer(typeof(TaskBreakdowns));
                breakdowns = (TaskBreakdowns)s.Deserialize(fs);

                fs.Close();
            }
        }

        public static BreakdownStorage Instance
        {
            get
            {
                lock (padlock)
                {
                    if (storageInstance == null)
                    {
                        storageInstance = new BreakdownStorage();
                    }
                    return storageInstance;
                }
            }
        }

        private void saveTaskBreakdown()
        {
            //load breakdowns
            FileInfo fi = new FileInfo(Application.StartupPath + "\\TaskBreakdowns.xml");
            
            if (fi.Exists)
            {
                //FileStream fs = new FileStream("\\TaskBreakdowns.xml", FileMode.Open);
                XmlSerializer s = new XmlSerializer(typeof(TaskBreakdowns));

                FileStream return_stream = File.Create(Application.StartupPath + "\\TaskBreakdowns.xml");
                //TextWriter xw = new XmlTextWriter("\\TaskBreakdowns.xml", Encoding.ASCII);

                s.Serialize(return_stream, breakdowns);
                return_stream.Close();

                //fs.Close();
            }

        }

        public void deleteTaskBreakdown(string name)
        {
            //delete the task breakdown with the specified name
            for (int i = 0; i < breakdowns.TaskBreakdownField.Count; i++)
            {
                if (breakdowns.TaskBreakdownField[i].Name == name)
                {
                    //delete this breakdown
                    breakdowns.TaskBreakdownField.Remove(breakdowns.TaskBreakdownField[i]);
                }
            }

            this.saveTaskBreakdown();
        }

        public void updateTaskBreakdown(TaskBreakdown tb)
        {           
            for (int i = 0; i < Breakdowns.TaskBreakdownField.Count; i++)
            {
                if (Breakdowns.TaskBreakdownField[i].Name == tb.Name)
                {
                    //update existing to new
                    Breakdowns.TaskBreakdownField[i] = tb;
                }
            }                            

            saveTaskBreakdown();
        }

        public void addTaskBreakdown(TaskBreakdown tb)
        {        
            /*                      
                List<RUI.Tasks.TaskBreakdown> bdList = new List<RUI.Tasks.TaskBreakdown>();

                if (Breakdowns.TaskBreakdownField != null)
                {
                    for (int i = 0; i < Breakdowns.TaskBreakdownField.Count; i++)
                    {
                        bdList.Add(Breakdowns.TaskBreakdownField[i]);
                    }
                }

                bdList.Add(tb);

                this.Breakdowns.TaskBreakdownField = bdList;//.ToArray();            
            */
                this.Breakdowns.TaskBreakdownField.Add(tb);

                saveTaskBreakdown();
        }

        public bool nameExists(string name){
            for (int i = 0; i < breakdowns.TaskBreakdownField.Count; i++)
            {
                if (breakdowns.TaskBreakdownField[i].Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public TaskBreakdown getBreakdown(string name)
        {
            for (int i = 0; i < breakdowns.TaskBreakdownField.Count; i++)
            {
                if (breakdowns.TaskBreakdownField[i].Name == name)
                {
                    return breakdowns.TaskBreakdownField[i];
                }
            }

            return null;
        }
    }
}
