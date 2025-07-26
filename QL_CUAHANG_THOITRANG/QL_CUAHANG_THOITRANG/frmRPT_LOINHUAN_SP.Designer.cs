namespace QL_CUAHANG_THOITRANG
{
    partial class frmRPT_LOINHUAN_SP
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.LOINHUAN_THEOSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_CUAHANG_THOITRANGDataSet = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSP = new System.Windows.Forms.ComboBox();
            this.cbALL = new System.Windows.Forms.CheckBox();
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.btnTAIBC = new System.Windows.Forms.Button();
            this.btnINBC = new System.Windows.Forms.Button();
            this.LOINHUAN_THEOSPTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.LOINHUAN_THEOSPTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.LOINHUAN_THEOSPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LOINHUAN_THEOSPBindingSource
            // 
            this.LOINHUAN_THEOSPBindingSource.DataMember = "LOINHUAN_THEOSP";
            this.LOINHUAN_THEOSPBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // QL_CUAHANG_THOITRANGDataSet
            // 
            this.QL_CUAHANG_THOITRANGDataSet.DataSetName = "QL_CUAHANG_THOITRANGDataSet";
            this.QL_CUAHANG_THOITRANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "Chọn sản phẩm";
            // 
            // cmbSP
            // 
            this.cmbSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSP.FormattingEnabled = true;
            this.cmbSP.Location = new System.Drawing.Point(163, 58);
            this.cmbSP.Name = "cmbSP";
            this.cmbSP.Size = new System.Drawing.Size(176, 28);
            this.cmbSP.TabIndex = 36;
            // 
            // cbALL
            // 
            this.cbALL.AutoSize = true;
            this.cbALL.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.cbALL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALL.Location = new System.Drawing.Point(357, 60);
            this.cbALL.Name = "cbALL";
            this.cbALL.Size = new System.Drawing.Size(152, 22);
            this.cbALL.TabIndex = 35;
            this.cbALL.Text = "Tất cả sản phẩm";
            this.cbALL.UseVisualStyleBackColor = true;
            this.cbALL.CheckedChanged += new System.EventHandler(this.cbALL_CheckedChanged);
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTHOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHOAT.Location = new System.Drawing.Point(300, 18);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(123, 31);
            this.btnTHOAT.TabIndex = 34;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = false;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // btnTAIBC
            // 
            this.btnTAIBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTAIBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAIBC.Location = new System.Drawing.Point(163, 17);
            this.btnTAIBC.Name = "btnTAIBC";
            this.btnTAIBC.Size = new System.Drawing.Size(123, 31);
            this.btnTAIBC.TabIndex = 33;
            this.btnTAIBC.Text = "TẢI BÁO CÁO";
            this.btnTAIBC.UseVisualStyleBackColor = false;
            this.btnTAIBC.Click += new System.EventHandler(this.btnTAIBC_Click);
            // 
            // btnINBC
            // 
            this.btnINBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnINBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINBC.Location = new System.Drawing.Point(12, 17);
            this.btnINBC.Name = "btnINBC";
            this.btnINBC.Size = new System.Drawing.Size(135, 31);
            this.btnINBC.TabIndex = 32;
            this.btnINBC.Text = "IN BÁO CÁO";
            this.btnINBC.UseVisualStyleBackColor = false;
            this.btnINBC.Click += new System.EventHandler(this.btnINBC_Click);
            // 
            // LOINHUAN_THEOSPTableAdapter
            // 
            this.LOINHUAN_THEOSPTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(826, 461);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetLN_SP";
            reportDataSource1.Value = this.LOINHUAN_THEOSPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_CUAHANG_THOITRANG.rpt_LOINHUAN_SP.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 92);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(826, 362);
            this.reportViewer1.TabIndex = 39;
            // 
            // frmRPT_LOINHUAN_SP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 458);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSP);
            this.Controls.Add(this.cbALL);
            this.Controls.Add(this.btnTHOAT);
            this.Controls.Add(this.btnTAIBC);
            this.Controls.Add(this.btnINBC);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRPT_LOINHUAN_SP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lợi nhuận theo sản phẩm";
            this.Load += new System.EventHandler(this.frmRPT_LOINHUAN_SP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LOINHUAN_THEOSPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSP;
        private System.Windows.Forms.CheckBox cbALL;
        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.Button btnTAIBC;
        private System.Windows.Forms.Button btnINBC;
        private System.Windows.Forms.BindingSource LOINHUAN_THEOSPBindingSource;
        private QL_CUAHANG_THOITRANGDataSet QL_CUAHANG_THOITRANGDataSet;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.LOINHUAN_THEOSPTableAdapter LOINHUAN_THEOSPTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}