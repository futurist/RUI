using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RUI.Forms
{
    public partial class NewTask : Form
    {
        string taskName;

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        public NewTask()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Constructor to edit task.
        /// </summary>
        /// <param name="taskName"></param>
        public NewTask(string taskName)
        {
            InitializeComponent();
            this.taskNameTextBox.Text = taskName;
            this.createTaskButton.Text = "Edit Task";
        }

        private void createTaskButton_Click(object sender, EventArgs e)
        {
            this.taskName = taskNameTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void taskNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.taskName = taskNameTextBox.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    e.Handled = true;
                    break;
            }

        }
    }
}
