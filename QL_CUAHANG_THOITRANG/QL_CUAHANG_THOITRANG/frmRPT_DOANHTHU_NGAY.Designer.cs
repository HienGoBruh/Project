namespace QL_CUAHANG_THOITRANG
{
    partial class frmRPT_DOANHTHU_NGAY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPT_DOANHTHU_NGAY));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DOANHTHU_THEONGAYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_CUAHANG_THOITRANGDataSet = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSet();
            this.dtpTUNGAY = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDENNGAY = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DOANHTHU_THEONGAYTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEONGAYTableAdapter();
            this.btnINBC = new System.Windows.Forms.Button();
            this.btnTAIBC = new System.Windows.Forms.Button();
            this.cbALLTIME = new System.Windows.Forms.CheckBox();
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEONGAYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DOANHTHU_THEONGAYBindingSource
            // 
            this.DOANHTHU_THEONGAYBindingSource.DataMember = "DOANHTHU_THEONGAY";
            this.DOANHTHU_THEONGAYBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // QL_CUAHANG_THOITRANGDataSet
            // 
            this.QL_CUAHANG_THOITRANGDataSet.DataSetName = "QL_CUAHANG_THOITRANGDataSet";
            this.QL_CUAHANG_THOITRANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpTUNGAY
            // 
            this.dtpTUNGAY.CustomFormat = "yyyy/MM/dd";
            this.dtpTUNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTUNGAY.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTUNGAY.Location = new System.Drawing.Point(132, 63);
            this.dtpTUNGAY.Name = "dtpTUNGAY";
            this.dtpTUNGAY.Size = new System.Drawing.Size(103, 26);
            this.dtpTUNGAY.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Montserrat Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(33, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "TỪ NGÀY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Montserrat Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(248, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "ĐẾN NGÀY";
            // 
            // dtpDENNGAY
            // 
            this.dtpDENNGAY.CustomFormat = "yyyy/MM/dd";
            this.dtpDENNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDENNGAY.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDENNGAY.Location = new System.Drawing.Point(361, 63);
            this.dtpDENNGAY.Name = "dtpDENNGAY";
            this.dtpDENNGAY.Size = new System.Drawing.Size(109, 26);
            this.dtpDENNGAY.TabIndex = 4;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DOANHTHU_THEONGAYBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_CUAHANG_THOITRANG.rpt_DOANHTHU_THEONGAY.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 102);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(747, 377);
            this.reportViewer1.TabIndex = 6;
            // 
            // DOANHTHU_THEONGAYTableAdapter
            // 
            this.DOANHTHU_THEONGAYTableAdapter.ClearBeforeFill = true;
            // 
            // btnINBC
            // 
            this.btnINBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnINBC.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINBC.Location = new System.Drawing.Point(37, 12);
            this.btnINBC.Name = "btnINBC";
            this.btnINBC.Size = new System.Drawing.Size(135, 31);
            this.btnINBC.TabIndex = 7;
            this.btnINBC.Text = "IN BÁO CÁO";
            this.btnINBC.UseVisualStyleBackColor = false;
            this.btnINBC.Click += new System.EventHandler(this.btnINBC_Click);
            // 
            // btnTAIBC
            // 
            this.btnTAIBC.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTAIBC.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAIBC.Location = new System.Drawing.Point(187, 12);
            this.btnTAIBC.Name = "btnTAIBC";
            this.btnTAIBC.Size = new System.Drawing.Size(123, 31);
            this.btnTAIBC.TabIndex = 8;
            this.btnTAIBC.Text = "TẢI BÁO CÁO";
            this.btnTAIBC.UseVisualStyleBackColor = false;
            this.btnTAIBC.Click += new System.EventHandler(this.btnTAIBC_Click);
            // 
            // cbALLTIME
            // 
            this.cbALLTIME.AutoSize = true;
            this.cbALLTIME.BackColor = System.Drawing.Color.LightGray;
            this.cbALLTIME.BackgroundImage = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.cbALLTIME.Font = new System.Drawing.Font("Montserrat Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALLTIME.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbALLTIME.Location = new System.Drawing.Point(483, 65);
            this.cbALLTIME.Name = "cbALLTIME";
            this.cbALLTIME.Size = new System.Drawing.Size(183, 26);
            this.cbALLTIME.TabIndex = 9;
            this.cbALLTIME.Text = "Từ trước đến nay";
            this.cbALLTIME.UseVisualStyleBackColor = false;
            this.cbALLTIME.CheckedChanged += new System.EventHandler(this.cbALLTIME_CheckedChanged);
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTHOAT.Font = new System.Drawing.Font("Montserrat Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHOAT.Location = new System.Drawing.Point(325, 12);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(123, 31);
            this.btnTHOAT.TabIndex = 10;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = false;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(755, 490);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // frmRPT_DOANHTHU_NGAY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 481);
            this.Controls.Add(this.btnTHOAT);
            this.Controls.Add(this.cbALLTIME);
            this.Controls.Add(this.btnTAIBC);
            this.Controls.Add(this.btnINBC);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDENNGAY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTUNGAY);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRPT_DOANHTHU_NGAY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo doanh thu theo ngày";
            this.Load += new System.EventHandler(this.frmRPT_DOANHTHU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHU_THEONGAYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpTUNGAY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDENNGAY;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DOANHTHU_THEONGAYBindingSource;
        private QL_CUAHANG_THOITRANGDataSet QL_CUAHANG_THOITRANGDataSet;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.DOANHTHU_THEONGAYTableAdapter DOANHTHU_THEONGAYTableAdapter;
        private System.Windows.Forms.Button btnINBC;
        private System.Windows.Forms.Button btnTAIBC;
        private System.Windows.Forms.CheckBox cbALLTIME;
        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}