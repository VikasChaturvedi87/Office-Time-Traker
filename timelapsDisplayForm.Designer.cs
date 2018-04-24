namespace TimeTraker {
    partial class timelapsDisplayForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(timelapsDisplayForm));
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblTimelaps = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.officeTimer = new System.Windows.Forms.Timer(this.components);
            this.timeNotification = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnHide = new System.Windows.Forms.Button();
            this.lblExitTime = new System.Windows.Forms.Label();
            this.lblCurrentAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartTime.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblStartTime.Location = new System.Drawing.Point(10, 9);
            this.lblStartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(86, 18);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Start Time";
            this.lblStartTime.Click += new System.EventHandler(this.lblStartTime_Click);
            // 
            // lblTimelaps
            // 
            this.lblTimelaps.AutoSize = true;
            this.lblTimelaps.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimelaps.ForeColor = System.Drawing.Color.Teal;
            this.lblTimelaps.Location = new System.Drawing.Point(7, 45);
            this.lblTimelaps.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimelaps.Name = "lblTimelaps";
            this.lblTimelaps.Size = new System.Drawing.Size(75, 18);
            this.lblTimelaps.TabIndex = 1;
            this.lblTimelaps.Text = "Timelaps";
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(13, 10);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(151, 20);
            this.startTimePicker.TabIndex = 2;
            this.startTimePicker.Visible = false;
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            this.startTimePicker.VisibleChanged += new System.EventHandler(this.startTimePicker_VisibleChanged);
            this.startTimePicker.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startTimePicker_KeyDown);
            this.startTimePicker.Leave += new System.EventHandler(this.startTimePicker_Leave);
            // 
            // officeTimer
            // 
            this.officeTimer.Tick += new System.EventHandler(this.officeTimer_Tick);
            // 
            // timeNotification
            // 
            this.timeNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.timeNotification.BalloonTipText = "Know your total time";
            this.timeNotification.BalloonTipTitle = "Time";
            this.timeNotification.Icon = ((System.Drawing.Icon)(resources.GetObject("timeNotification.Icon")));
            this.timeNotification.Visible = true;
            this.timeNotification.Click += new System.EventHandler(this.timeNotification_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(268, 8);
            this.btnHide.Margin = new System.Windows.Forms.Padding(2);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(46, 20);
            this.btnHide.TabIndex = 3;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // lblExitTime
            // 
            this.lblExitTime.AutoSize = true;
            this.lblExitTime.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExitTime.ForeColor = System.Drawing.Color.Teal;
            this.lblExitTime.Location = new System.Drawing.Point(168, 12);
            this.lblExitTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExitTime.Name = "lblExitTime";
            this.lblExitTime.Size = new System.Drawing.Size(48, 18);
            this.lblExitTime.TabIndex = 4;
            this.lblExitTime.Text = "EOD: ";
            // 
            // lblCurrentAddress
            // 
            this.lblCurrentAddress.AutoSize = true;
            this.lblCurrentAddress.Font = new System.Drawing.Font("Candara", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAddress.ForeColor = System.Drawing.Color.Teal;
            this.lblCurrentAddress.Location = new System.Drawing.Point(9, 63);
            this.lblCurrentAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentAddress.Name = "lblCurrentAddress";
            this.lblCurrentAddress.Size = new System.Drawing.Size(31, 13);
            this.lblCurrentAddress.TabIndex = 5;
            this.lblCurrentAddress.Text = "Add :";
            // 
            // timelapsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(322, 85);
            this.Controls.Add(this.lblCurrentAddress);
            this.Controls.Add(this.lblExitTime);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.lblTimelaps);
            this.Controls.Add(this.lblStartTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "timelapsDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.timelapsDisplayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblTimelaps;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Timer officeTimer;
        private System.Windows.Forms.NotifyIcon timeNotification;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label lblExitTime;
        private System.Windows.Forms.Label lblCurrentAddress;
    }
}

