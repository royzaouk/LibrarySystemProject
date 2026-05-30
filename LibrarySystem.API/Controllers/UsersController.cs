using LibrarySystem.API.Data;
using LibrarySystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseHandler _db;

        public UsersController(DatabaseHandler db)
        {
            _db = db;
        }

        // GET api/users
        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var users = new List<User>();
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, LastName, Username, IsAdmin FROM Users WHERE IsAdmin=0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = Convert.ToInt32(reader["UserID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Username = reader["Username"].ToString(),
                                IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                            });
                        }
                    }
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, LastName, Username, IsAdmin FROM Users WHERE UserID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var user = new User
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                                };
                                return Ok(user);
                            }
                            return NotFound("User not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT UserID, FirstName, IsAdmin FROM Users WHERE Username=@u AND Password=@p";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@u", loginRequest.Username);
                        cmd.Parameters.AddWithValue("@p", loginRequest.Password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return Ok(new
                                {
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                                });
                            }
                            return Unauthorized("Invalid username or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/users/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User newUser)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@u";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@u", newUser.Username);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                            return Conflict("Username already taken.");
                    }

                    string insertQuery = "INSERT INTO Users (FirstName, LastName, Username, Password, IsAdmin) VALUES (@f, @l, @u, @p, 0)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@f", newUser.FirstName);
                        cmd.Parameters.AddWithValue("@l", newUser.LastName);
                        cmd.Parameters.AddWithValue("@u", newUser.Username);
                        cmd.Parameters.AddWithValue("@p", newUser.Password);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Registered successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "UPDATE Users SET FirstName=@f, LastName=@l, Username=@u, Password=@p WHERE UserID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@f", updatedUser.FirstName);
                        cmd.Parameters.AddWithValue("@l", updatedUser.LastName);
                        cmd.Parameters.AddWithValue("@u", updatedUser.Username);
                        cmd.Parameters.AddWithValue("@p", updatedUser.Password);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("User updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Users WHERE UserID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("User deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}