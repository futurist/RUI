using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RUI.Tasks;

namespace RUI.Forms
{
    public partial class TaskBreakdownForm : Form
    {
        private TaskBreakdown taskBreakdown;
        private bool edit = false;
        private string selectedTask;

        public string SelectedTask
        {
            get { return selectedTask; }
            set { selectedTask = value; }
        }

        public TaskBreakdownForm(bool runTime)
        {
            InitializeComponent();

            if (runTime == true)
            {

            }
            else
            {
                this.selectTaskButton.Visible = false;
            }
        }

        public TaskBreakdownForm(bool runTime, TaskBreakdown editBreakdown)
        {
            InitializeComponent();

            if (runTime == true)
            {

            }
            else
            {
                this.selectTaskButton.Visible = false;
            }

            this.taskBreakdown = editBreakdown;

            this.edit = true;

            this.breakdownNameTextBox.Enabled = false;

            this.buildTaskTree(editBreakdown);
        }

        private void buildTaskTree(TaskBreakdown breakdown)
        {
            this.breakdownNameTextBox.Text = breakdown.Name;

            if (breakdown.Task != null)
            {
                for (int i = 0; i < breakdown.Task.Length; i++)
                {
                    this.createTreeNode(breakdown.Task[i], null);
                }
            }
        }

        public TaskBreakdown TaskBreakdown
        {
            get { return taskBreakdown; }
            set { taskBreakdown = value; }
        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            NewTask task = new NewTask();
            task.ShowDialog();

            if (task.DialogResult == DialogResult.OK)
            {
                string newTask = task.TaskName;

                if (taskTreeView.SelectedNode != null)
                {
                    taskTreeView.SelectedNode.Nodes.Add(newTask);
                    taskTreeView.SelectedNode.Expand();
                }
                else
                {
                    taskTreeView.Nodes.Add(newTask);
                }
            }
        }

        private void editTaskButton_Click(object sender, EventArgs e)
        {
            if (taskTreeView.SelectedNode == null)
            {
                MessageBox.Show("No task selected!");
            }
            else
            {
                TreeNode selectedNode = taskTreeView.SelectedNode;


                NewTask editTask = new NewTask(selectedNode.Text);              
                editTask.ShowDialog();               

                if (editTask.DialogResult == DialogResult.OK)
                {
                    string newTask = editTask.TaskName;

                    selectedNode.Text = newTask;
                }
            }
        }

        private void deleteButtonTask_Click(object sender, EventArgs e)
        {
            if (taskTreeView.SelectedNode == null)
            {
                MessageBox.Show("No task selected!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    taskTreeView.SelectedNode.Remove();
                }
            }
        }

        private void saveTaskBreakdown_Click(object sender, EventArgs e)
        {
            try
            {
                BreakdownStorage bs = BreakdownStorage.Instance;

                if (edit == true)
                {
                    this.UpdateTaskBreakdown();

                    this.Close();
                }
                else
                {
                    if (breakdownNameTextBox.Text == "")
                    {
                        MessageBox.Show("Please create a name before saving.");
                    }
                    else if (bs.nameExists(breakdownNameTextBox.Text))
                    {
                        MessageBox.Show("Name already exists, please choose a new name.");
                    }
                    else
                    {
                        this.SaveTaskBreakdown();

                        this.DialogResult = DialogResult.OK;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving task breakdown: " + ex.Message);
            }
        }

        private void UpdateTaskBreakdown()
        {
            TaskBreakdown tb = new TaskBreakdown();
            tb.Name = breakdownNameTextBox.Text;

            TreeNodeCollection topLevelNodes = taskTreeView.Nodes;

            List<Task> taskList = new List<Task>();

            for (int i = 0; i < topLevelNodes.Count; i++)
            {
                taskList.Add(createTaskNode(topLevelNodes[i]));
            }

            tb.Task = taskList.ToArray();

            this.taskBreakdown = tb;

            BreakdownStorage bs = BreakdownStorage.Instance;
            bs.updateTaskBreakdown(tb);
        }

        private void SaveTaskBreakdown()
        {
            TaskBreakdown tb = new TaskBreakdown();
            tb.Name = breakdownNameTextBox.Text;

            TreeNodeCollection topLevelNodes = taskTreeView.Nodes;

            List<Task> taskList = new List<Task>();

            for (int i = 0; i < topLevelNodes.Count; i++)
            {
                taskList.Add(createTaskNode(topLevelNodes[i]));
            }

            tb.Task = taskList.ToArray();

            this.taskBreakdown = tb;

            BreakdownStorage bs = BreakdownStorage.Instance;
            bs.addTaskBreakdown(tb);

        }

        private Task createTaskNode(TreeNode node)
        {
            Task newTask = new Task();
            newTask.Name = node.Text;

            TreeNodeCollection taskNodes = node.Nodes;

            List<Task> taskList = new List<Task>();

            for (int i = 0; i < taskNodes.Count; i++)
            {
                taskList.Add(createTaskNode(taskNodes[i]));
            }

            newTask.Task1 = taskList.ToArray();

            return newTask;            
        }

        private void createTreeNode(Task task, TreeNode treeNode)
        {
            if (treeNode == null)
            {
                TreeNode newNode = this.taskTreeView.Nodes.Add(task.Name);

                if (task.Task1 != null)
                {
                    for (int i = 0; i < task.Task1.Length; i++)
                    {
                        this.createTreeNode(task.Task1[i], newNode);
                        newNode.Expand();
                    }
                }
            }
            else
            {
                TreeNode newNode = treeNode.Nodes.Add(task.Name);

                if (task.Task1 != null)
                {
                    for (int i = 0; i < task.Task1.Length; i++)
                    {
                        this.createTreeNode(task.Task1[i], newNode);
                        newNode.Expand();
                    }
                }
            }
        }

        private void selectTaskButton_Click(object sender, EventArgs e)
        {
            if (taskTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a task first.");
            }
            else
            {
                this.SelectedTask = taskTreeView.SelectedNode.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
