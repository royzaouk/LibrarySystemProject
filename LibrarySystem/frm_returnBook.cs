using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_returnBook : Form
    {
        public frm_returnBook()
        {
            InitializeComponent();
        }

        private void frm_returnBook_Load(object sender, EventArgs e)
        {
            LoadActiveBorrows();
        }

        private void LoadActiveBorrows()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT 
                            bt.TransactionID,
                            u.FirstName + ' ' + u.LastName AS Member,
                            b.Title,
                            bt.BorrowDate,
                            bt.ReturnDate AS DueDate
                        FROM BorrowingTransaction bt
                        JOIN Users u ON bt.UserID  = u.UserID
                        JOIN Books b ON bt.BookID  = b.BookID
                        WHERE bt.IsReturned = 0";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvActiveBorrows.DataSource = dt;

                        if (dgvActiveBorrows.Columns["TransactionID"] != null)
                            dgvActiveBorrows.Columns["TransactionID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMarkReturned_Click(object sender, EventArgs e)
        {
            if (dgvActiveBorrows.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrow record.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int transactionID = Convert.ToInt32(dgvActiveBorrows.SelectedRows[0].Cells["TransactionID"].Value);

            DialogResult confirm = MessageBox.Show("Mark this book as returned?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();

                    // Get the BookID first
                    int bookID;
                    string getBookQuery = "SELECT BookID FROM BorrowingTransaction WHERE TransactionID=@tid";
                    using (SqlCommand cmd = new SqlCommand(getBookQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tid", transactionID);
                        bookID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Mark transaction as returned
                    string updateQuery = "UPDATE BorrowingTransaction SET IsReturned=1 WHERE TransactionID=@tid";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tid", transactionID);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into BookReturnTransaction
                    string insertReturn = "INSERT INTO BookReturnTransaction (TransactionID, ActualReturnDate) VALUES (@tid, @date)";
                    using (SqlCommand cmd = new SqlCommand(insertReturn, con))
                    {
                        cmd.Parameters.AddWithValue("@tid", transactionID);
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);
                        cmd.ExecuteNonQuery();
                    }

                    // Restore book quantity
                    string restoreQty = "UPDATE Books SET Quantity = Quantity + 1 WHERE BookID=@bid";
                    using (SqlCommand cmd = new SqlCommand(restoreQty, con))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Book returned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActiveBorrows();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}