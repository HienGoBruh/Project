namespace QL_CUAHANG_THOITRANG
{
    partial class frmRPT_HOADONBAN_KH
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKH = new System.Windows.Forms.ComboBox();
            this.cbALL = new System.Windows.Forms.CheckBox();
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.btnTAIBC = new System.Windows.Forms.Button();
            this.btnINBC = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DOANHTHU_THEOSPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_CUAHANG_THOITRANGDataSet = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSet();
            this.DOANHTHU_THEOSPTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEOSPTableAdapter();
            this.HOADONBAN_KHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HOADONBAN_KHTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.HOADONBAN_KHTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEOSPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBAN_KHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(-7, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(711, 519);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.label1.Location = new System.Drawing.Point(8, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Chọn Khách Hàng";
            // 
            // cmbKH
            // 
            this.cmbKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKH.FormattingEnabled = true;
            this.cmbKH.Location = new System.Drawing.Point(159, 90);
            this.cmbKH.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cmbKH.Name = "cmbKH";
            this.cmbKH.Size = new System.Drawing.Size(273, 28);
            this.cmbKH.TabIndex = 37;
            // 
            // cbALL
            // 
            this.cbALL.AutoSize = true;
            this.cbALL.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.cbALL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALL.Location = new System.Drawing.Point(444, 94);
            this.cbALL.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cbALL.Name = "cbALL";
            this.cbALL.Size = new System.Drawing.Size(165, 22);
            this.cbALL.TabIndex = 36;
            this.cbALL.Text = "Tất cả khách hàng";
            this.cbALL.UseVisualStyleBackColor = true;
            this.cbALL.CheckedChanged += new System.EventHandler(this.cbALL_CheckedChanged);
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTHOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHOAT.Location = new System.Drawing.Point(434, 3);
            this.btnTHOAT.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(162, 38);
            this.btnTHOAT.TabIndex = 35;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = false;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // btnTAIBC
            // 
            this.btnTAIBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTAIBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAIBC.Location = new System.Drawing.Point(235, 3);
            this.btnTAIBC.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTAIBC.Name = "btnTAIBC";
            this.btnTAIBC.Size = new System.Drawing.Size(162, 38);
            this.btnTAIBC.TabIndex = 34;
            this.btnTAIBC.Text = "TẢI BÁO CÁO";
            this.btnTAIBC.UseVisualStyleBackColor = false;
            this.btnTAIBC.Click += new System.EventHandler(this.btnTAIBC_Click);
            // 
            // btnINBC
            // 
            this.btnINBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnINBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINBC.Location = new System.Drawing.Point(14, 3);
            this.btnINBC.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnINBC.Name = "btnINBC";
            this.btnINBC.Size = new System.Drawing.Size(184, 38);
            this.btnINBC.TabIndex = 33;
            this.btnINBC.Text = "IN BÁO CÁO";
            this.btnINBC.UseVisualStyleBackColor = false;
            this.btnINBC.Click += new System.EventHandler(this.btnINBC_Click);
            // 
            // reportViewer1
            // 
            reportDataSource5.Name = "DataSetHDB_KH";
            reportDataSource5.Value = this.HOADONBAN_KHBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_CUAHANG_THOITRANG.rpt_HOADONBAN_KH.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-4, 141);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(708, 358);
            this.reportViewer1.TabIndex = 32;
            // 
            // DOANHTHU_THEOSPBindingSource
            // 
            this.DOANHTHU_THEOSPBindingSource.DataMember = "DOANHTHU_THEOSP";
            this.DOANHTHU_THEOSPBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // QL_CUAHANG_THOITRANGDataSet
            // 
            this.QL_CUAHANG_THOITRANGDataSet.DataSetName = "QL_CUAHANG_THOITRANGDataSet";
            this.QL_CUAHANG_THOITRANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DOANHTHU_THEOSPTableAdapter
            // 
            this.DOANHTHU_THEOSPTableAdapter.ClearBeforeFill = true;
            // 
            // HOADONBAN_KHBindingSource
            // 
            this.HOADONBAN_KHBindingSource.DataMember = "HOADONBAN_KH";
            this.HOADONBAN_KHBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // HOADONBAN_KHTableAdapter
            // 
            this.HOADONBAN_KHTableAdapter.ClearBeforeFill = true;
            // 
            // frmRPT_HOADONBAN_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 505);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKH);
            this.Controls.Add(this.cbALL);
            this.Controls.Add(this.btnTHOAT);
            this.Controls.Add(this.btnTAIBC);
            this.Controls.Add(this.btnINBC);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRPT_HOADONBAN_KH";
            this.Text = "frmRPT_HOADONBAN_KH";
            this.Load += new System.EventHandler(this.frmRPT_HOADONBAN_KH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEOSPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBAN_KHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource DOANHTHU_THEOSPBindingSource;
        private QL_CUAHANG_THOITRANGDataSet QL_CUAHANG_THOITRANGDataSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKH;
        private System.Windows.Forms.CheckBox cbALL;
        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.Button btnTAIBC;
        private System.Windows.Forms.Button btnINBC;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEOSPTableAdapter DOANHTHU_THEOSPTableAdapter;
        private System.Windows.Forms.BindingSource HOADONBAN_KHBindingSource;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.HOADONBAN_KHTableAdapter HOADONBAN_KHTableAdapter;
    }
}