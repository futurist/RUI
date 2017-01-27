//Program to log and replay user Keystrokes and Mouse Actions//
//Urmila Kukreja//
//06/22/04//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Threading;
using System.Timers;
using System.Text;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using RUI.Tasks;
using RUI.Output;
using RUI.Listeners;
using RUI.Forms;
using RUI.Replay;
using RUI.NASATLX;

namespace RUI
{ 
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class RUI : System.Windows.Forms.Form
    {
        #region Variable Declarations

        bool quit = globalvar.quitting;
		private System.ComponentModel.IContainer components;
        private System.IO.StreamWriter sw;
        private System.Windows.Forms.Button replayButton;
		private System.Windows.Forms.Timer timer1;
		private string filename = " ";
        private string replay_file = " ";
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox replayFileTextBox;
		private System.Windows.Forms.Button browseReplayButton;
        private TabControl ruiTabControl;
        private TabPage replayTab;
        private TabPage recordTab;
        private CheckBox taskBreakdownCheckBox;
        private Label label1;
        private ListBox taskBreakdownListBox;
        private Button deleteBreakdownBtn;
        private Button editTaskButton;
        private Button addTaskButton;
        private TextBox fileLocTextBox;
        private Button startRecordingButton;
        private Button stopRecording;
        private Button createLog;
        private Label label3;
        private GroupBox groupBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox3;
        private TabPage processOutputTab;
        private GroupBox Statistics;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private TextBox rightMouseTextBox;
        private TextBox leftMouseTextBox;
        private TextBox mouseDistanceTextBox;
        private TextBox keyStrokesTextBox;
        private TextBox processLogFileTextBox;
        private Button processLogFileBrowse;
        private Label label4;
        private Label label10;
        private TreeView outputTaskTree;
        private TextBox statusTextBox;
        private Label label2;
        private GroupBox groupBox4;
        private RadioButton absoluteTimeRdBtn;
        private RadioButton relativeTimeRdBtn;
        private GroupBox groupBox3;
        private RadioButton excelOutputRdBtn;
        private RadioButton textOutputRdBtn;
        private TextBox timeTextBox;
        private Label label11;
        private TextBox replayStatusTxtBox;
        private Button stopReplayBtn;
        private Label label12;			

        private TaskBreakdowns taskBreakdowns;
        private string currentTaskBreakdown;

        private MouseListener mouseListener;
        private KeyListener keyListener;

        //variable to suspend logging when picking a task
        private bool suspendLogging = false;
        //logging class
        private IRUILogger logger;

        private bool continueReplay = true;
        KeyListener stopReplayKeyList;
        private Button nasaTlxBtn;

        private RUIReplayer replayProcessor;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public RUI()
		{
			InitializeComponent();
            //get all breakdowns
            this.refreshBreakdownList();           
		}

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
		{
            try
            {
                keyListener.Stop();
            }
            catch (Exception ex)
            {
            }
            try
            {
                stopReplayKeyList.Stop();
            }
            catch (Exception ex)
            {
            }
            try
            {
                mouseListener.Stop();
            }
            catch (Exception ex)
            {
            }
            try
            {
                replayProcessor.Stop();
            }
            catch (Exception ex)
            {
            }
           
            

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.replayButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.replayFileTextBox = new System.Windows.Forms.TextBox();
            this.browseReplayButton = new System.Windows.Forms.Button();
            this.ruiTabControl = new System.Windows.Forms.TabControl();
            this.recordTab = new System.Windows.Forms.TabPage();
            this.nasaTlxBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.absoluteTimeRdBtn = new System.Windows.Forms.RadioButton();
            this.relativeTimeRdBtn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.excelOutputRdBtn = new System.Windows.Forms.RadioButton();
            this.textOutputRdBtn = new System.Windows.Forms.RadioButton();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.taskBreakdownCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.taskBreakdownListBox = new System.Windows.Forms.ListBox();
            this.deleteBreakdownBtn = new System.Windows.Forms.Button();
            this.editTaskButton = new System.Windows.Forms.Button();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.fileLocTextBox = new System.Windows.Forms.TextBox();
            this.startRecordingButton = new System.Windows.Forms.Button();
            this.stopRecording = new System.Windows.Forms.Button();
            this.createLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.replayTab = new System.Windows.Forms.TabPage();
            this.stopReplayBtn = new System.Windows.Forms.Button();
            this.replayStatusTxtBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.processOutputTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.outputTaskTree = new System.Windows.Forms.TreeView();
            this.Statistics = new System.Windows.Forms.GroupBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rightMouseTextBox = new System.Windows.Forms.TextBox();
            this.leftMouseTextBox = new System.Windows.Forms.TextBox();
            this.mouseDistanceTextBox = new System.Windows.Forms.TextBox();
            this.keyStrokesTextBox = new System.Windows.Forms.TextBox();
            this.processLogFileTextBox = new System.Windows.Forms.TextBox();
            this.processLogFileBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.ruiTabControl.SuspendLayout();
            this.recordTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.replayTab.SuspendLayout();
            this.processOutputTab.SuspendLayout();
            this.Statistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // replayButton
            // 
            this.replayButton.BackColor = System.Drawing.Color.LightGray;
            this.replayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayButton.ForeColor = System.Drawing.Color.Black;
            this.replayButton.Location = new System.Drawing.Point(152, 81);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(230, 44);
            this.replayButton.TabIndex = 12;
            this.replayButton.Text = "Start Replay";
            this.replayButton.UseVisualStyleBackColor = false;
            this.replayButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 96);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replay Speed";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(8, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "2 X";
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(104, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Original";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "0.5 X";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Replay File:";
            // 
            // replayFileTextBox
            // 
            this.replayFileTextBox.BackColor = System.Drawing.Color.White;
            this.replayFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replayFileTextBox.Location = new System.Drawing.Point(10, 36);
            this.replayFileTextBox.Name = "replayFileTextBox";
            this.replayFileTextBox.Size = new System.Drawing.Size(248, 20);
            this.replayFileTextBox.TabIndex = 24;
            // 
            // browseReplayButton
            // 
            this.browseReplayButton.BackColor = System.Drawing.Color.LightGray;
            this.browseReplayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseReplayButton.Location = new System.Drawing.Point(273, 33);
            this.browseReplayButton.Name = "browseReplayButton";
            this.browseReplayButton.Size = new System.Drawing.Size(92, 24);
            this.browseReplayButton.TabIndex = 25;
            this.browseReplayButton.Text = "Browse";
            this.browseReplayButton.UseVisualStyleBackColor = false;
            this.browseReplayButton.Click += new System.EventHandler(this.replayFileLocButton);
            // 
            // ruiTabControl
            // 
            this.ruiTabControl.Controls.Add(this.recordTab);
            this.ruiTabControl.Controls.Add(this.replayTab);
            this.ruiTabControl.Controls.Add(this.processOutputTab);
            this.ruiTabControl.Location = new System.Drawing.Point(4, 4);
            this.ruiTabControl.Name = "ruiTabControl";
            this.ruiTabControl.SelectedIndex = 0;
            this.ruiTabControl.Size = new System.Drawing.Size(431, 437);
            this.ruiTabControl.TabIndex = 26;
            // 
            // recordTab
            // 
            this.recordTab.Controls.Add(this.nasaTlxBtn);
            this.recordTab.Controls.Add(this.groupBox4);
            this.recordTab.Controls.Add(this.groupBox3);
            this.recordTab.Controls.Add(this.statusTextBox);
            this.recordTab.Controls.Add(this.label2);
            this.recordTab.Controls.Add(this.taskBreakdownCheckBox);
            this.recordTab.Controls.Add(this.label1);
            this.recordTab.Controls.Add(this.taskBreakdownListBox);
            this.recordTab.Controls.Add(this.deleteBreakdownBtn);
            this.recordTab.Controls.Add(this.editTaskButton);
            this.recordTab.Controls.Add(this.addTaskButton);
            this.recordTab.Controls.Add(this.fileLocTextBox);
            this.recordTab.Controls.Add(this.startRecordingButton);
            this.recordTab.Controls.Add(this.stopRecording);
            this.recordTab.Controls.Add(this.createLog);
            this.recordTab.Controls.Add(this.label3);
            this.recordTab.Controls.Add(this.groupBox1);
            this.recordTab.Location = new System.Drawing.Point(4, 22);
            this.recordTab.Name = "recordTab";
            this.recordTab.Padding = new System.Windows.Forms.Padding(3);
            this.recordTab.Size = new System.Drawing.Size(423, 411);
            this.recordTab.TabIndex = 0;
            this.recordTab.Text = "Record";
            this.recordTab.UseVisualStyleBackColor = true;
            // 
            // nasaTlxBtn
            // 
            this.nasaTlxBtn.Location = new System.Drawing.Point(342, 183);
            this.nasaTlxBtn.Name = "nasaTlxBtn";
            this.nasaTlxBtn.Size = new System.Drawing.Size(67, 56);
            this.nasaTlxBtn.TabIndex = 26;
            this.nasaTlxBtn.Text = "NASA TLX";
            this.nasaTlxBtn.UseVisualStyleBackColor = true;
            this.nasaTlxBtn.Click += new System.EventHandler(this.nasaTlxBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.absoluteTimeRdBtn);
            this.groupBox4.Controls.Add(this.relativeTimeRdBtn);
            this.groupBox4.Location = new System.Drawing.Point(281, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 76);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time";
            // 
            // absoluteTimeRdBtn
            // 
            this.absoluteTimeRdBtn.AutoSize = true;
            this.absoluteTimeRdBtn.Location = new System.Drawing.Point(5, 41);
            this.absoluteTimeRdBtn.Name = "absoluteTimeRdBtn";
            this.absoluteTimeRdBtn.Size = new System.Drawing.Size(66, 17);
            this.absoluteTimeRdBtn.TabIndex = 1;
            this.absoluteTimeRdBtn.Text = "Absolute";
            this.absoluteTimeRdBtn.UseVisualStyleBackColor = true;
            // 
            // relativeTimeRdBtn
            // 
            this.relativeTimeRdBtn.AutoSize = true;
            this.relativeTimeRdBtn.Checked = true;
            this.relativeTimeRdBtn.Location = new System.Drawing.Point(5, 18);
            this.relativeTimeRdBtn.Name = "relativeTimeRdBtn";
            this.relativeTimeRdBtn.Size = new System.Drawing.Size(64, 17);
            this.relativeTimeRdBtn.TabIndex = 0;
            this.relativeTimeRdBtn.TabStop = true;
            this.relativeTimeRdBtn.Text = "Relative";
            this.relativeTimeRdBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.excelOutputRdBtn);
            this.groupBox3.Controls.Add(this.textOutputRdBtn);
            this.groupBox3.Location = new System.Drawing.Point(307, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(102, 62);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // excelOutputRdBtn
            // 
            this.excelOutputRdBtn.AutoSize = true;
            this.excelOutputRdBtn.Location = new System.Drawing.Point(6, 39);
            this.excelOutputRdBtn.Name = "excelOutputRdBtn";
            this.excelOutputRdBtn.Size = new System.Drawing.Size(51, 17);
            this.excelOutputRdBtn.TabIndex = 1;
            this.excelOutputRdBtn.Text = "Excel";
            this.excelOutputRdBtn.UseVisualStyleBackColor = true;
            this.excelOutputRdBtn.CheckedChanged += new System.EventHandler(this.excelOutputRdBtn_CheckedChanged);
            // 
            // textOutputRdBtn
            // 
            this.textOutputRdBtn.AutoSize = true;
            this.textOutputRdBtn.Checked = true;
            this.textOutputRdBtn.Location = new System.Drawing.Point(6, 19);
            this.textOutputRdBtn.Name = "textOutputRdBtn";
            this.textOutputRdBtn.Size = new System.Drawing.Size(46, 17);
            this.textOutputRdBtn.TabIndex = 0;
            this.textOutputRdBtn.TabStop = true;
            this.textOutputRdBtn.Text = "Text";
            this.textOutputRdBtn.UseVisualStyleBackColor = true;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextBox.ForeColor = System.Drawing.Color.Red;
            this.statusTextBox.Location = new System.Drawing.Point(80, 378);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(237, 23);
            this.statusTextBox.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Status:";
            // 
            // taskBreakdownCheckBox
            // 
            this.taskBreakdownCheckBox.AutoSize = true;
            this.taskBreakdownCheckBox.Location = new System.Drawing.Point(15, 289);
            this.taskBreakdownCheckBox.Name = "taskBreakdownCheckBox";
            this.taskBreakdownCheckBox.Size = new System.Drawing.Size(314, 17);
            this.taskBreakdownCheckBox.TabIndex = 21;
            this.taskBreakdownCheckBox.Text = "Use Selected Task Breakdown (Contorl + E to Switch Tasks)";
            this.taskBreakdownCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Task Breakdowns";
            // 
            // taskBreakdownListBox
            // 
            this.taskBreakdownListBox.FormattingEnabled = true;
            this.taskBreakdownListBox.Location = new System.Drawing.Point(14, 211);
            this.taskBreakdownListBox.Name = "taskBreakdownListBox";
            this.taskBreakdownListBox.Size = new System.Drawing.Size(202, 69);
            this.taskBreakdownListBox.TabIndex = 19;
            // 
            // deleteBreakdownBtn
            // 
            this.deleteBreakdownBtn.Location = new System.Drawing.Point(237, 244);
            this.deleteBreakdownBtn.Name = "deleteBreakdownBtn";
            this.deleteBreakdownBtn.Size = new System.Drawing.Size(80, 26);
            this.deleteBreakdownBtn.TabIndex = 18;
            this.deleteBreakdownBtn.Text = "Delete";
            this.deleteBreakdownBtn.UseVisualStyleBackColor = true;
            this.deleteBreakdownBtn.Click += new System.EventHandler(this.deleteBreakdownBtn_Click);
            // 
            // editTaskButton
            // 
            this.editTaskButton.Location = new System.Drawing.Point(237, 213);
            this.editTaskButton.Name = "editTaskButton";
            this.editTaskButton.Size = new System.Drawing.Size(80, 26);
            this.editTaskButton.TabIndex = 17;
            this.editTaskButton.Text = "Edit";
            this.editTaskButton.UseVisualStyleBackColor = true;
            this.editTaskButton.Click += new System.EventHandler(this.editTaskButton_Click);
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(237, 183);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(80, 25);
            this.addTaskButton.TabIndex = 16;
            this.addTaskButton.Text = "Add";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // fileLocTextBox
            // 
            this.fileLocTextBox.BackColor = System.Drawing.Color.White;
            this.fileLocTextBox.Location = new System.Drawing.Point(14, 39);
            this.fileLocTextBox.Name = "fileLocTextBox";
            this.fileLocTextBox.Size = new System.Drawing.Size(202, 20);
            this.fileLocTextBox.TabIndex = 5;
            // 
            // startRecordingButton
            // 
            this.startRecordingButton.BackColor = System.Drawing.Color.Transparent;
            this.startRecordingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startRecordingButton.Location = new System.Drawing.Point(14, 328);
            this.startRecordingButton.Name = "startRecordingButton";
            this.startRecordingButton.Size = new System.Drawing.Size(135, 38);
            this.startRecordingButton.TabIndex = 1;
            this.startRecordingButton.Text = "Start &Recording";
            this.startRecordingButton.UseVisualStyleBackColor = false;
            this.startRecordingButton.Click += new System.EventHandler(this.startRecordingButton_Click);
            // 
            // stopRecording
            // 
            this.stopRecording.BackColor = System.Drawing.Color.Transparent;
            this.stopRecording.Enabled = false;
            this.stopRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopRecording.Location = new System.Drawing.Point(172, 328);
            this.stopRecording.Name = "stopRecording";
            this.stopRecording.Size = new System.Drawing.Size(145, 38);
            this.stopRecording.TabIndex = 2;
            this.stopRecording.Text = "Stop Recording";
            this.stopRecording.UseVisualStyleBackColor = false;
            this.stopRecording.Click += new System.EventHandler(this.stopRecordingButton_Click);
            // 
            // createLog
            // 
            this.createLog.BackColor = System.Drawing.Color.Transparent;
            this.createLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createLog.Location = new System.Drawing.Point(228, 39);
            this.createLog.Name = "createLog";
            this.createLog.Size = new System.Drawing.Size(74, 24);
            this.createLog.TabIndex = 15;
            this.createLog.Text = "Browse";
            this.createLog.UseVisualStyleBackColor = false;
            this.createLog.Click += new System.EventHandler(this.browseFileLocButton);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log File Location:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(14, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 96);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record";
            // 
            // checkBox2
            // 
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.Black;
            this.checkBox2.Location = new System.Drawing.Point(13, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(116, 28);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "Mouse Clicks";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(13, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 27);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Key Strokes";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.Color.Black;
            this.checkBox3.Location = new System.Drawing.Point(127, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(125, 29);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "Mouse Moves";
            // 
            // replayTab
            // 
            this.replayTab.Controls.Add(this.stopReplayBtn);
            this.replayTab.Controls.Add(this.replayStatusTxtBox);
            this.replayTab.Controls.Add(this.label12);
            this.replayTab.Controls.Add(this.replayFileTextBox);
            this.replayTab.Controls.Add(this.browseReplayButton);
            this.replayTab.Controls.Add(this.replayButton);
            this.replayTab.Controls.Add(this.groupBox2);
            this.replayTab.Controls.Add(this.label5);
            this.replayTab.Location = new System.Drawing.Point(4, 22);
            this.replayTab.Name = "replayTab";
            this.replayTab.Padding = new System.Windows.Forms.Padding(3);
            this.replayTab.Size = new System.Drawing.Size(423, 411);
            this.replayTab.TabIndex = 1;
            this.replayTab.Text = "Replay";
            this.replayTab.UseVisualStyleBackColor = true;
            // 
            // stopReplayBtn
            // 
            this.stopReplayBtn.Location = new System.Drawing.Point(152, 131);
            this.stopReplayBtn.Name = "stopReplayBtn";
            this.stopReplayBtn.Size = new System.Drawing.Size(230, 39);
            this.stopReplayBtn.TabIndex = 29;
            this.stopReplayBtn.Text = "Stop Replay (Alt + S)";
            this.stopReplayBtn.UseVisualStyleBackColor = true;
            this.stopReplayBtn.Click += new System.EventHandler(this.stopReplayBtn_Click);
            // 
            // replayStatusTxtBox
            // 
            this.replayStatusTxtBox.ForeColor = System.Drawing.Color.Red;
            this.replayStatusTxtBox.Location = new System.Drawing.Point(66, 197);
            this.replayStatusTxtBox.Name = "replayStatusTxtBox";
            this.replayStatusTxtBox.Size = new System.Drawing.Size(316, 20);
            this.replayStatusTxtBox.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Status:";
            // 
            // processOutputTab
            // 
            this.processOutputTab.Controls.Add(this.label10);
            this.processOutputTab.Controls.Add(this.outputTaskTree);
            this.processOutputTab.Controls.Add(this.Statistics);
            this.processOutputTab.Controls.Add(this.processLogFileTextBox);
            this.processOutputTab.Controls.Add(this.processLogFileBrowse);
            this.processOutputTab.Controls.Add(this.label4);
            this.processOutputTab.Location = new System.Drawing.Point(4, 22);
            this.processOutputTab.Name = "processOutputTab";
            this.processOutputTab.Padding = new System.Windows.Forms.Padding(3);
            this.processOutputTab.Size = new System.Drawing.Size(423, 411);
            this.processOutputTab.TabIndex = 2;
            this.processOutputTab.Text = "Process Output";
            this.processOutputTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Task:";
            // 
            // outputTaskTree
            // 
            this.outputTaskTree.Location = new System.Drawing.Point(10, 91);
            this.outputTaskTree.Name = "outputTaskTree";
            this.outputTaskTree.Size = new System.Drawing.Size(203, 307);
            this.outputTaskTree.TabIndex = 20;
            this.outputTaskTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.outputTaskTree_AfterSelect);
            // 
            // Statistics
            // 
            this.Statistics.Controls.Add(this.timeTextBox);
            this.Statistics.Controls.Add(this.label11);
            this.Statistics.Controls.Add(this.label9);
            this.Statistics.Controls.Add(this.label8);
            this.Statistics.Controls.Add(this.label7);
            this.Statistics.Controls.Add(this.label6);
            this.Statistics.Controls.Add(this.rightMouseTextBox);
            this.Statistics.Controls.Add(this.leftMouseTextBox);
            this.Statistics.Controls.Add(this.mouseDistanceTextBox);
            this.Statistics.Controls.Add(this.keyStrokesTextBox);
            this.Statistics.Location = new System.Drawing.Point(218, 91);
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(193, 242);
            this.Statistics.TabIndex = 19;
            this.Statistics.TabStop = false;
            this.Statistics.Text = "Statistics";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(102, 190);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(75, 20);
            this.timeTextBox.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 36);
            this.label11.TabIndex = 24;
            this.label11.Text = "Time (Mins):";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 37);
            this.label9.TabIndex = 23;
            this.label9.Text = "Right Mouse Clicks:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 34);
            this.label8.TabIndex = 22;
            this.label8.Text = "Left Mouse Clicks:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 36);
            this.label7.TabIndex = 21;
            this.label7.Text = "Pixels:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Keystrokes:";
            // 
            // rightMouseTextBox
            // 
            this.rightMouseTextBox.Location = new System.Drawing.Point(102, 153);
            this.rightMouseTextBox.Name = "rightMouseTextBox";
            this.rightMouseTextBox.Size = new System.Drawing.Size(75, 20);
            this.rightMouseTextBox.TabIndex = 3;
            // 
            // leftMouseTextBox
            // 
            this.leftMouseTextBox.Location = new System.Drawing.Point(102, 117);
            this.leftMouseTextBox.Name = "leftMouseTextBox";
            this.leftMouseTextBox.Size = new System.Drawing.Size(75, 20);
            this.leftMouseTextBox.TabIndex = 2;
            // 
            // mouseDistanceTextBox
            // 
            this.mouseDistanceTextBox.Location = new System.Drawing.Point(102, 78);
            this.mouseDistanceTextBox.Name = "mouseDistanceTextBox";
            this.mouseDistanceTextBox.Size = new System.Drawing.Size(75, 20);
            this.mouseDistanceTextBox.TabIndex = 1;
            // 
            // keyStrokesTextBox
            // 
            this.keyStrokesTextBox.Location = new System.Drawing.Point(102, 40);
            this.keyStrokesTextBox.Name = "keyStrokesTextBox";
            this.keyStrokesTextBox.Size = new System.Drawing.Size(75, 20);
            this.keyStrokesTextBox.TabIndex = 0;
            // 
            // processLogFileTextBox
            // 
            this.processLogFileTextBox.BackColor = System.Drawing.Color.White;
            this.processLogFileTextBox.Location = new System.Drawing.Point(17, 38);
            this.processLogFileTextBox.Name = "processLogFileTextBox";
            this.processLogFileTextBox.Size = new System.Drawing.Size(270, 20);
            this.processLogFileTextBox.TabIndex = 16;
            // 
            // processLogFileBrowse
            // 
            this.processLogFileBrowse.BackColor = System.Drawing.Color.Transparent;
            this.processLogFileBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processLogFileBrowse.Location = new System.Drawing.Point(309, 35);
            this.processLogFileBrowse.Name = "processLogFileBrowse";
            this.processLogFileBrowse.Size = new System.Drawing.Size(110, 24);
            this.processLogFileBrowse.TabIndex = 18;
            this.processLogFileBrowse.Text = "Browse";
            this.processLogFileBrowse.UseVisualStyleBackColor = false;
            this.processLogFileBrowse.Click += new System.EventHandler(this.processLogFileBrowse_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Log File Location:";
            // 
            // RUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(442, 466);
            this.Controls.Add(this.ruiTabControl);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RUI";
            this.Text = "RUI 2.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.ruiTabControl.ResumeLayout(false);
            this.recordTab.ResumeLayout(false);
            this.recordTab.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.replayTab.ResumeLayout(false);
            this.replayTab.PerformLayout();
            this.processOutputTab.ResumeLayout(false);
            this.processOutputTab.PerformLayout();
            this.Statistics.ResumeLayout(false);
            this.Statistics.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 		
		{
			Application.Run(new RUI());
        }

        #region Input Processing Methods

        
        private void stopReplayKeyList_OnKeyPress(object sender, Listeners.KeyPressEventArgs e)
		{         
            if (e.ModifierKeys == Keys.Alt)
            {                   
                    char chr = new char();
                    chr = 'S';

                    if (Convert.ToChar(e.KeyCode).Equals(chr))
                    {
                        //continueReplay = false;
                        try
                        {
                            replayProcessor.Stop();
                        }
                        catch (Exception ex)
                        {
                        }
                        stopReplayKeyList.Stop();
                        this.replayStatusTxtBox.Text = "Replay stopped!";
                    }                                           
            }
        }

        private void KeyListener_KeyPress(object sender, Listeners.KeyPressEventArgs e)  //record key presses
		{
            //get time from KeyPressEventArgs
            DateTime now = e.CurrentTime;

            if (this.suspendLogging == true)
            {
            }
            else
            {                
                String b = "";

                if (e.ModifierKeys == Keys.Shift)
                {
                    if (((Keys)e.KeyCode).ToString().Equals("RShiftKey") || ((Keys)e.KeyCode).ToString().Equals("LShiftKey"))
                    {

                    }
                    else
                    {
                        logger.LogKeyStroke(now, ((Keys)e.KeyCode).ToString(), "Shift");
                    }
                }
                else if (e.ModifierKeys == Keys.Alt)
                {
                    String key = ((Keys)e.KeyCode).ToString();
                    if (key.Equals("LMenu") || key.Equals("RMenu"))
                    {

                    }
                    else
                    {
                        logger.LogKeyStroke(now, key, "Alt");
                    }
                }               
                else if (e.ModifierKeys == Keys.Control)
                {
                    //if trying to select task, open up task breakdown form
                    if (taskBreakdownCheckBox.Checked == true)
                    {
                        char chr = new char();
                        chr = 'E';

                        if (Convert.ToChar(e.KeyCode).Equals(chr))
                        {
                            BreakdownStorage bs = BreakdownStorage.Instance;
                            TaskBreakdown selectedBreakdown = bs.getBreakdown(this.currentTaskBreakdown);

                            //suspend logging
                            this.suspendLogging = true;

                            TaskBreakdownForm tbf = new TaskBreakdownForm(true, selectedBreakdown);

                            if (tbf.ShowDialog() == DialogResult.OK)
                            {
                                logger.LogTaskSwitch(tbf.SelectedTask);
                            }

                            //reactivate logging
                            this.suspendLogging = false;
                        }
                        else
                        {
                            String key = ((Keys)e.KeyCode).ToString();
                            if (key.Equals("LControlKey") || key.Equals("RControlKey"))
                            {

                            }
                            else
                            {
                                logger.LogKeyStroke(now, key, "Control");
                            }
                        }
                    }
                    else
                    {
                        String key = ((Keys)e.KeyCode).ToString();
                        if (key.Equals("LControlKey") || key.Equals("RControlKey"))
                        {

                        }
                        else
                        {
                            logger.LogKeyStroke(now, key, "Control");
                        }
                    }
                }
                else
                {
                    logger.LogKeyStroke(now, ((Keys)e.KeyCode).ToString(), null);
                }
            }
		} 

		private void InputListener_MouseButton(object sender, MouseButtonEventArgs e) //Records Mouse Clicks
		{
            DateTime now = DateTime.Now;

            if (this.suspendLogging == true)
            {

            }
            else
            {
                String a = GetElapsedTime();
                String b = "";
                if (e.buttonState == MouseButtonState.Pressed)
                {
                    logger.LogMouseClick(now, e.Button.ToString(), MouseInputType.Pressed, e.X, e.Y);                    
                }
                else
                {
                    logger.LogMouseClick(now, e.Button.ToString(), MouseInputType.Released, e.X, e.Y);                    
                }                
            }
		} 

		private void InputListener_MouseMove(object sender, MouseMoveEventArgs e) //Records Mouse Movements
		{
            DateTime now = DateTime.Now;

            if (this.suspendLogging == true)
            {

            }
            else
            {
                logger.LogMousePosition(now, e.X, e.Y);
            }
        }

        #endregion

        public string GetElapsedTime()
		{
            DateTime now = DateTime.Now;

            return now.ToString("s") + ":" + now.Millisecond;            
		}

		public void Timer_Tick( object sender, EventArgs eArgs )
		{
			if( sender == timer1 )
			{				
				Invalidate();
			}
		}

		private void startRecordingButton_Click(object sender, System.EventArgs e)
		{
            if (taskBreakdownCheckBox.Checked == true && taskBreakdownListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select task breakdown to use.");
            }
            else if (taskBreakdownCheckBox.Checked == true)
            {
                this.currentTaskBreakdown = taskBreakdownListBox.SelectedItem.ToString();                
                
                //disalbe buttons
                addTaskButton.Enabled = false;
                editTaskButton.Enabled = false;
                deleteBreakdownBtn.Enabled = false;

                statusTextBox.Text = "Recording...";                
                record();
            }
            else
            {
                statusTextBox.Text = "Recording...";
                record();
            }
		} 

		public void record()
		{
            if (fileLocTextBox.Text == "")
            {
                MessageBox.Show("Please select a location to store the output file.");
            }
            else
            {
                this.startRecordingButton.Enabled = false;
                this.stopRecording.Enabled = true;
                this.taskBreakdownListBox.Enabled = false;

                System.Timers.Timer timer1 = null;

                //create logger
                if (textOutputRdBtn.Checked == true)
                {
                    if (absoluteTimeRdBtn.Checked == true)
                    {
                        logger = new TextLogger(fileLocTextBox.Text, LogTimeType.Absolute);
                    }
                    else if (relativeTimeRdBtn.Checked == true)
                    {
                        logger = new TextLogger(fileLocTextBox.Text, LogTimeType.Relative);
                    }
                }
                else if (excelOutputRdBtn.Checked == true)
                {
                    if (absoluteTimeRdBtn.Checked == true)
                    {
                        logger = new ExcelLogger(fileLocTextBox.Text, LogTimeType.Absolute);
                    }
                    else if (relativeTimeRdBtn.Checked == true)
                    {
                        logger = new ExcelLogger(fileLocTextBox.Text, LogTimeType.Relative);
                    }                    
                }               
                
                if (taskBreakdownCheckBox.Checked == true)
                {
                    //load breakdowns
                    FileInfo fi = new FileInfo(Application.StartupPath + "\\TaskBreakdowns.xml");

                    if (fi.Exists)
                    {
                        FileStream fs = new FileStream(Application.StartupPath + "\\TaskBreakdowns.xml", FileMode.Open);
                        XmlSerializer s = new XmlSerializer(typeof(TaskBreakdowns));                         
                        fs.Close();
                    }
                    
                    logger.LogTaskBreakDown(taskBreakdownListBox.SelectedItem.ToString());
                }

                mouseListener = new MouseListener();
                keyListener = new KeyListener();
                
                //enable listeners based on what is checked
                if (checkBox3.Checked)
                {
                    mouseListener.OnMouseMove += new MouseListener.MouseMoveHandler(InputListener_MouseMove);
                }
                if (checkBox2.Checked)
                {
                    mouseListener.OnMouseButton += new MouseListener.MouseButtonHandler(InputListener_MouseButton);
                }
                if (checkBox1.Checked)
                {
                    keyListener.OnKeyPress += new KeyListener.KeyPressHandler(KeyListener_KeyPress);
                }

                quit = false;
                if (!quit)
                {
                    mouseListener.Run();
                    keyListener.Run();
                }
                timer1 = new System.Timers.Timer();

                // Setup timer
                timer1.Interval = 0.1;
                timer1.Enabled = true;

                fileLocTextBox.Enabled = false;
                globalvar.startTime = DateTime.Now;
            }
		}
		
        private void stopRecordingButton_Click(object sender, System.EventArgs e)
		{
            try
            {
                mouseListener.Stop();
                keyListener.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping listener.");
            }

            this.taskBreakdownListBox.Enabled = true;
            this.stopRecording.Enabled = false;
            this.startRecordingButton.Enabled = true;

            //enable buttons
            addTaskButton.Enabled = true;
            editTaskButton.Enabled = true;
            deleteBreakdownBtn.Enabled = true;

            quit = true;
            statusTextBox.Text = "";

			label1.Enabled=false;			

			timer1.Enabled =false;

            logger.StopLogging();
		}

        #region Replay Functions

        /// <summary>
        /// Replay button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, System.EventArgs e)
        {
            replayStatusTxtBox.Text = "Replaying...";

            stopReplayKeyList = new KeyListener();
            stopReplayKeyList.OnKeyPress += new KeyListener.KeyPressHandler(stopReplayKeyList_OnKeyPress);
            stopReplayKeyList.Run();

            double sleepTimeMod = 0;
            if (radioButton2.Checked == true)
                sleepTimeMod = 0;
            else if (radioButton3.Checked == true)
                sleepTimeMod = 2;
            else if (radioButton1.Checked == true)
                sleepTimeMod = 0.5;

            replayProcessor = new RUIReplayer(this.replayFileTextBox.Text, sleepTimeMod);
            replayProcessor.Run();

            /*
            continueReplay = true;

            stopReplayKeyList = new KeyListener();
            stopReplayKeyList.OnKeyPress += new KeyListener.KeyPressHandler(stopReplayKeyList_OnKeyPress);
            stopReplayKeyList.Run();

            replay();

            stopReplayKeyList.Stop();

            replayStatusTxtBox.Text = "Done with replay.";
             */
        }


	
 
        #endregion

        private void Form1_Load(object sender, System.EventArgs e)
		{
			// Adding a new menu to the form
			MainMenu mainMenu = new MainMenu();
			this.Menu = mainMenu;
			ContextMenu label1ContextMenu = new ContextMenu();
			Label label10 = new Label();
			label10.ContextMenu = label1ContextMenu; 

			//Add Database Options Menu
			MenuItem miFile = mainMenu.MenuItems.Add("&Options");
			miFile.MenuItems.Add(new MenuItem("Start Recording", new EventHandler(this.startRecordingButton_Click), Shortcut.CtrlR));
			miFile.MenuItems.Add("-"); // Gives us a seperator
			miFile.MenuItems.Add(new MenuItem("Stop Recording", new EventHandler(this.stopRecordingButton_Click), Shortcut.CtrlS));
			
		}

		private void browseFileLocButton(object sender, System.EventArgs e)
		{			
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            if (textOutputRdBtn.Checked == true)
            {
                saveFileDialog1.Filter = "Text file|*.txt";
            }
            else
            {
                saveFileDialog1.Filter = "Excel file|*.xls";
            }

			saveFileDialog1.ShowDialog();

			// If the file name is not an empty string open it for saving.
			if(saveFileDialog1.FileName != "")
			{				
				System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
				filename =fs.Name;
				replay_file =fs.Name;
                fileLocTextBox.Text = fs.Name;
                
                fs.Close();
			}
		}

		private void replayFileLocButton(object sender, System.EventArgs e) // log file location
		{
			OpenFileDialog fdlg = new OpenFileDialog();
						
			fdlg.Filter = "Text file|*.txt"; ;
			
			fdlg.RestoreDirectory = true ;
			if(fdlg.ShowDialog() == DialogResult.OK)
			{
				replayFileTextBox.Text = fdlg.FileName ;
			}
			
            replay_file = fdlg.FileName;
        }

        #region task breakdown functions

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            TaskBreakdownForm taskBreakdownForm = new TaskBreakdownForm(false);
            taskBreakdownForm.ShowDialog();

            this.refreshBreakdownList();         
        }

        private void refreshBreakdownList()
        {
            this.taskBreakdownListBox.Items.Clear();

            BreakdownStorage bs = BreakdownStorage.Instance;
            taskBreakdowns = bs.Breakdowns;

            if (taskBreakdowns.TaskBreakdownField != null)
            {
                //display task breakdowns in list bow
                for (int i = 0; i < taskBreakdowns.TaskBreakdownField.Count; i++)
                {
                    taskBreakdownListBox.Items.Add(taskBreakdowns.TaskBreakdownField[i].Name);
                }
            }
        }

        private void deleteBreakdownBtn_Click(object sender, EventArgs e)
        {
            if (taskBreakdownListBox.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected breakdown?", "Are you sure?", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    BreakdownStorage bs = BreakdownStorage.Instance;

                    bs.deleteTaskBreakdown(taskBreakdownListBox.SelectedItem.ToString());

                    this.refreshBreakdownList();
                }
            }
            else
            {
                MessageBox.Show("Please select a breakdown to delete.");
            }
        }

