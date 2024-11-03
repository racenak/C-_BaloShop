
namespace WinformForProject
{
    partial class FormDK
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.dnLink = new System.Windows.Forms.LinkLabel();
            this.mkBox = new System.Windows.Forms.TextBox();
            this.dkButton = new System.Windows.Forms.Button();
            this.tkBox = new System.Windows.Forms.TextBox();
            this.mkLabel = new System.Windows.Forms.Label();
            this.tkLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::WinformForProject.Properties.Resources.ehman1;
            this.groupBox1.Controls.Add(this.lnBox);
            this.groupBox1.Controls.Add(this.lastNameLabel);
            this.groupBox1.Controls.Add(this.dnLink);
            this.groupBox1.Controls.Add(this.mkBox);
            this.groupBox1.Controls.Add(this.dkButton);
            this.groupBox1.Controls.Add(this.tkBox);
            this.groupBox1.Controls.Add(this.mkLabel);
            this.groupBox1.Controls.Add(this.tkLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đăng ký";
            // 
            // lnBox
            // 
            this.lnBox.Location = new System.Drawing.Point(199, 129);
            this.lnBox.Name = "lnBox";
            this.lnBox.Size = new System.Drawing.Size(367, 38);
            this.lnBox.TabIndex = 9;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.lastNameLabel.ForeColor = System.Drawing.Color.Wheat;
            this.lastNameLabel.Location = new System.Drawing.Point(27, 132);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(151, 32);
            this.lastNameLabel.TabIndex = 8;
            this.lastNameLabel.Text = "Last Name";
            // 
            // dnLink
            // 
            this.dnLink.AutoSize = true;
            this.dnLink.BackColor = System.Drawing.Color.Transparent;
            this.dnLink.LinkColor = System.Drawing.Color.Aqua;
            this.dnLink.Location = new System.Drawing.Point(12, 366);
            this.dnLink.Name = "dnLink";
            this.dnLink.Size = new System.Drawing.Size(154, 32);
            this.dnLink.TabIndex = 7;
            this.dnLink.TabStop = true;
            this.dnLink.Text = "Đăng nhập";
            this.dnLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.dnLink_LinkClicked);
            // 
            // mkBox
            // 
            this.mkBox.Location = new System.Drawing.Point(199, 223);
            this.mkBox.Name = "mkBox";
            this.mkBox.PasswordChar = '*';
            this.mkBox.Size = new System.Drawing.Size(367, 38);
            this.mkBox.TabIndex = 6;
            // 
            // dkButton
            // 
            this.dkButton.BackColor = System.Drawing.Color.Transparent;
            this.dkButton.Location = new System.Drawing.Point(199, 278);
            this.dkButton.Name = "dkButton";
            this.dkButton.Size = new System.Drawing.Size(232, 80);
            this.dkButton.TabIndex = 5;
            this.dkButton.Text = "Đăng ký";
            this.dkButton.UseVisualStyleBackColor = false;
            this.dkButton.Click += new System.EventHandler(this.dkButton_Click);
            // 
            // tkBox
            // 
            this.tkBox.Location = new System.Drawing.Point(199, 40);
            this.tkBox.Name = "tkBox";
            this.tkBox.Size = new System.Drawing.Size(367, 38);
            this.tkBox.TabIndex = 2;
            // 
            // mkLabel
            // 
            this.mkLabel.AutoSize = true;
            this.mkLabel.BackColor = System.Drawing.Color.Transparent;
            this.mkLabel.ForeColor = System.Drawing.Color.Wheat;
            this.mkLabel.Location = new System.Drawing.Point(27, 226);
            this.mkLabel.Name = "mkLabel";
            this.mkLabel.Size = new System.Drawing.Size(131, 32);
            this.mkLabel.TabIndex = 1;
            this.mkLabel.Text = "Mật khẩu";
            // 
            // tkLabel
            // 
            this.tkLabel.AutoSize = true;
            this.tkLabel.BackColor = System.Drawing.Color.Transparent;
            this.tkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tkLabel.ForeColor = System.Drawing.Color.Olive;
            this.tkLabel.Location = new System.Drawing.Point(27, 40);
            this.tkLabel.Name = "tkLabel";
            this.tkLabel.Size = new System.Drawing.Size(162, 32);
            this.tkLabel.TabIndex = 0;
            this.tkLabel.Text = "First Name";
            // 
            // FormDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 422);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDK";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label tkLabel;
        private System.Windows.Forms.Label mkLabel;
        private System.Windows.Forms.TextBox tkBox;
        private System.Windows.Forms.Button dkButton;
        private System.Windows.Forms.LinkLabel dnLink;
        private System.Windows.Forms.TextBox mkBox;
        private System.Windows.Forms.TextBox lnBox;
        private System.Windows.Forms.Label lastNameLabel;
    }
}