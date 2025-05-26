namespace LabManagement
{
    partial class UserEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(80, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入用户名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(80, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "输入用户姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(80, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "输入联系方式（选填）：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(80, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "输入密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(80, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "选择身份：";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("宋体", 14F);
            this.txtName.Location = new System.Drawing.Point(420, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 39);
            this.txtName.TabIndex = 5;
            // 
            // txtRealName
            // 
            this.txtRealName.Font = new System.Drawing.Font("宋体", 14F);
            this.txtRealName.Location = new System.Drawing.Point(420, 110);
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(300, 39);
            this.txtRealName.TabIndex = 6;
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("宋体", 14F);
            this.txtContact.Location = new System.Drawing.Point(420, 170);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(300, 39);
            this.txtContact.TabIndex = 7;
            // 
            // comboRole
            // 
            this.comboRole.Font = new System.Drawing.Font("宋体", 14F);
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Location = new System.Drawing.Point(420, 290);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(300, 36);
            this.comboRole.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("宋体", 14F);
            this.btnSave.Location = new System.Drawing.Point(320, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 58);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("宋体", 14F);
            this.txtPassword.Location = new System.Drawing.Point(420, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 39);
            this.txtPassword.TabIndex = 11;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserEditForm";
            this.Text = "UserEditForm";
            this.Load += new System.EventHandler(this.UserEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPassword;
    }
}