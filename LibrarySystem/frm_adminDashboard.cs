using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_adminDashboard : Form
    {
        public frm_adminDashboard()
        {
            InitializeComponent();
        }

        private void frm_adminDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + frm_login.setValueForUserName;
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();

                    string q1 = "SELECT COUNT(*) FROM Books";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                        lblTotalBooks.Text = "Total Books: " + cmd.ExecuteScalar().ToString();

                    string q2 = "SELECT COUNT(*) FROM Users WHERE IsAdmin=0";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                        lblTotalMembers.Text = "Total Members: " + cmd.ExecuteScalar().ToString();

                    string q3 = "SELECT COUNT(*) FROM BorrowingTransaction WHERE IsReturned=0";
                    using (SqlCommand cmd = new SqlCommand(q3, con))
                        lblCurrentlyBorrowed.Text = "Currently Borrowed: " + cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            frm_manageBooks form = new frm_manageBooks();
            form.Show();
        }

        private void btnManageMembers_Click(object sender, EventArgs e)
        {
            frm_manageMembers form = new frm_manageMembers();
            form.Show();
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            frm_borrowBook form = new frm_borrowBook();
            form.ShowDialog();
            LoadStats(); // refresh stats after borrowing
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            frm_returnBook form = new frm_returnBook();
            form.ShowDialog();
            LoadStats(); // refresh stats after returning
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frm_login loginForm = new frm_login();
            loginForm.Show();
            this.Close();
        }

       
    }
}