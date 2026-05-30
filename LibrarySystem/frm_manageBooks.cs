using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_manageBooks : Form
    {
        private int selectedBookID = -1;

        public frm_manageBooks()
        {
            InitializeComponent();
        }

        private void frm_manageBooks_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT BookID, Title, Author, Quantity FROM Books";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvBooks.DataSource = dt;

                        // Hide the ID column from the user
                        if (dgvBooks.Columns["BookID"] != null)
                            dgvBooks.Columns["BookID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
            selectedBookID = Convert.ToInt32(row.Cells["BookID"].Value);
            txtTitle.Text = row.Cells["Title"].Value.ToString();
            txtAuthor.Text = row.Cells["Author"].Value.ToString();
            txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "INSERT INTO Books (Title, Author, Quantity) VALUES (@t, @a, @q)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@t", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@a", txtAuthor.Text.Trim());
                        cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text.Trim()));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Book added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedBookID == -1)
            {
                MessageBox.Show("Please select a book to edit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInputs()) return;

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "UPDATE Books SET Title=@t, Author=@a, Quantity=@q WHERE BookID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@t", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@a", txtAuthor.Text.Trim());
                        cmd.Parameters.AddWithValue("@q", int.Parse(txtQuantity.Text.Trim()));
                        cmd.Parameters.AddWithValue("@id", selectedBookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Book updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookID == -1)
            {
                MessageBox.Show("Please select a book to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Books WHERE BookID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedBookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Book deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtQuantity.Text = "";
            selectedBookID = -1;
            dgvBooks.ClearSelection();
        }

        private bool ValidateInputs()
        {
            if (txtTitle.Text.Trim() == "" || txtAuthor.Text.Trim() == "" || txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("All fields are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty < 0)
            {
                MessageBox.Show("Quantity must be a non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}