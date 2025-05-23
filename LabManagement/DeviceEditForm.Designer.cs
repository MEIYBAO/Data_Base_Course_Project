namespace LabManagement
{
    partial class DeviceEditForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datePurchase = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboLab = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboManager = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(323, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 39);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(96, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入设备名称：";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtModel.Location = new System.Drawing.Point(323, 131);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(266, 39);
            this.txtModel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(96, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入设备型号：";
            // 
            // datePurchase
            // 
            this.datePurchase.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.datePurchase.Location = new System.Drawing.Point(323, 208);
            this.datePurchase.Name = "datePurchase";
            this.datePurchase.Size = new System.Drawing.Size(266, 39);
            this.datePurchase.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(96, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "选择购买时间：";
            // 
            // comboStatus
            // 
            this.comboStatus.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "正常",
            "借出",
            "维修",
            "报废"});
            this.comboStatus.Location = new System.Drawing.Point(323, 286);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(266, 36);
            this.comboStatus.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(96, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "设备状态：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(96, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "实验室选择：";
            // 
            // comboLab
            // 
            this.comboLab.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboLab.FormattingEnabled = true;
            this.comboLab.Items.AddRange(new object[] {
            "正常",
            "借出",
            "维修",
            "报废"});
            this.comboLab.Location = new System.Drawing.Point(323, 365);
            this.comboLab.Name = "comboLab";
            this.comboLab.Size = new System.Drawing.Size(266, 36);
            this.comboLab.TabIndex = 8;
            this.comboLab.SelectedIndexChanged += new System.EventHandler(this.comboLab_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(96, 441);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "管理员选择：";
            // 
            // comboManager
            // 
            this.comboManager.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboManager.FormattingEnabled = true;
            this.comboManager.Items.AddRange(new object[] {
            "正常",
            "借出",
            "维修",
            "报废"});
            this.comboManager.Location = new System.Drawing.Point(323, 441);
            this.comboManager.Name = "comboManager";
            this.comboManager.Size = new System.Drawing.Size(266, 36);
            this.comboManager.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(206, 522);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 58);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // DeviceEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 653);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboManager);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboLab);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePurchase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "DeviceEditForm";
            this.Text = "DeviceEditForm";
            this.Load += new System.EventHandler(this.DeviceEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePurchase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboLab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboManager;
        private System.Windows.Forms.Button btnSave;
    }
}