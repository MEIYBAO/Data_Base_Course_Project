namespace LabManagement
{
    partial class DeviceLogForm
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
            this.dgvDeviceLog = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeviceLog
            // 
            this.dgvDeviceLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceLog.Location = new System.Drawing.Point(0, -1);
            this.dgvDeviceLog.Name = "dgvDeviceLog";
            this.dgvDeviceLog.RowHeadersWidth = 62;
            this.dgvDeviceLog.RowTemplate.Height = 30;
            this.dgvDeviceLog.Size = new System.Drawing.Size(1037, 547);
            this.dgvDeviceLog.TabIndex = 0;
            // 
            // DeviceLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 544);
            this.Controls.Add(this.dgvDeviceLog);
            this.Name = "DeviceLogForm";
            this.Text = "DeviceLogForm";
            this.Load += new System.EventHandler(this.DeviceLogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeviceLog;
    }
}