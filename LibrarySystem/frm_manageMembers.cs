using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_manageMembers : Form
    {
        private int selectedUserID = -1;

        public frm_manageMembers()
        {
            InitializeComponent();
        }

        private void frm_manageMembers_Load(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void LoadMembers()
        {
            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, LastName, Username, Password FROM Users WHERE IsAdmin=0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvMembers.DataSource = dt;

                        if (dgvMembers.Columns["UserID"] != null)
                            dgvMembers.Columns["UserID"].Visible = false;

                        if (dgvMembers.Columns["Password"] != null)
                            dgvMembers.Columns["Password"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
            selectedUserID = Convert.ToInt32(row.Cells["UserID"].Value);
            txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
            txtLastName.Text = row.Cells["LastName"].Value.ToString();
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            txtPassword.Text = row.Cells["Password"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a member to edit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtFirstName.Text.Trim() == "" || txtLastName.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("All fields are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "UPDATE Users SET FirstName=@f, LastName=@l, Username=@u, Password=@p WHERE UserID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@f", txtFirstName.Text.Trim());
                        cmd.Parameters.AddWithValue("@l", txtLastName.Text.Trim());
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", selectedUserID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Member updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserID == -1)
            {
                MessageBox.Show("Please select a member to delete.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Delete this member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Users WHERE UserID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedUserID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Member deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFields();
                LoadMembers();
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
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            selectedUserID = -1;
            dgvMembers.ClearSelection();
        }

        private void lblAuthor_Click(object sender, EventArgs e)
        {

        }
    }
}