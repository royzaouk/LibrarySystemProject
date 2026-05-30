using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_borrowBook : Form
    {
        public frm_borrowBook()
        {
            InitializeComponent();
        }

        private void frm_borrowBook_Load(object sender, EventArgs e)
        {
            dtpBorrowDate.Value = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today.AddDays(14);
            LoadMembers();
            LoadBooks();
        }

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName + ' ' + LastName AS FullName FROM Users WHERE IsAdmin=0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbMember.DataSource = dt;
                        cmbMember.DisplayMember = "FullName";
                        cmbMember.ValueMember = "UserID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT BookID, Title FROM Books WHERE Quantity > 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbBook.DataSource = dt;
                        cmbBook.DisplayMember = "Title";
                        cmbBook.ValueMember = "BookID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmBorrow_Click(object sender, EventArgs e)
        {
            if (cmbMember.SelectedIndex == -1 || cmbBook.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a member and a book.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpReturnDate.Value.Date <= dtpBorrowDate.Value.Date)
            {
                MessageBox.Show("Return date must be after borrow date.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userID = Convert.ToInt32(cmbMember.SelectedValue);
            int bookID = Convert.ToInt32(cmbBook.SelectedValue);

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();

                    string insertQuery = @"INSERT INTO BorrowingTransaction 
                        (UserID, BookID, BorrowDate, ReturnDate, IsReturned) 
                        VALUES (@uid, @bid, @bd, @rd, 0)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", userID);
                        cmd.Parameters.AddWithValue("@bid", bookID);
                        cmd.Parameters.AddWithValue("@bd", dtpBorrowDate.Value.Date);
                        cmd.Parameters.AddWithValue("@rd", dtpReturnDate.Value.Date);
                        cmd.ExecuteNonQuery();
                    }

                    string updateQuery = "UPDATE Books SET Quantity = Quantity - 1 WHERE BookID=@bid";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Book borrowed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}