namespace LabManagement
{
    partial class MainForm
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
            this.btnDeviceManager = new System.Windows.Forms.Button();
            this.btnUserManager = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeviceManager
            // 
            this.btnDeviceManager.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeviceManager.Location = new System.Drawing.Point(193, 187);
            this.btnDeviceManager.Name = "btnDeviceManager";
            this.btnDeviceManager.Size = new System.Drawing.Size(172, 81);
            this.btnDeviceManager.TabIndex = 0;
            this.btnDeviceManager.Text = "管理设备";
            this.btnDeviceManager.UseVisualStyleBackColor = true;
            this.btnDeviceManager.Click += new System.EventHandler(this.btnDeviceManager_Click);
            // 
            // btnUserManager
            // 
            this.btnUserManager.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserManager.Location = new System.Drawing.Point(535, 187);
            this.btnUserManager.Name = "btnUserManager";
            this.btnUserManager.Size = new System.Drawing.Size(172, 81);
            this.btnUserManager.TabIndex = 1;
            this.btnUserManager.Text = "用户管理";
            this.btnUserManager.UseVisualStyleBackColor = true;
            this.btnUserManager.Click += new System.EventHandler(this.btnUserManager_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Font = new System.Drawing.Font("宋体", 14F);
            this.btnViewLog.Location = new System.Drawing.Point(193, 320);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(172, 81);
            this.btnViewLog.TabIndex = 2;
            this.btnViewLog.Text = "查看日志";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 597);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.btnUserManager);
            this.Controls.Add(this.btnDeviceManager);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeviceManager;
        private System.Windows.Forms.Button btnUserManager;
        private System.Windows.Forms.Button btnViewLog;
    }
}