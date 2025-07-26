namespace QL_CUAHANG_THOITRANG
{
    partial class frmPHANQUYEN
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
            this.luoiPQ = new System.Windows.Forms.DataGridView();
            this.pnlPQ = new System.Windows.Forms.Panel();
            this.cmbUSER = new System.Windows.Forms.ComboBox();
            this.cmbCN = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDPQ = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTIMKIEM = new System.Windows.Forms.TextBox();
            this.btnHUY = new System.Windows.Forms.Button();
            this.btnLUU = new System.Windows.Forms.Button();
            this.btnSUA = new System.Windows.Forms.Button();
            this.btnXOA = new System.Windows.Forms.Button();
            this.btnTHEM = new System.Windows.Forms.Button();
            this.btnRESET = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTIM = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listcbPQ = new System.Windows.Forms.CheckedListBox();
            this.txtUSER = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.luoiPQ)).BeginInit();
            this.pnlPQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // luoiPQ
            // 
            this.luoiPQ.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.luoiPQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.luoiPQ.Location = new System.Drawing.Point(17, 208);
            this.luoiPQ.Name = "luoiPQ";
            this.luoiPQ.Size = new System.Drawing.Size(476, 210);
            this.luoiPQ.TabIndex = 55;
            this.luoiPQ.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.luoiPQ_CellContentClick);
            this.luoiPQ.Click += new System.EventHandler(this.luoiPQ_Click);
            // 
            // pnlPQ
            // 
            this.pnlPQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPQ.Controls.Add(this.cmbUSER);
            this.pnlPQ.Controls.Add(this.cmbCN);
            this.pnlPQ.Controls.Add(this.label3);
            this.pnlPQ.Controls.Add(this.txtIDPQ);
            this.pnlPQ.Controls.Add(this.label2);
            this.pnlPQ.Controls.Add(this.label1);
            this.pnlPQ.Location = new System.Drawing.Point(17, 85);
            this.pnlPQ.Name = "pnlPQ";
            this.pnlPQ.Size = new System.Drawing.Size(649, 98);
            this.pnlPQ.TabIndex = 50;
            // 
            // cmbUSER
            // 
            this.cmbUSER.FormattingEnabled = true;
            this.cmbUSER.Location = new System.Drawing.Point(500, 14);
            this.cmbUSER.Name = "cmbUSER";
            this.cmbUSER.Size = new System.Drawing.Size(128, 21);
            this.cmbUSER.TabIndex = 38;
            this.cmbUSER.SelectedIndexChanged += new System.EventHandler(this.cmbUSER_SelectedIndexChanged);
            // 
            // cmbCN
            // 
            this.cmbCN.FormattingEnabled = true;
            this.cmbCN.Location = new System.Drawing.Point(156, 58);
            this.cmbCN.Name = "cmbCN";
            this.cmbCN.Size = new System.Drawing.Size(472, 21);
            this.cmbCN.TabIndex = 30;
            this.cmbCN.SelectedIndexChanged += new System.EventHandler(this.cmbCN_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "TÊN ĐĂNG NHẬP";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtIDPQ
            // 
            this.txtIDPQ.Location = new System.Drawing.Point(156, 15);
            this.txtIDPQ.Multiline = true;
            this.txtIDPQ.Name = "txtIDPQ";
            this.txtIDPQ.Size = new System.Drawing.Size(134, 20);
            this.txtIDPQ.TabIndex = 27;
            this.txtIDPQ.TextChanged += new System.EventHandler(this.txtIDPQ_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "CHỨC NĂNG";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "ID PHÂN QUYỀN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTIMKIEM
            // 
            this.txtTIMKIEM.Location = new System.Drawing.Point(198, 33);
            this.txtTIMKIEM.Multiline = true;
            this.txtTIMKIEM.Name = "txtTIMKIEM";
            this.txtTIMKIEM.Size = new System.Drawing.Size(304, 41);
            this.txtTIMKIEM.TabIndex = 53;
            this.txtTIMKIEM.Enter += new System.EventHandler(this.txtTIMKIEM_Enter);
            this.txtTIMKIEM.Leave += new System.EventHandler(this.txtTIMKIEM_Leave);
            // 
            // btnHUY
            // 
            this.btnHUY.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHUY.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._192;
            this.btnHUY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHUY.Location = new System.Drawing.Point(591, 447);
            this.btnHUY.Name = "btnHUY";
            this.btnHUY.Size = new System.Drawing.Size(75, 31);
            this.btnHUY.TabIndex = 60;
            this.btnHUY.Text = "HỦY";
            this.btnHUY.UseVisualStyleBackColor = false;
            this.btnHUY.Click += new System.EventHandler(this.btnHUY_Click);
            // 
            // btnLUU
            // 
            this.btnLUU.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLUU.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._181;
            this.btnLUU.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLUU.Location = new System.Drawing.Point(366, 447);
            this.btnLUU.Name = "btnLUU";
            this.btnLUU.Size = new System.Drawing.Size(75, 31);
            this.btnLUU.TabIndex = 59;
            this.btnLUU.Text = "LƯU";
            this.btnLUU.UseVisualStyleBackColor = false;
            this.btnLUU.Click += new System.EventHandler(this.btnLUU_Click);
            // 
            // btnSUA
            // 
            this.btnSUA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSUA.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._1711;
            this.btnSUA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSUA.Location = new System.Drawing.Point(254, 447);
            this.btnSUA.Name = "btnSUA";
            this.btnSUA.Size = new System.Drawing.Size(75, 31);
            this.btnSUA.TabIndex = 58;
            this.btnSUA.Text = "SỬA";
            this.btnSUA.UseVisualStyleBackColor = false;
            this.btnSUA.Click += new System.EventHandler(this.btnSUA_Click);
            // 
            // btnXOA
            // 
            this.btnXOA.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXOA.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._16;
            this.btnXOA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXOA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXOA.Location = new System.Drawing.Point(139, 447);
            this.btnXOA.Name = "btnXOA";
            this.btnXOA.Size = new System.Drawing.Size(75, 31);
            this.btnXOA.TabIndex = 57;
            this.btnXOA.Text = "XÓA";
            this.btnXOA.UseVisualStyleBackColor = false;
            this.btnXOA.Click += new System.EventHandler(this.btnXOA_Click);
            // 
            // btnTHEM
            // 
            this.btnTHEM.BackColor = System.Drawing.Color.Transparent;
            this.btnTHEM.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._15;
            this.btnTHEM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTHEM.CausesValidation = false;
            this.btnTHEM.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTHEM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHEM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTHEM.Location = new System.Drawing.Point(17, 447);
            this.btnTHEM.Name = "btnTHEM";
            this.btnTHEM.Size = new System.Drawing.Size(75, 31);
            this.btnTHEM.TabIndex = 56;
            this.btnTHEM.Text = "THÊM";
            this.btnTHEM.UseVisualStyleBackColor = false;
            this.btnTHEM.Click += new System.EventHandler(this.btnTHEM_Click);
            // 
            // btnRESET
            // 
            this.btnRESET.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRESET.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._21;
            this.btnRESET.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRESET.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRESET.Location = new System.Drawing.Point(478, 447);
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Size = new System.Drawing.Size(75, 31);
            this.btnRESET.TabIndex = 54;
            this.btnRESET.Text = "RESET";
            this.btnRESET.UseVisualStyleBackColor = false;
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label4.Location = new System.Drawing.Point(29, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "TÌM TÀI KHOẢN";
            // 
            // btnTIM
            // 
            this.btnTIM.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTIM.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources.Untitled_2w;
            this.btnTIM.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTIM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTIM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTIM.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources.Untitled_2w;
            this.btnTIM.Location = new System.Drawing.Point(459, 38);
            this.btnTIM.Name = "btnTIM";
            this.btnTIM.Size = new System.Drawing.Size(34, 29);
            this.btnTIM.TabIndex = 52;
            this.btnTIM.UseVisualStyleBackColor = false;
            this.btnTIM.Click += new System.EventHandler(this.btnTIM_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(-358, -32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1344, 669);
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // listcbPQ
            // 
            this.listcbPQ.Enabled = false;
            this.listcbPQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listcbPQ.FormattingEnabled = true;
            this.listcbPQ.Items.AddRange(new object[] {
            "QL Tài Khoản",
            "QL Chức Năng",
            "Phân Quyền",
            "QL Chất Liệu",
            "QL Mặt Hàng",
            "QL Nhân Viên",
            "QL Khách Hàng",
            "QL Hóa Đơn",
            "Chi Tiết Hóa Đơn",
            "Tìm Kiếm",
            "Báo Cáo"});
            this.listcbPQ.Location = new System.Drawing.Point(505, 227);
            this.listcbPQ.Name = "listcbPQ";
            this.listcbPQ.Size = new System.Drawing.Size(161, 191);
            this.listcbPQ.TabIndex = 62;
            // 
            // txtUSER
            // 
            this.txtUSER.Enabled = false;
            this.txtUSER.Location = new System.Drawing.Point(505, 208);
            this.txtUSER.Multiline = true;
            this.txtUSER.Name = "txtUSER";
            this.txtUSER.Size = new System.Drawing.Size(161, 20);
            this.txtUSER.TabIndex = 63;
            // 
            // frmPHANQUYEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 513);
            this.Controls.Add(this.txtUSER);
            this.Controls.Add(this.listcbPQ);
            this.Controls.Add(this.btnHUY);
            this.Controls.Add(this.btnLUU);
            this.Controls.Add(this.btnSUA);
            this.Controls.Add(this.btnXOA);
            this.Controls.Add(this.btnTHEM);
            this.Controls.Add(this.luoiPQ);
            this.Controls.Add(this.btnRESET);
            this.Controls.Add(this.pnlPQ);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTIM);
            this.Controls.Add(this.txtTIMKIEM);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPHANQUYEN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPHANQUYEN";
            this.Load += new System.EventHandler(this.frmPHANQUYEN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luoiPQ)).EndInit();
            this.pnlPQ.ResumeLayout(false);
            this.pnlPQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHUY;
        private System.Windows.Forms.Button btnLUU;
        private System.Windows.Forms.Button btnSUA;
        private System.Windows.Forms.Button btnXOA;
        private System.Windows.Forms.Button btnTHEM;
        private System.Windows.Forms.DataGridView luoiPQ;
        private System.Windows.Forms.Button btnRESET;
        private System.Windows.Forms.Panel pnlPQ;
        private System.Windows.Forms.ComboBox cmbUSER;
        private System.Windows.Forms.ComboBox cmbCN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDPQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTIMKIEM;
        private System.Windows.Forms.Button btnTIM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckedListBox listcbPQ;
        private System.Windows.Forms.TextBox txtUSER;

    }
}