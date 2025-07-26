namespace QL_CUAHANG_THOITRANG
{
    partial class frmRPT_DOANHTHU_THEONV
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
            this.DOANHTHU_THEONVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_CUAHANG_THOITRANGDataSet = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSet();
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.btnTAIBC = new System.Windows.Forms.Button();
            this.btnINBC = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbALLNV = new System.Windows.Forms.CheckBox();
            this.cmbNV = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DOANHTHU_THEONVTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEONVTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEONVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DOANHTHU_THEONVBindingSource
            // 
            this.DOANHTHU_THEONVBindingSource.DataMember = "DOANHTHU_THEONV";
            this.DOANHTHU_THEONVBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // QL_CUAHANG_THOITRANGDataSet
            // 
            this.QL_CUAHANG_THOITRANGDataSet.DataSetName = "QL_CUAHANG_THOITRANGDataSet";
            this.QL_CUAHANG_THOITRANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTHOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHOAT.Location = new System.Drawing.Point(370, 22);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(123, 31);
            this.btnTHOAT.TabIndex = 19;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = false;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // btnTAIBC
            // 
            this.btnTAIBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTAIBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAIBC.Location = new System.Drawing.Point(232, 22);
            this.btnTAIBC.Name = "btnTAIBC";
            this.btnTAIBC.Size = new System.Drawing.Size(123, 31);
            this.btnTAIBC.TabIndex = 17;
            this.btnTAIBC.Text = "TẢI BÁO CÁO";
            this.btnTAIBC.UseVisualStyleBackColor = false;
            this.btnTAIBC.Click += new System.EventHandler(this.btnTAIBC_Click);
            // 
            // btnINBC
            // 
            this.btnINBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnINBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINBC.Location = new System.Drawing.Point(82, 22);
            this.btnINBC.Name = "btnINBC";
            this.btnINBC.Size = new System.Drawing.Size(135, 31);
            this.btnINBC.TabIndex = 16;
            this.btnINBC.Text = "IN BÁO CÁO";
            this.btnINBC.UseVisualStyleBackColor = false;
            this.btnINBC.Click += new System.EventHandler(this.btnINBC_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetDT_THEONV";
            reportDataSource1.Value = this.DOANHTHU_THEONVBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_CUAHANG_THOITRANG.rpt_DOANHTHU_THEONV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 117);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(546, 362);
            this.reportViewer1.TabIndex = 15;
            // 
            // cbALLNV
            // 
            this.cbALLNV.AutoSize = true;
            this.cbALLNV.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.cbALLNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALLNV.Location = new System.Drawing.Point(387, 77);
            this.cbALLNV.Name = "cbALLNV";
            this.cbALLNV.Size = new System.Drawing.Size(150, 22);
            this.cbALLNV.TabIndex = 20;
            this.cbALLNV.Text = "Tất cả nhân viên";
            this.cbALLNV.UseVisualStyleBackColor = true;
            this.cbALLNV.CheckedChanged += new System.EventHandler(this.cbALLNV_CheckedChanged);
            // 
            // cmbNV
            // 
            this.cmbNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNV.FormattingEnabled = true;
            this.cmbNV.Location = new System.Drawing.Point(228, 76);
            this.cmbNV.Name = "cmbNV";
            this.cmbNV.Size = new System.Drawing.Size(136, 28);
            this.cmbNV.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label1.Location = new System.Drawing.Point(56, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Chọn nhân viên";
            // 
            // DOANHTHU_THEONVTableAdapter
            // 
            this.DOANHTHU_THEONVTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(587, 518);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // frmRPT_DOANHTHU_THEONV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 513);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNV);
            this.Controls.Add(this.cbALLNV);
            this.Controls.Add(this.btnTHOAT);
            this.Controls.Add(this.btnTAIBC);
            this.Controls.Add(this.btnINBC);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRPT_DOANHTHU_THEONV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu theo nhân viên";
            this.Load += new System.EventHandler(this.frmRPT_DOANHTHU_THEONV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEONVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.Button btnTAIBC;
        private System.Windows.Forms.Button btnINBC;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DOANHTHU_THEONVBindingSource;
        private QL_CUAHANG_THOITRANGDataSet QL_CUAHANG_THOITRANGDataSet;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEONVTableAdapter DOANHTHU_THEONVTableAdapter;
        private System.Windows.Forms.CheckBox cbALLNV;
        private System.Windows.Forms.ComboBox cmbNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}