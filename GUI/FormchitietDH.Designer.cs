
namespace WinformForProject
{
    partial class FormchitietDH
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
            this.idDonhang = new System.Windows.Forms.Label();
            this.idEmployee = new System.Windows.Forms.Label();
            this.detailDate = new System.Windows.Forms.Label();
            this.detailTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).BeginInit();
            this.SuspendLayout();
            // 
            // idDonhang
            // 
            this.idDonhang.AutoSize = true;
            this.idDonhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.idDonhang.Location = new System.Drawing.Point(9, 7);
            this.idDonhang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idDonhang.Name = "idDonhang";
            this.idDonhang.Size = new System.Drawing.Size(40, 26);
            this.idDonhang.TabIndex = 0;
            this.idDonhang.Text = "ID:";
            this.idDonhang.Click += new System.EventHandler(this.idDonhang_Click);
            // 
            // idEmployee
            // 
            this.idEmployee.AutoSize = true;
            this.idEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.idEmployee.Location = new System.Drawing.Point(172, 7);
            this.idEmployee.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.idEmployee.Name = "idEmployee";
            this.idEmployee.Size = new System.Drawing.Size(130, 26);
            this.idEmployee.TabIndex = 1;
            this.idEmployee.Text = "IDNhanVien";
            this.idEmployee.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // detailDate
            // 
            this.detailDate.AutoSize = true;
            this.detailDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.detailDate.Location = new System.Drawing.Point(398, 7);
            this.detailDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.detailDate.Name = "detailDate";
            this.detailDate.Size = new System.Drawing.Size(70, 26);
            this.detailDate.TabIndex = 2;
            this.detailDate.Text = "DATE";
            // 
            // detailTable
            // 
            this.detailTable.BackgroundColor = System.Drawing.Color.White;
            this.detailTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailTable.Location = new System.Drawing.Point(9, 62);
            this.detailTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.detailTable.Name = "detailTable";
            this.detailTable.RowHeadersWidth = 51;
            this.detailTable.RowTemplate.Height = 24;
            this.detailTable.Size = new System.Drawing.Size(582, 294);
            this.detailTable.TabIndex = 3;
            this.detailTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailTable_CellContentClick);
            // 
            // FormchitietDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.detailTable);
            this.Controls.Add(this.detailDate);
            this.Controls.Add(this.idEmployee);
            this.Controls.Add(this.idDonhang);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormchitietDH";
            this.Text = "FormchitietDH";
            ((System.ComponentModel.ISupportInitialize)(this.detailTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label idDonhang;
        private System.Windows.Forms.Label idEmployee;
        private System.Windows.Forms.Label detailDate;
        private System.Windows.Forms.DataGridView detailTable;
    }
}