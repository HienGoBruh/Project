using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace QL_CUAHANG_THOITRANG
{
    public partial class frmRPT_LOINHUAN_NGAY : Form
    {
        public frmRPT_LOINHUAN_NGAY()
        {
            InitializeComponent();
        }

        private void frmRPT_LOINHUAN_NGAY_Load(object sender, EventArgs e)
        {
            
        }

        private void btnINBC_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTUNGAY.Value.Date;
            DateTime denNgay = dtpDENNGAY.Value.Date;

            this.LOINHUAN_THEONGAYTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.LOINHUAN_THEONGAY, tuNgay, denNgay);
            this.reportViewer1.RefreshReport(); 
        }

        private void btnTAIBC_Click(object sender, EventArgs e)
        {
            if (this.QL_CUAHANG_THOITRANGDataSet.LOINHUAN_THEONGAY.Rows.Count > 0)
            {
                try
                {
                    // 1. Lấy ngày để load lại dữ liệu đúng thời điểm
                    DateTime tuNgay = dtpTUNGAY.Value.Date;
                    DateTime denNgay = dtpDENNGAY.Value.Date;

                    // 2. Load dữ liệu nếu cần
                    this.LOINHUAN_THEONGAYTableAdapter.Fill(this.QL_CUAHANG_THOITRANGDataSet.LOINHUAN_THEONGAY, tuNgay, denNgay);

                    // 3. Render PDF
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = "", encoding = "", extension = "";

                    byte[] bytes = reportViewer1.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding,
                        out extension, out streamIds, out warnings);

                    // 4. Chọn nơi lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Lưu báo cáo dưới dạng PDF";
                    saveFileDialog.FileName = "BaoCao_LoiNhuan_Ngay.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(saveFileDialog.FileName, System.IO.FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }

                        MessageBox.Show("Xuất file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để tải về");
            }
        }

        private void btnTHOAT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbALLTIME_CheckedChanged(object sender, EventArgs e)
        {
            if (cbALLTIME.Checked)
            {
                dtpTUNGAY.Enabled = false;
                dtpDENNGAY.Enabled = false;

                DateTime tuNgay, denNgay;
                HamXuLy.GetKhoangThoiGianHoaDonBan(out tuNgay, out denNgay);

                if (tuNgay != DateTime.MinValue && denNgay != DateTime.MaxValue)
                {
                    dtpTUNGAY.Value = tuNgay;
                    dtpDENNGAY.Value = denNgay;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn.");
                }
            }
            else
            {
                dtpTUNGAY.Enabled = true;
                dtpDENNGAY.Enabled = true;
            }
        }
    }
}
