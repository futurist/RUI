using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RUI.NASATLX
{
    public partial class TLXForm : Form
    {
        public TLXForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String fileName = Application.StartupPath + "\\TLX_Assessments\\TLX Assesment " + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".txt";

                //save results to file
                StreamWriter sw = File.AppendText(fileName);

                sw.Write("Task Name:");
                sw.WriteLine(this.taskTextBox.Text);

                sw.Write("File Created: ");
                String fileCreationTime = DateTime.Now.ToString();
                sw.Write(fileCreationTime);
                sw.WriteLine(" ");
                sw.Write("Version: 2.02");
                sw.WriteLine(" ");
                sw.WriteLine("Released: 10/08/2008");
                sw.WriteLine(" ");
                sw.Write("Mental Demand: " + mentalDemandSlider.Value.ToString());
                sw.WriteLine(" ");
                sw.Write("Physical Demand: " + physicalDemandSlider.Value.ToString());
                sw.WriteLine(" ");
                sw.Write("Temperal Demand: " + temperallDemandSlider.Value.ToString());
                sw.WriteLine(" ");
                sw.Write("Performance: " + perfSlider.Value.ToString());
                sw.WriteLine(" ");
                sw.Write("Effort: " + effortSlider.Value.ToString());
                sw.WriteLine(" ");
                sw.Write("Frustration: " + frustrationSlider.Value.ToString());
                sw.WriteLine(" ");

                sw.AutoFlush = true;

                sw.Flush();
                sw.Close();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving assessment: " + ex.ToString());
            }
        }
    }
}