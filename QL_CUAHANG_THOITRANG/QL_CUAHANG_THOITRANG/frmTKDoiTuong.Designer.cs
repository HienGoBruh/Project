namespace QL_CUAHANG_THOITRANG
{
    partial class frmTKDoiTuong
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
            this.dgvTKDT = new System.Windows.Forms.DataGridView();
            this.btnTKDT = new System.Windows.Forms.Button();
            this.txtTKDT = new System.Windows.Forms.TextBox();
            this.cboDT = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTKDT
            // 
            this.dgvTKDT.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvTKDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTKDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKDT.Location = new System.Drawing.Point(42, 103);
            this.dgvTKDT.Name = "dgvTKDT";
            this.dgvTKDT.Size = new System.Drawing.Size(553, 150);
            this.dgvTKDT.TabIndex = 27;
            // 
            // btnTKDT
            // 
            this.btnTKDT.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTKDT.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKDT.Location = new System.Drawing.Point(386, 9);
            this.btnTKDT.Name = "btnTKDT";
            this.btnTKDT.Size = new System.Drawing.Size(107, 43);
            this.btnTKDT.TabIndex = 26;
            this.btnTKDT.Text = "Tìm kiếm";
            this.btnTKDT.UseVisualStyleBackColor = false;
            this.btnTKDT.Click += new System.EventHandler(this.btnTKDT_Click);
            // 
            // txtTKDT
            // 
            this.txtTKDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTKDT.Location = new System.Drawing.Point(45, 18);
            this.txtTKDT.Name = "txtTKDT";
            this.txtTKDT.Size = new System.Drawing.Size(305, 27);
            this.txtTKDT.TabIndex = 25;
            // 
            // cboDT
            // 
            this.cboDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDT.FormattingEnabled = true;
            this.cboDT.Location = new System.Drawing.Point(360, 66);
            this.cboDT.Name = "cboDT";
            this.cboDT.Size = new System.Drawing.Size(235, 28);
            this.cboDT.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label3.Location = new System.Drawing.Point(43, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Hãy chọn đối tượng: ";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnThoat.Font = new System.Drawing.Font("Montserrat Medium", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(502, 10);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 42);
            this.btnThoat.TabIndex = 38;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(632, 293);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // frmTKDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 283);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDT);
            this.Controls.Add(this.dgvTKDT);
            this.Controls.Add(this.btnTKDT);
            this.Controls.Add(this.txtTKDT);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmTKDoiTuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đối tượng";
            this.Load += new System.EventHandler(this.frmTKDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTKDT;
        private System.Windows.Forms.Button btnTKDT;
        private System.Windows.Forms.TextBox txtTKDT;
        private System.Windows.Forms.ComboBox cboDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}