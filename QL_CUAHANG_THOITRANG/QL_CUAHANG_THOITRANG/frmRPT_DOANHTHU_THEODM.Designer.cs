namespace QL_CUAHANG_THOITRANG
{
    partial class frmRPT_DOANHTHU_THEODM
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
            this.DOANHTHU_THEODMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_CUAHANG_THOITRANGDataSet = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDM = new System.Windows.Forms.ComboBox();
            this.cbALL = new System.Windows.Forms.CheckBox();
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.btnTAIBC = new System.Windows.Forms.Button();
            this.btnINBC = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DOANHTHU_THEODMTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEODMTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEODMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DOANHTHU_THEODMBindingSource
            // 
            this.DOANHTHU_THEODMBindingSource.DataMember = "DOANHTHU_THEODM";
            this.DOANHTHU_THEODMBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
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
            this.label1.Location = new System.Drawing.Point(16, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Chọn danh mục";
            // 
            // cmbDM
            // 
            this.cmbDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDM.FormattingEnabled = true;
            this.cmbDM.Location = new System.Drawing.Point(148, 63);
            this.cmbDM.Name = "cmbDM";
            this.cmbDM.Size = new System.Drawing.Size(136, 28);
            this.cmbDM.TabIndex = 29;
            // 
            // cbALL
            // 
            this.cbALL.AutoSize = true;
            this.cbALL.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.cbALL.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALL.Location = new System.Drawing.Point(295, 67);
            this.cbALL.Name = "cbALL";
            this.cbALL.Size = new System.Drawing.Size(152, 22);
            this.cbALL.TabIndex = 28;
            this.cbALL.Text = "Tất cả danh mục";
            this.cbALL.UseVisualStyleBackColor = true;
            this.cbALL.CheckedChanged += new System.EventHandler(this.cbALL_CheckedChanged);
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTHOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHOAT.Location = new System.Drawing.Point(308, 10);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(123, 31);
            this.btnTHOAT.TabIndex = 27;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = false;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // btnTAIBC
            // 
            this.btnTAIBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTAIBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAIBC.Location = new System.Drawing.Point(170, 10);
            this.btnTAIBC.Name = "btnTAIBC";
            this.btnTAIBC.Size = new System.Drawing.Size(123, 31);
            this.btnTAIBC.TabIndex = 26;
            this.btnTAIBC.Text = "TẢI BÁO CÁO";
            this.btnTAIBC.UseVisualStyleBackColor = false;
            this.btnTAIBC.Click += new System.EventHandler(this.btnTAIBC_Click);
            // 
            // btnINBC
            // 
            this.btnINBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnINBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINBC.Location = new System.Drawing.Point(20, 10);
            this.btnINBC.Name = "btnINBC";
            this.btnINBC.Size = new System.Drawing.Size(135, 31);
            this.btnINBC.TabIndex = 25;
            this.btnINBC.Text = "IN BÁO CÁO";
            this.btnINBC.UseVisualStyleBackColor = false;
            this.btnINBC.Click += new System.EventHandler(this.btnINBC_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetDT_DM";
            reportDataSource1.Value = this.DOANHTHU_THEODMBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_CUAHANG_THOITRANG.rpt_DOANHTHU_THEODM.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(17, 101);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(517, 362);
            this.reportViewer1.TabIndex = 24;
            // 
            // DOANHTHU_THEODMTableAdapter
            // 
            this.DOANHTHU_THEODMTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(553, 485);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // frmRPT_DOANHTHU_THEODM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 480);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDM);
            this.Controls.Add(this.cbALL);
            this.Controls.Add(this.btnTHOAT);
            this.Controls.Add(this.btnTAIBC);
            this.Controls.Add(this.btnINBC);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRPT_DOANHTHU_THEODM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu theo DMSP";
            this.Load += new System.EventHandler(this.frmRPT_DOANHTHU_THEODM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEODMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDM;
        private System.Windows.Forms.CheckBox cbALL;
        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.Button btnTAIBC;
        private System.Windows.Forms.Button btnINBC;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DOANHTHU_THEODMBindingSource;
        private QL_CUAHANG_THOITRANGDataSet QL_CUAHANG_THOITRANGDataSet;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEODMTableAdapter DOANHTHU_THEODMTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}