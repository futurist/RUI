namespace RUI.Forms
{
    partial class TaskBreakdownForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.editTaskButton = new System.Windows.Forms.Button();
            this.deleteButtonTask = new System.Windows.Forms.Button();
            this.saveTaskBreakdown = new System.Windows.Forms.Button();
            this.selectTaskButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.breakdownNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // taskTreeView
            // 
            this.taskTreeView.Location = new System.Drawing.Point(9, 28);
            this.taskTreeView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.taskTreeView.Name = "taskTreeView";
            this.taskTreeView.Size = new System.Drawing.Size(279, 273);
            this.taskTreeView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task Breakdown";
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(13, 341);
            this.addTaskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(85, 27);
            this.addTaskButton.TabIndex = 2;
            this.addTaskButton.Text = "Add";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // editTaskButton
            // 
            this.editTaskButton.Location = new System.Drawing.Point(102, 341);
            this.editTaskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.editTaskButton.Name = "editTaskButton";
            this.editTaskButton.Size = new System.Drawing.Size(92, 27);
            this.editTaskButton.TabIndex = 3;
            this.editTaskButton.Text = "Edit";
            this.editTaskButton.UseVisualStyleBackColor = true;
            this.editTaskButton.Click += new System.EventHandler(this.editTaskButton_Click);
            // 
            // deleteButtonTask
            // 
            this.deleteButtonTask.Location = new System.Drawing.Point(198, 341);
            this.deleteButtonTask.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteButtonTask.Name = "deleteButtonTask";
            this.deleteButtonTask.Size = new System.Drawing.Size(86, 27);
            this.deleteButtonTask.TabIndex = 4;
            this.deleteButtonTask.Text = "Delete";
            this.deleteButtonTask.UseVisualStyleBackColor = true;
            this.deleteButtonTask.Click += new System.EventHandler(this.deleteButtonTask_Click);
            // 
            // saveTaskBreakdown
            // 
            this.saveTaskBreakdown.Location = new System.Drawing.Point(38, 373);
            this.saveTaskBreakdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveTaskBreakdown.Name = "saveTaskBreakdown";
            this.saveTaskBreakdown.Size = new System.Drawing.Size(105, 27);
            this.saveTaskBreakdown.TabIndex = 5;
            this.saveTaskBreakdown.Text = "Save and Close";
            this.saveTaskBreakdown.UseVisualStyleBackColor = true;
            this.saveTaskBreakdown.Click += new System.EventHandler(this.saveTaskBreakdown_Click);
            // 
            // selectTaskButton
            // 
            this.selectTaskButton.Location = new System.Drawing.Point(156, 373);
            this.selectTaskButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectTaskButton.Name = "selectTaskButton";
            this.selectTaskButton.Size = new System.Drawing.Size(98, 27);
            this.selectTaskButton.TabIndex = 6;
            this.selectTaskButton.Text = "Select and Close";
            this.selectTaskButton.UseVisualStyleBackColor = true;
            this.selectTaskButton.Click += new System.EventHandler(this.selectTaskButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 314);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Name: ";
            // 
            // breakdownNameTextBox
            // 
            this.breakdownNameTextBox.Location = new System.Drawing.Point(58, 311);
            this.breakdownNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.breakdownNameTextBox.Name = "breakdownNameTextBox";
            this.breakdownNameTextBox.Size = new System.Drawing.Size(225, 20);
            this.breakdownNameTextBox.TabIndex = 8;
            // 
            // TaskBreakdownForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 413);
            this.Controls.Add(this.breakdownNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectTaskButton);
            this.Controls.Add(this.saveTaskBreakdown);
            this.Controls.Add(this.deleteButtonTask);
            this.Controls.Add(this.editTaskButton);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taskTreeView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TaskBreakdownForm";
            this.Text = "TaskBreakdown";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView taskTreeView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Button editTaskButton;
        private System.Windows.Forms.Button deleteButtonTask;
        private System.Windows.Forms.Button saveTaskBreakdown;
        private System.Windows.Forms.Button selectTaskButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox breakdownNameTextBox;
    }
}