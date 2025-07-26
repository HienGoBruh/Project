namespace QL_CUAHANG_THOITRANG
{
    partial class frmTKSP
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
            this.cboMuc = new System.Windows.Forms.ComboBox();
            this.dgvTKMuc = new System.Windows.Forms.DataGridView();
            this.btnTKMuc = new System.Windows.Forms.Button();
            this.txtTKMuc = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThoat.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(498, 64);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(94, 35);
            this.btnThoat.TabIndex = 45;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label3.Location = new System.Drawing.Point(26, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 24);
            this.label3.TabIndex = 44;
            this.label3.Text = "Hãy chọn mục: ";
            // 
            // cboMuc
            // 
            this.cboMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMuc.FormattingEnabled = true;
            this.cboMuc.Location = new System.Drawing.Point(231, 68);
            this.cboMuc.Name = "cboMuc";
            this.cboMuc.Size = new System.Drawing.Size(237, 28);
            this.cboMuc.TabIndex = 43;
            // 
            // dgvTKMuc
            // 
            this.dgvTKMuc.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTKMuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTKMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKMuc.Location = new System.Drawing.Point(26, 117);
            this.dgvTKMuc.Name = "dgvTKMuc";
            this.dgvTKMuc.Size = new System.Drawing.Size(567, 150);
            this.dgvTKMuc.TabIndex = 41;
            // 
            // btnTKMuc
            // 
            this.btnTKMuc.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTKMuc.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKMuc.Location = new System.Drawing.Point(464, 15);
            this.btnTKMuc.Name = "btnTKMuc";
            this.btnTKMuc.Size = new System.Drawing.Size(127, 33);
            this.btnTKMuc.TabIndex = 40;
            this.btnTKMuc.Text = "Tìm kiếm";
            this.btnTKMuc.UseVisualStyleBackColor = false;
            this.btnTKMuc.Click += new System.EventHandler(this.btnTKMuc_Click);
            // 
            // txtTKMuc
            // 
            this.txtTKMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTKMuc.Location = new System.Drawing.Point(26, 18);
            this.txtTKMuc.Name = "txtTKMuc";
            this.txtTKMuc.Size = new System.Drawing.Size(419, 27);
            this.txtTKMuc.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 298);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // frmTKSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 284);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMuc);
            this.Controls.Add(this.dgvTKMuc);
            this.Controls.Add(this.btnTKMuc);
            this.Controls.Add(this.txtTKMuc);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmTKSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm sản phẩm";
            this.Load += new System.EventHandler(this.frmTKSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMuc;
        private System.Windows.Forms.DataGridView dgvTKMuc;
        private System.Windows.Forms.Button btnTKMuc;
        private System.Windows.Forms.TextBox txtTKMuc;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}