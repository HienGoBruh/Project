namespace QL_CUAHANG_THOITRANG
{
    partial class frmRPT_NHAPHANG
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BC_NHAPHANGBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QL_CUAHANG_THOITRANGDataSet = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSet();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTHOAT = new System.Windows.Forms.Button();
            this.cbALLTIME = new System.Windows.Forms.CheckBox();
            this.btnTAIBC = new System.Windows.Forms.Button();
            this.btnINBC = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDENNGAY = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTUNGAY = new System.Windows.Forms.DateTimePicker();
            this.LOINHUAN_THEONGAYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LOINHUAN_THEONGAYTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.LOINHUAN_THEONGAYTableAdapter();
            this.BC_NHAPHANGTableAdapter = new QL_CUAHANG_THOITRANG.QL_CUAHANG_THOITRANGDataSetTableAdapters.BC_NHAPHANGTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BC_NHAPHANGBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOINHUAN_THEONGAYBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BC_NHAPHANGBindingSource
            // 
            this.BC_NHAPHANGBindingSource.DataMember = "BC_NHAPHANG";
            this.BC_NHAPHANGBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // QL_CUAHANG_THOITRANGDataSet
            // 
            this.QL_CUAHANG_THOITRANGDataSet.DataSetName = "QL_CUAHANG_THOITRANGDataSet";
            this.QL_CUAHANG_THOITRANGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_CUAHANG_THOITRANG.Properties.Resources._333;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 502);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // btnTHOAT
            // 
            this.btnTHOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTHOAT.Location = new System.Drawing.Point(330, 13);
            this.btnTHOAT.Name = "btnTHOAT";
            this.btnTHOAT.Size = new System.Drawing.Size(123, 31);
            this.btnTHOAT.TabIndex = 48;
            this.btnTHOAT.Text = "THOÁT";
            this.btnTHOAT.UseVisualStyleBackColor = true;
            this.btnTHOAT.Click += new System.EventHandler(this.btnTHOAT_Click);
            // 
            // cbALLTIME
            // 
            this.cbALLTIME.AutoSize = true;
            this.cbALLTIME.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbALLTIME.Location = new System.Drawing.Point(488, 66);
            this.cbALLTIME.Name = "cbALLTIME";
            this.cbALLTIME.Size = new System.Drawing.Size(146, 24);
            this.cbALLTIME.TabIndex = 47;
            this.cbALLTIME.Text = "Từ trước đến nay";
            this.cbALLTIME.UseVisualStyleBackColor = true;
            this.cbALLTIME.CheckedChanged += new System.EventHandler(this.cbALLTIME_CheckedChanged);
            // 
            // btnTAIBC
            // 
            this.btnTAIBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAIBC.Location = new System.Drawing.Point(192, 13);
            this.btnTAIBC.Name = "btnTAIBC";
            this.btnTAIBC.Size = new System.Drawing.Size(123, 31);
            this.btnTAIBC.TabIndex = 46;
            this.btnTAIBC.Text = "TẢI BÁO CÁO";
            this.btnTAIBC.UseVisualStyleBackColor = true;
            this.btnTAIBC.Click += new System.EventHandler(this.btnTAIBC_Click);
            // 
            // btnINBC
            // 
            this.btnINBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnINBC.Location = new System.Drawing.Point(42, 13);
            this.btnINBC.Name = "btnINBC";
            this.btnINBC.Size = new System.Drawing.Size(135, 31);
            this.btnINBC.TabIndex = 45;
            this.btnINBC.Text = "IN BÁO CÁO";
            this.btnINBC.UseVisualStyleBackColor = true;
            this.btnINBC.Click += new System.EventHandler(this.btnINBC_Click);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSetNHAP";
            reportDataSource2.Value = this.BC_NHAPHANGBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_CUAHANG_THOITRANG.rpt_NHAPHANG.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-4, 103);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(789, 377);
            this.reportViewer1.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(253, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "ĐẾN NGÀY";
            // 
            // dtpDENNGAY
            // 
            this.dtpDENNGAY.CustomFormat = "yyyy/MM/dd";
            this.dtpDENNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDENNGAY.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDENNGAY.Location = new System.Drawing.Point(366, 64);
            this.dtpDENNGAY.Name = "dtpDENNGAY";
            this.dtpDENNGAY.Size = new System.Drawing.Size(109, 26);
            this.dtpDENNGAY.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "TỪ NGÀY";
            // 
            // dtpTUNGAY
            // 
            this.dtpTUNGAY.CustomFormat = "yyyy/MM/dd";
            this.dtpTUNGAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTUNGAY.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTUNGAY.Location = new System.Drawing.Point(137, 64);
            this.dtpTUNGAY.Name = "dtpTUNGAY";
            this.dtpTUNGAY.Size = new System.Drawing.Size(103, 26);
            this.dtpTUNGAY.TabIndex = 40;
            // 
            // LOINHUAN_THEONGAYBindingSource
            // 
            this.LOINHUAN_THEONGAYBindingSource.DataMember = "LOINHUAN_THEONGAY";
            this.LOINHUAN_THEONGAYBindingSource.DataSource = this.QL_CUAHANG_THOITRANGDataSet;
            // 
            // LOINHUAN_THEONGAYTableAdapter
            // 
            this.LOINHUAN_THEONGAYTableAdapter.ClearBeforeFill = true;
            // 
            // BC_NHAPHANGTableAdapter
            // 
            this.BC_NHAPHANGTableAdapter.ClearBeforeFill = true;
            // 
            // frmRPT_NHAPHANG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 492);
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
            this.Name = "frmRPT_NHAPHANG";
            this.Text = "frmRPT_NHAPHANG";
            this.Load += new System.EventHandler(this.frmRPT_NHAPHANG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BC_NHAPHANGBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QL_CUAHANG_THOITRANGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LOINHUAN_THEONGAYBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource LOINHUAN_THEONGAYBindingSource;
        private QL_CUAHANG_THOITRANGDataSet QL_CUAHANG_THOITRANGDataSet;
        private System.Windows.Forms.Button btnTHOAT;
        private System.Windows.Forms.CheckBox cbALLTIME;
        private System.Windows.Forms.Button btnTAIBC;
        private System.Windows.Forms.Button btnINBC;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDENNGAY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTUNGAY;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.LOINHUAN_THEONGAYTableAdapter LOINHUAN_THEONGAYTableAdapter;
        private System.Windows.Forms.BindingSource BC_NHAPHANGBindingSource;
        private QL_CUAHANG_THOITRANGDataSetTableAdapters.BC_NHAPHANGTableAdapter BC_NHAPHANGTableAdapter;
    }
}