        private void editTaskButton_Click(object sender, EventArgs e)
        {
            if(this.taskBreakdownListBox.SelectedItem != null){
                BreakdownStorage bs = BreakdownStorage.Instance;
                TaskBreakdown editBreakdown = bs.getBreakdown(this.taskBreakdownListBox.SelectedItem.ToString());
                
                TaskBreakdownForm tbf = new TaskBreakdownForm(false,editBreakdown);
                tbf.Show();
            }
            else
            {
                MessageBox.Show("Please select a breakdown to edit.");
            }
        }

        #endregion

        #region Process File Functions

        private void processLogFileBrowse_Click(object sender, EventArgs e)
        {
            this.outputTaskTree.Nodes.Clear();

            OpenFileDialog fdlg = new OpenFileDialog();

            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "Text file|*.txt"; ;

            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                processLogFileTextBox.Text = fdlg.FileName;
            }

            //process output 
            OutputProcessor outProc = new OutputProcessor();
            RUIOutput output = outProc.ProcessRUIOutput(processLogFileTextBox.Text);

            this.keyStrokesTextBox.Text = output.KeyStrokes.ToString();
            this.leftMouseTextBox.Text = output.LeftMouseClicks.ToString();
            this.rightMouseTextBox.Text = output.RightMouseClicks.ToString();
            this.mouseDistanceTextBox.Text = output.DistanceTraveled.ToString();
            double timeInMinutes = output.TotalTimeMilliSeconds / (60000);
            this.timeTextBox.Text = timeInMinutes.ToString();

