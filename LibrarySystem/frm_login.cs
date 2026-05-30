using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class frm_login : Form
    {
        public static int setValueForUserID;
        public static string setValueForUserName;

        public frm_login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = DatabaseHandler.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, IsAdmin FROM Users WHERE Username=@u AND Password=@p";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                setValueForUserID = Convert.ToInt32(reader["UserID"]);
                                setValueForUserName = reader["FirstName"].ToString();
                                bool isAdmin = Convert.ToBoolean(reader["IsAdmin"]);

                                if (isAdmin)
                                {
                                    frm_adminDashboard adminDash = new frm_adminDashboard();
                                    adminDash.Show();
                                }
                                else
                                {
                                    frm_studentDashboard studentDash = new frm_studentDashboard();
                                    studentDash.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frm_register registerForm = new frm_register();
            registerForm.ShowDialog();
        }
    }
}