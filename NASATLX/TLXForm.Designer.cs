namespace RUI.NASATLX
{
    partial class TLXForm
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
            this.mentalDemandSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.physicalDemandSlider = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.temperallDemandSlider = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.perfSlider = new System.Windows.Forms.TrackBar();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.effortSlider = new System.Windows.Forms.TrackBar();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.frustrationSlider = new System.Windows.Forms.TrackBar();
            this.label26 = new System.Windows.Forms.Label();
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mentalDemandSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalDemandSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperallDemandSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.effortSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frustrationSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // mentalDemandSlider
            // 
            this.mentalDemandSlider.Location = new System.Drawing.Point(15, 140);
            this.mentalDemandSlider.Maximum = 21;
            this.mentalDemandSlider.Name = "mentalDemandSlider";
            this.mentalDemandSlider.Size = new System.Drawing.Size(381, 45);
            this.mentalDemandSlider.TabIndex = 0;
            this.mentalDemandSlider.Value = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Very Low";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Very High";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mental Demand";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "How mentally demanding was the task?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "NASA Task Load Index";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(15, 33);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(381, 46);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Hart and Staveland’s NASA Task Load Index (TLX) method assesses work load on five" +
                " 7-point scales. Increments of high, medium and low estimates for each point res" +
                "ult in 21 gradations on the scales.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "How physically demanding was the task?";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Physical Demand";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 287);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Very High";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Very Low";
            // 
            // physicalDemandSlider
            // 
            this.physicalDemandSlider.Location = new System.Drawing.Point(15, 239);
            this.physicalDemandSlider.Maximum = 21;
            this.physicalDemandSlider.Name = "physicalDemandSlider";
            this.physicalDemandSlider.Size = new System.Drawing.Size(381, 45);
            this.physicalDemandSlider.TabIndex = 7;
            this.physicalDemandSlider.Value = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Temperol Demand";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(343, 389);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Very High";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 389);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Very Low";
            // 
            // temperallDemandSlider
            // 
            this.temperallDemandSlider.Location = new System.Drawing.Point(15, 341);
            this.temperallDemandSlider.Maximum = 21;
            this.temperallDemandSlider.Name = "temperallDemandSlider";
            this.temperallDemandSlider.Size = new System.Drawing.Size(381, 45);
            this.temperallDemandSlider.TabIndex = 12;
            this.temperallDemandSlider.Value = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 425);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Performance";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(340, 489);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 13);
            this.label16.TabIndex = 19;
            this.label16.Text = "Very High";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 489);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "Very Low";
            // 
            // perfSlider
            // 
            this.perfSlider.Location = new System.Drawing.Point(12, 441);
            this.perfSlider.Maximum = 21;
            this.perfSlider.Name = "perfSlider";
            this.perfSlider.Size = new System.Drawing.Size(381, 45);
            this.perfSlider.TabIndex = 17;
            this.perfSlider.Value = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 529);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "Effort";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(340, 593);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 13);
            this.label20.TabIndex = 24;
            this.label20.Text = "Very High";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(9, 593);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(51, 13);
            this.label21.TabIndex = 23;
            this.label21.Text = "Very Low";
            // 
            // effortSlider
            // 
            this.effortSlider.Location = new System.Drawing.Point(12, 545);
            this.effortSlider.Maximum = 21;
            this.effortSlider.Name = "effortSlider";
            this.effortSlider.Size = new System.Drawing.Size(381, 45);
            this.effortSlider.TabIndex = 22;
            this.effortSlider.Value = 11;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(89, 714);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(96, 35);
            this.submitBtn.TabIndex = 27;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(205, 714);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(88, 35);
            this.cancelBtn.TabIndex = 28;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(156, 325);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(237, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "How hurried or rushed was the pace of the task?";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 623);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 13);
            this.label22.TabIndex = 34;
            this.label22.Text = "Frustration";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(340, 687);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 13);
            this.label23.TabIndex = 33;
            this.label23.Text = "Very High";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 687);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 13);
            this.label24.TabIndex = 32;
            this.label24.Text = "Very Low";
            // 
            // frustrationSlider
            // 
            this.frustrationSlider.Location = new System.Drawing.Point(12, 639);
            this.frustrationSlider.Maximum = 21;
            this.frustrationSlider.Name = "frustrationSlider";
            this.frustrationSlider.Size = new System.Drawing.Size(381, 45);
            this.frustrationSlider.TabIndex = 31;
            this.frustrationSlider.Value = 11;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(12, 97);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(39, 13);
            this.label26.TabIndex = 35;
            this.label26.Text = "Task:";
            // 
            // taskTextBox
            // 
            this.taskTextBox.Location = new System.Drawing.Point(58, 97);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(335, 20);
            this.taskTextBox.TabIndex = 36;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(159, 405);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(234, 33);
            this.richTextBox2.TabIndex = 37;
            this.richTextBox2.Text = "How successful were you in accomplishing what you were asked to do?";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Location = new System.Drawing.Point(159, 509);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(234, 33);
            this.richTextBox3.TabIndex = 38;
            this.richTextBox3.Text = "How hard did you have to work to accomplish your level of performance?";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox4.Location = new System.Drawing.Point(159, 609);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(234, 33);
            this.richTextBox4.TabIndex = 39;
            this.richTextBox4.Text = "How insecure, discouraged, irritated, stressed, and annoyed were you?";
            // 
            // TLXForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 763);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.taskTextBox);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.frustrationSlider);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.effortSlider);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.perfSlider);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.temperallDemandSlider);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.physicalDemandSlider);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mentalDemandSlider);
            this.Name = "TLXForm";
            this.Text = "TLXForm";
            ((System.ComponentModel.ISupportInitialize)(this.mentalDemandSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.physicalDemandSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperallDemandSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.effortSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frustrationSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar mentalDemandSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar physicalDemandSlider;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar temperallDemandSlider;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar perfSlider;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TrackBar effortSlider;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TrackBar frustrationSlider;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
    }
}