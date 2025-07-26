namespace QL_CUAHANG_THOITRANG
{
    partial class frmTKHD
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTK = new System.Windows.Forms.ComboBox();
            this.dgvTK = new System.Windows.Forms.DataGridView();
            this.btnTK = new System.Windows.Forms.Button();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.btnCT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightGray;
            this.btnThoat.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(472, 78);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 37);
            this.btnThoat.TabIndex = 52;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 24);
            this.label3.TabIndex = 51;
            this.label3.Text = "Chọn hóa đơn:";
            // 
            // cboTK
            // 
            this.cboTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTK.FormattingEnabled = true;
            this.cboTK.Location = new System.Drawing.Point(177, 81);
            this.cboTK.Name = "cboTK";
            this.cboTK.Size = new System.Drawing.Size(165, 32);
            this.cboTK.TabIndex = 50;
            // 
            // dgvTK
            // 
            this.dgvTK.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTK.Location = new System.Drawing.Point(12, 129);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.Size = new System.Drawing.Size(548, 150);
            this.dgvTK.TabIndex = 48;
            // 
            // btnTK
            // 
            this.btnTK.BackColor = System.Drawing.Color.LightGray;
            this.btnTK.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTK.Location = new System.Drawing.Point(413, 11);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(115, 40);
            this.btnTK.TabIndex = 47;
            this.btnTK.Text = "Tìm kiếm";
            this.btnTK.UseVisualStyleBackColor = false;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(17, 17);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(378, 29);
            this.txtTK.TabIndex = 46;
            // 
            // btnCT
            // 
            this.btnCT.BackColor = System.Drawing.Color.LightGray;
            this.btnCT.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCT.Location = new System.Drawing.Point(363, 77);
            this.btnCT.Name = "btnCT";
            this.btnCT.Size = new System.Drawing.Size(95, 38);
            this.btnCT.TabIndex = 53;
            this.btnCT.Text = "Chi tiết";
            this.btnCT.UseVisualStyleBackColor = false;
            this.btnCT.Click += new System.EventHandler(this.btnCT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 299);
            this.pictureBox1.TabIndex = 54;
            this.pictureBox1.TabStop = false;
            // 
            // frmTKHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 293);
            this.Controls.Add(this.btnCT);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTK);
            this.Controls.Add(this.dgvTK);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmTKHD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm hóa đơn";
            this.Load += new System.EventHandler(this.frmTKHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTK;
        private System.Windows.Forms.DataGridView dgvTK;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Button btnCT;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}