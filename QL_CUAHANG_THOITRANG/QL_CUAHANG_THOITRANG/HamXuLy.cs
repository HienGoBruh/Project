using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QL_CUAHANG_THOITRANG
{
    class HamXuLy
    {

        
        public static DataTable dtTIMDC = new DataTable();
        public static double tongtien = 0;
        public static double giamgia = 0;
        public static string mahdban = "";
        public static string MAHD = "";
        public static SqlConnection conn;
        //Hàm connect
        public static void connect()
        {
            if (conn == null)
            {
                conn = new SqlConnection();
                //Bỏ Comment connection string
                //Khang
                //conn.ConnectionString = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QL_CUAHANG_THOITRANG;;Integrated Security=True";
                //Hiền
                //conn.ConnectionString = @"Data Source=2B09\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True";
                conn.ConnectionString = @"Data Source=THIS-PC\SQLEXPRESS;Initial Catalog=QL_CUAHANG_THOITRANG;Integrated Security=True";
                //Đạt
                //conn.ConnectionString = @"Data Source=DESKTOP-TEJKH1N\TANDAT;Initial Catalog=QL_CUAHANG_THOITRANG;Integrated Security=True";
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            
        }

        //Hàm Disconnect
        public static void disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        //Hàm Truy vấn
        public static Boolean TruyVan(String strSQL, DataTable dt)
        {
            Boolean kq = false;
            SqlDataAdapter da;
            try
            {
                da = new SqlDataAdapter(strSQL, conn);
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                    kq = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            return kq;
        }

        //Hàm run SQL
        public static void RunSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = HamXuLy.conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery(); //Run Truy vấn SQL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;

        }
        //Hàm fill combo
        public static void FillCombo(string sqlfill, ComboBox cmb, string ma, string ten)
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlfill, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb.DataSource = dt;
            cmb.ValueMember = ma;
            cmb.DisplayMember = ten;
        }

        //Hàm click Lưới để lấy mã
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ma = reader.GetValue(0).ToString();
            }
            reader.Close();
            return ma;
        }

        //Hàm tạo ID tự động khi thêm
        public static string TaoIDMoi(string tenbang, string tencot, string tiento)
        {
            HamXuLy.connect();
            //string.Format giống với cách dùng '"+txtMACL.Text+"' nhưng thay vì dùng thế thì dùng string.Format("Câu truy vấn SQL {0} <- đây là biến số 1", txtMACL.Text <- Truyền biến txtMACL);
            string sql = string.Format("SELECT TOP 1 {0} FROM {1} WHERE {0} LIKE '{2}%' ORDER BY {0} DESC", tencot, tenbang, tiento);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            string hauto = "";
            if (reader.Read()) //kiểm tra xem truy vấn có trả về ít nhất 1 dòng dữ liệu hay không.
            {
                hauto = reader[tencot].ToString(); //Lấy giá trị trong cột có tên là tencot từ dòng hiện tại (dòng đầu tiên trong kết quả truy vấn).
            }
            reader.Close();

            if (string.IsNullOrEmpty(hauto))
            {
                return tiento + "01"; // Nếu chưa có mã nào, bắt đầu từ 1
            }
            else
            {
                string phanso = hauto.Substring(tiento.Length); //Cắt chuỗi hauto từ vị trí bắt đầu là độ dài của tiento, và lấy phần còn lại — phần này chính là phần số phía sau tiền tố.
                int number;
                if (int.TryParse(phanso, out number)) //Biến kiểu chuỗi của phần số tách ra từ hauto thành kiểu int
                {
                    //out number là truyền tham chiếu đầu ra — nghĩa là biến number sẽ nhận giá trị được tạo ra bên trong hàm TryParse nếu hàm chạy thành công.
                    return tiento + (number + 1).ToString("D2"); //ToString("D2") để định dạng một số nguyên thành chuỗi có ít nhất 2 chữ số, và thêm số 0 phía trước nếu cần.
                }
                else
                {
                    // Trường hợp không parse được (dữ liệu lỗi), mặc định về 1
                    return tiento + "01";
                }
            }
        }


        //Hàm kiểm tra ID HDB và ID SP
        public static bool ExistsChiTietHDB(string maHDB, string maSP)
        {
            connect();
            string sql = "SELECT COUNT(*) FROM CHITIETHDB WHERE IDHDB = @IDHDB AND IDSP = @IDSP";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                //Parameters là một thuộc tính của đối tượng SqlCommand (hoặc OleDbCommand, MySqlCommand,...) dùng để chứa danh sách các tham số mà ta muốn truyền vào câu lệnh SQL.
                //AddWithValue là một phương thức được sử dụng trong ADO.NET để thêm một tham số và giá trị tương ứng vào đối tượng
                //SqlCommand.Parameters. Nó giúp truyền giá trị biến vào câu lệnh SQL một cách an toàn,
                //tránh lỗi SQL Injection và tăng tính linh hoạt trong việc xử lý truy vấn.
                
                cmd.Parameters.AddWithValue("@IDHDB", maHDB);
                cmd.Parameters.AddWithValue("@IDSP", maSP);
                try
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra chi tiết hóa đơn: " + ex.Message, "Thông báo");
                    return false;
                }
            }
        }
        //Hàm kiểm tra ID HDN và ID SP
        public static bool ExistsChiTietHDN(string maHDN, string maSP)
        {
            connect();
            //Đếm số lượng CHITIETHDN (dữ liệu) trong bảng CTHDN. VD: csdl có 3 CTHDN thì sql sẽ trả về COUNT là 3
            string sql = "SELECT COUNT(*) FROM CHITIETHDN WHERE IDHDN = @IDHDN AND IDSP = @IDSP";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                //AddWithValue là pthuc giúp thêm tham số, tự động đoán kiểu dữ liệu từ biến truyền vào (maHDN).
                cmd.Parameters.AddWithValue("@IDHDN", maHDN); //Gán giá trị biến maHDN vào tham số @IDHDN trong câu lệnh SQL
                cmd.Parameters.AddWithValue("@IDSP", maSP); //Gán giá trị maSP cho tham số @IDSP (tương tự như trên)
                try
                {
                    //thực hiện câu lệnh sql
                    int count = Convert.ToInt32(cmd.ExecuteScalar());//Chuyển đổi kết quả ExecuteScalar() (trả về dạng object) thành số nguyên (int).
                    //ExecuteScalar() là một phương thức của đối tượng SqlCommand dùng để
                    //chạy một câu lệnh SQL và trả về duy nhất một giá trị (ô dữ liệu đầu tiên của hàng đầu tiên) trong kết quả.
                    return count > 0; //Trả về true nếu có ít nhất 1 bản ghi tồn tại với @IDHDN và @IDSP.
                    //Trả về false nếu không có bản ghi nào phù hợp.
                    //Giống việc viết if (cont > 0) return true; else return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra chi tiết hóa đơn: " + ex.Message, "Thông báo");
                    return false;
                }
            }
        }
        //Hàm kiểm tra tồn tại phân quyền 
        public static bool ExistsPhanQuyen(string idUser, string idCN)
        {
            connect();
            string sql = "SELECT COUNT(*) FROM PHANQUYEN WHERE IDUSER = @IDUSER AND IDCN = @IDCN";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@IDUSER", idUser);
                cmd.Parameters.AddWithValue("@IDCN", idCN);
                try
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra phân quyền: " + ex.Message, "Thông báo");
                    return false;
                }
            }
        }

        // Hàm KT là Admin
        public static int CheckAdmin(string idUser)
        {
            connect();
            string sql = "SELECT NHOM FROM TAIKHOAN WHERE IDUSER = @IDUSER";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@IDUSER", idUser);
                try
                {
                    //object là Kiểu dữ liệu cơ bản nhất trong C#, chứa được mọi kiểu khác
                    //Để sử dụng được biến từ kdl object ta phải đổi kdl, vd: ta có biến result, 
                    //và muốn dùng nó thì txtuser.text = result.ToString();
                    
                    object result = cmd.ExecuteScalar();
                    //khi lấy dữ liệu từ SQL, nếu một cột trong cơ sở dữ liệu có giá trị NULL, thì C# không trả về null mà là DBNull.Value
                    if (result != null && result != DBNull.Value)
                    {
                        string nhom = result.ToString();
                        // Nếu NHOM là "admin" (không phân biệt hoa thường) trả về 1
                        //StringComparison là một enum (kiểu liệt kê) trong C#, dùng để chỉ định cách so sánh 
                        //hai chuỗi — như so sánh có phân biệt chữ hoa/thường hay không, hoặc theo văn hóa/ngôn ngữ nào.
                        if (string.Equals(nhom, "admin", StringComparison.OrdinalIgnoreCase))
                            return 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kiểm tra nhóm tài khoản: " + ex.Message, "Thông báo");
                }
            }
            return 0; // không phải admin
        }

        //Hàm FillText
        public static void FillText(string sqlTxt, TextBox txt, string ma, string ten)
        {
            SqlDataAdapter daTxt = new SqlDataAdapter(sqlTxt, conn);
            DataTable dtTxt = new DataTable();
            daTxt.Fill(dtTxt);

            if (dtTxt.Rows.Count > 0)
            {
                txt.Text = dtTxt.Rows[0][ten].ToString();
            }
            else
            {
                txt.Text = string.Empty;
            }
        }
        
        //Hàm getDataToTable
        public static DataTable GetDataToTable(string sql)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
            return table;
        }
        //Hàm Timkiem
        public static DataTable TimKiem(string sql, SqlParameter[] parameters = null)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (parameters != null) //Kiểm tra xem có danh sách tham số nào không (tránh lỗi khi gọi AddRange trên null).
                {
                    //parameters là một mảng (hoặc danh sách) các SqlParameter chứa các tham số cần truyền vào truy vấn.
                    //Nếu có dl, thì thêm toàn bộ các tham số trong parameters vào đối tượng cmd để dùng trong truy vấn SQL.
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu: " + ex.Message);
            }
            return table;
        }

        //Hàm lấy ngày min và max ngay lap hdb
        public static void GetKhoangThoiGianHoaDonBan(out DateTime tuNgay, out DateTime denNgay)
        {
            tuNgay = DateTime.MinValue;
            denNgay = DateTime.MaxValue;

            connect();
            string sql = "SELECT MIN(NGAYLAP) AS TuNgay, MAX(NGAYLAP) AS DenNgay FROM HOADONBAN";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) tuNgay = reader.GetDateTime(0); //Gán biến TuNgay = min datetime Nếu cột đầu tiên (index 0) không phải là NULL
                    if (!reader.IsDBNull(1)) denNgay = reader.GetDateTime(1); //Gán biến DenNgay = min datetime Nếu cột thứ 2 (index 1) không phải là NULL
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy khoảng thời gian: " + ex.Message);
            }
        }

        //Hàm lấy ngày min và max ngay lap hdn
        public static void GetKhoangThoiGianHoaDonNhap(out DateTime tuNgay, out DateTime denNgay)
        {
            tuNgay = DateTime.MinValue;
            denNgay = DateTime.MaxValue;

            connect();
            string sql = "SELECT MIN(NGAYLAP) AS TuNgay, MAX(NGAYLAP) AS DenNgay FROM HOADONNHAP";
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0)) tuNgay = reader.GetDateTime(0);
                    if (!reader.IsDBNull(1)) denNgay = reader.GetDateTime(1);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy khoảng thời gian: " + ex.Message);
            }
        }
    }//Class
}//NameSpace
