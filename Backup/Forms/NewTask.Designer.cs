namespace RUI.Forms
{
    partial class NewTask
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
            this.label1 = new System.Windows.Forms.Label();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.createTaskButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Name:";
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.Location = new System.Drawing.Point(105, 12);
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(253, 22);
            this.taskNameTextBox.TabIndex = 1;
            this.taskNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taskNameTextBox_KeyDown);
            // 
            // createTaskButton
            // 
            this.createTaskButton.Location = new System.Drawing.Point(52, 49);
            this.createTaskButton.Name = "createTaskButton";
            this.createTaskButton.Size = new System.Drawing.Size(127, 31);
            this.createTaskButton.TabIndex = 2;
            this.createTaskButton.Text = "Create Task";
            this.createTaskButton.UseVisualStyleBackColor = true;
            this.createTaskButton.Click += new System.EventHandler(this.createTaskButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(196, 49);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 31);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 96);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createTaskButton);
            this.Controls.Add(this.taskNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "NewTask";
            this.Text = "NewTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox taskNameTextBox;
        private System.Windows.Forms.Button createTaskButton;
        private System.Windows.Forms.Button cancelButton;
    }
}