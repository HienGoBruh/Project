namespace QL_CUAHANG_THOITRANG
{
    partial class frmDANHMUCSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDANHMUCSP));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDDM = new System.Windows.Forms.TextBox();
            this.txtTENDM = new System.Windows.Forms.TextBox();
            this.luoiDM = new System.Windows.Forms.DataGridView();
            this.btnTHEM = new System.Windows.Forms.Button();
            this.btnXOA = new System.Windows.Forms.Button();
            this.btnSUA = new System.Windows.Forms.Button();
            this.btnLUU = new System.Windows.Forms.Button();
            this.btnHUY = new System.Windows.Forms.Button();
            this.pnlDM = new System.Windows.Forms.Panel();
            this.btnRESET = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTIMKIEM = new System.Windows.Forms.TextBox();
            this.btnTIM = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.luoiDM)).BeginInit();
            this.pnlDM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(46, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID DANH MỤC";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(42, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "TÊN DANH MỤC";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtIDDM
            // 
            this.txtIDDM.Location = new System.Drawing.Point(17, 14);
            this.txtIDDM.Multiline = true;
            this.txtIDDM.Name = "txtIDDM";
            this.txtIDDM.Size = new System.Drawing.Size(276, 22);
            this.txtIDDM.TabIndex = 2;
            // 
            // txtTENDM
            // 
            this.txtTENDM.Location = new System.Drawing.Point(16, 52);
            this.txtTENDM.Multiline = true;
            this.txtTENDM.Name = "txtTENDM";
            this.txtTENDM.Size = new System.Drawing.Size(276, 22);
            this.txtTENDM.TabIndex = 3;
            // 
            // luoiDM
            // 
            this.luoiDM.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.luoiDM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.luoiDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.luoiDM.GridColor = System.Drawing.Color.Gainsboro;
            this.luoiDM.Location = new System.Drawing.Point(43, 189);
            this.luoiDM.Name = "luoiDM";
            this.luoiDM.Size = new System.Drawing.Size(465, 173);
            this.luoiDM.TabIndex = 4;
            this.luoiDM.Click += new System.EventHandler(this.luoiDM_Click);
            // 
            // btnTHEM
            // 
            this.btnTHEM.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTHEM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTHEM.CausesValidation = false;
            this.btnTHEM.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTHEM.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHEM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTHEM.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._15;
            this.btnTHEM.Location = new System.Drawing.Point(528, 32);
            this.btnTHEM.Name = "btnTHEM";
            this.btnTHEM.Size = new System.Drawing.Size(73, 36);
            this.btnTHEM.TabIndex = 5;
            this.btnTHEM.Text = "THÊM";
            this.btnTHEM.UseVisualStyleBackColor = false;
            this.btnTHEM.Click += new System.EventHandler(this.btnTHEM_Click);
            // 
            // btnXOA
            // 
            this.btnXOA.BackColor = System.Drawing.Color.Gainsboro;
            this.btnXOA.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXOA.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._16;
            this.btnXOA.Location = new System.Drawing.Point(528, 78);
            this.btnXOA.Name = "btnXOA";
            this.btnXOA.Size = new System.Drawing.Size(73, 36);
            this.btnXOA.TabIndex = 6;
            this.btnXOA.Text = "XÓA";
            this.btnXOA.UseVisualStyleBackColor = false;
            this.btnXOA.Click += new System.EventHandler(this.btnXOA_Click);
            // 
            // btnSUA
            // 
            this.btnSUA.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSUA.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSUA.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._1711;
            this.btnSUA.Location = new System.Drawing.Point(530, 133);
            this.btnSUA.Name = "btnSUA";
            this.btnSUA.Size = new System.Drawing.Size(71, 36);
            this.btnSUA.TabIndex = 7;
            this.btnSUA.Text = "SỬA";
            this.btnSUA.UseVisualStyleBackColor = false;
            this.btnSUA.Click += new System.EventHandler(this.btnSUA_Click);
            // 
            // btnLUU
            // 
            this.btnLUU.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLUU.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLUU.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._181;
            this.btnLUU.Location = new System.Drawing.Point(530, 184);
            this.btnLUU.Name = "btnLUU";
            this.btnLUU.Size = new System.Drawing.Size(71, 36);
            this.btnLUU.TabIndex = 8;
            this.btnLUU.Text = "LƯU";
            this.btnLUU.UseVisualStyleBackColor = false;
            this.btnLUU.Click += new System.EventHandler(this.btnLUU_Click);
            // 
            // btnHUY
            // 
            this.btnHUY.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHUY.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHUY.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._191;
            this.btnHUY.Location = new System.Drawing.Point(530, 238);
            this.btnHUY.Name = "btnHUY";
            this.btnHUY.Size = new System.Drawing.Size(72, 36);
            this.btnHUY.TabIndex = 9;
            this.btnHUY.Text = "HỦY";
            this.btnHUY.UseVisualStyleBackColor = false;
            this.btnHUY.BackgroundImageChanged += new System.EventHandler(this.btnHUY_BackgroundImageChanged);
            this.btnHUY.Click += new System.EventHandler(this.btnHUY_Click);
            // 
            // pnlDM
            // 
            this.pnlDM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDM.Controls.Add(this.txtTENDM);
            this.pnlDM.Controls.Add(this.txtIDDM);
            this.pnlDM.Location = new System.Drawing.Point(198, 88);
            this.pnlDM.Name = "pnlDM";
            this.pnlDM.Size = new System.Drawing.Size(309, 89);
            this.pnlDM.TabIndex = 10;
            // 
            // btnRESET
            // 
            this.btnRESET.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRESET.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRESET.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources.reset;
            this.btnRESET.Location = new System.Drawing.Point(444, 32);
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Size = new System.Drawing.Size(61, 31);
            this.btnRESET.TabIndex = 43;
            this.btnRESET.UseVisualStyleBackColor = false;
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(46, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 40;
            this.label4.Text = "TÌM DANH MỤC";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtTIMKIEM
            // 
            this.txtTIMKIEM.Location = new System.Drawing.Point(197, 32);
            this.txtTIMKIEM.Multiline = true;
            this.txtTIMKIEM.Name = "txtTIMKIEM";
            this.txtTIMKIEM.Size = new System.Drawing.Size(162, 30);
            this.txtTIMKIEM.TabIndex = 42;
            this.txtTIMKIEM.Enter += new System.EventHandler(this.txtTIMKIEM_Enter);
            this.txtTIMKIEM.Leave += new System.EventHandler(this.txtTIMKIEM_Leave);
            // 
            // btnTIM
            // 
            this.btnTIM.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTIM.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTIM.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources.tim4;
            this.btnTIM.Location = new System.Drawing.Point(378, 32);
            this.btnTIM.Name = "btnTIM";
            this.btnTIM.Size = new System.Drawing.Size(61, 31);
            this.btnTIM.TabIndex = 41;
            this.btnTIM.UseVisualStyleBackColor = false;
            this.btnTIM.Click += new System.EventHandler(this.btnTIM_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(715, 406);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // frmDANHMUCSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(625, 400);
            this.Controls.Add(this.btnRESET);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTIMKIEM);
            this.Controls.Add(this.btnTIM);
            this.Controls.Add(this.pnlDM);
            this.Controls.Add(this.btnHUY);
            this.Controls.Add(this.btnLUU);
            this.Controls.Add(this.btnSUA);
            this.Controls.Add(this.btnXOA);
            this.Controls.Add(this.btnTHEM);
            this.Controls.Add(this.luoiDM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDANHMUCSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDANHMUCSP";
            this.Load += new System.EventHandler(this.frmDANHMUCSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luoiDM)).EndInit();
            this.pnlDM.ResumeLayout(false);
            this.pnlDM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDDM;
        private System.Windows.Forms.TextBox txtTENDM;
        private System.Windows.Forms.DataGridView luoiDM;
        private System.Windows.Forms.Button btnTHEM;
        private System.Windows.Forms.Button btnXOA;
        private System.Windows.Forms.Button btnSUA;
        private System.Windows.Forms.Button btnLUU;
        private System.Windows.Forms.Button btnHUY;
        private System.Windows.Forms.Panel pnlDM;
        private System.Windows.Forms.Button btnRESET;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTIMKIEM;
        private System.Windows.Forms.Button btnTIM;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}