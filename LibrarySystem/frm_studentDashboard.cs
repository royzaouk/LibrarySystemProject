using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_studentDashboard : Form
    {
        public frm_studentDashboard()
        {
            InitializeComponent();
        }

        private void frm_studentDashboard_Load(object sender, EventArgs e)
        {
            lblStudentName.Text = "Welcome, " + frm_login.setValueForUserName;
            LoadAvailableBooks();
            LoadMyBorrows();
        }

        private void LoadAvailableBooks()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT Title, Author, Quantity FROM Books WHERE Quantity > 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvAvailableBooks.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMyBorrows()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            b.Title,
                            bt.BorrowDate,
                            bt.ReturnDate AS DueDate,
                            CASE WHEN bt.IsReturned = 1 THEN 'Returned' ELSE 'Borrowed' END AS Status
                        FROM BorrowingTransaction bt
                        JOIN Books b ON bt.BookID = b.BookID
                        WHERE bt.UserID = @uid";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", frm_login.setValueForUserID);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvMyBorrows.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frm_login loginForm = new frm_login();
            loginForm.Show();
            this.Close();
        }
    }
}