            //get task breakdown
            TaskBreakdown logFileTb = output.TaskBreakdown;
            //populate tree
            if (logFileTb != null)
            {
                TreeNode topLevelNode = this.outputTaskTree.Nodes.Add(logFileTb.Name);
                Task topLevelTask = new Task();
                topLevelTask.OutputStats = output;
                topLevelNode.Tag = topLevelTask;

                if (logFileTb.Task != null)
                {
                    for (int i = 0; i < logFileTb.Task.Length; i++)
                    {
                        this.createTreeNode(logFileTb.Task[i], topLevelNode);
                    }
                }
            }            
        }

        private void createTreeNode(Task task, TreeNode treeNode)
        {
            if (treeNode == null)
            {
                TreeNode newNode = this.outputTaskTree.Nodes.Add(task.Name);
                newNode.Tag = task;

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
                newNode.Tag = task;                

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

        private void outputTaskTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //method called when node is selected
            String taskName = outputTaskTree.SelectedNode.Text;

            Task currentTask = (Task)outputTaskTree.SelectedNode.Tag;
            RUIOutput output = currentTask.OutputStats;

            if (output != null)
            {
                this.keyStrokesTextBox.Text = output.KeyStrokes.ToString();
                this.leftMouseTextBox.Text = output.LeftMouseClicks.ToString();
                this.rightMouseTextBox.Text = output.RightMouseClicks.ToString();
                this.mouseDistanceTextBox.Text = output.DistanceTraveled.ToString();
                double timeInMinutes = output.TotalTimeMilliSeconds / (60000);
                this.timeTextBox.Text = timeInMinutes.ToString();
            }
            else
            {
                this.keyStrokesTextBox.Text = "0";
                this.leftMouseTextBox.Text = "0";
                this.rightMouseTextBox.Text = "0";
                this.mouseDistanceTextBox.Text = "0";
                this.timeTextBox.Text = "0";
            }
        }

        #endregion 

       
        private void excelOutputRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (excelOutputRdBtn.Checked == true)
            {
                MessageBox.Show("Note: If you output to Excel file, you will not be able to replay or run statistics on the log file. This feature needs added to RUI.");
            }
        }

        private void stopReplayBtn_Click(object sender, EventArgs e)
        {
            //continueReplay = false;
            this.stopReplayKeyList.Stop();
            replayProcessor.Stop();            
            this.replayStatusTxtBox.Text = "Done with replay.";
        }

        private void nasaTlxBtn_Click(object sender, EventArgs e)
        {
             //suspend logging
             this.suspendLogging = true;

            TLXForm tlxform = new TLXForm();
            tlxform.ShowDialog();

            //reactivate logging
            this.suspendLogging = false;
        }


    }

    public class globalvar
    {
        public static bool quitting;
        public static long oldTime = 0;
        public static System.DateTime startTime;
    }
}
