using LibrarySystem.API.Data;
using LibrarySystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly DatabaseHandler _db;

        public BooksController(DatabaseHandler db)
        {
            _db = db;
        }

        // GET api/books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = new List<Book>();
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT BookID, Title, Author, Quantity FROM Books";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                BookID = Convert.ToInt32(reader["BookID"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            });
                        }
                    }
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/books/available
        [HttpGet("available")]
        public IActionResult GetAvailableBooks()
        {
            var books = new List<Book>();
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "SELECT BookID, Title, Author, Quantity FROM Books WHERE Quantity > 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                BookID = Convert.ToInt32(reader["BookID"]),
                                Title = reader["Title"].ToString(),
                                Author = reader["Author"].ToString(),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            });
                        }
                    }
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/books
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "INSERT INTO Books (Title, Author, Quantity) VALUES (@t, @a, @q)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@t", book.Title);
                        cmd.Parameters.AddWithValue("@a", book.Author);
                        cmd.Parameters.AddWithValue("@q", book.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Book added.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "UPDATE Books SET Title=@t, Author=@a, Quantity=@q WHERE BookID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@t", book.Title);
                        cmd.Parameters.AddWithValue("@a", book.Author);
                        cmd.Parameters.AddWithValue("@q", book.Quantity);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Book updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = "DELETE FROM Books WHERE BookID=@id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Book deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}