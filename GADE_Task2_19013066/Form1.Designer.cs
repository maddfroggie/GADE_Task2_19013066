namespace GADE_Task2_19013066
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.txtUnitInfo = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblRound = new System.Windows.Forms.Label();
            this.DisplayMap = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUnitInfo
            // 
            this.txtUnitInfo.Location = new System.Drawing.Point(585, 215);
            this.txtUnitInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnitInfo.Multiline = true;
            this.txtUnitInfo.Name = "txtUnitInfo";
            this.txtUnitInfo.Size = new System.Drawing.Size(241, 72);
            this.txtUnitInfo.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(585, 36);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(125, 55);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(585, 109);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(125, 60);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(582, 182);
            this.lblRound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(58, 17);
            this.lblRound.TabIndex = 6;
            this.lblRound.Text = "Round: ";
            this.lblRound.Click += new System.EventHandler(this.lblRound_Click);
            // 
            // DisplayMap
            // 
            this.DisplayMap.Location = new System.Drawing.Point(13, 13);
            this.DisplayMap.Margin = new System.Windows.Forms.Padding(4);
            this.DisplayMap.Name = "DisplayMap";
            this.DisplayMap.Padding = new System.Windows.Forms.Padding(4);
            this.DisplayMap.Size = new System.Drawing.Size(548, 474);
            this.DisplayMap.TabIndex = 5;
            this.DisplayMap.TabStop = false;
            this.DisplayMap.Text = "Display";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(585, 378);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 56);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(585, 306);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(125, 57);
            this.btnRead.TabIndex = 11;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 497);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtUnitInfo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.DisplayMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUnitInfo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.GroupBox DisplayMap;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRead;
        public System.Windows.Forms.Timer timer1;
    }
}

