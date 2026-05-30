using LibrarySystem.API.Data;
using LibrarySystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly DatabaseHandler _db;

        public TransactionsController(DatabaseHandler db)
        {
            _db = db;
        }

        // GET api/transactions/active
        [HttpGet("active")]
        public IActionResult GetActiveBorrows()
        {
            var list = new List<BorrowingTransaction>();
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT bt.TransactionID,
                               bt.UserID, bt.BookID,
                               bt.BorrowDate, bt.ReturnDate, bt.IsReturned,
                               u.FirstName + ' ' + u.LastName AS MemberName,
                               b.Title AS BookTitle
                        FROM BorrowingTransaction bt
                        JOIN Users u ON bt.UserID = u.UserID
                        JOIN Books b ON bt.BookID = b.BookID
                        WHERE bt.IsReturned = 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BorrowingTransaction
                            {
                                TransactionID = Convert.ToInt32(reader["TransactionID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                BookID = Convert.ToInt32(reader["BookID"]),
                                BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                                ReturnDate = Convert.ToDateTime(reader["ReturnDate"]),
                                IsReturned = Convert.ToBoolean(reader["IsReturned"]),
                                MemberName = reader["MemberName"].ToString(),
                                BookTitle = reader["BookTitle"].ToString()
                            });
                        }
                    }
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/transactions/user/5
        [HttpGet("user/{userId}")]
        public IActionResult GetUserBorrows(int userId)
        {
            var list = new List<BorrowingTransaction>();
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();
                    string query = @"
                        SELECT bt.TransactionID, bt.UserID, bt.BookID,
                               bt.BorrowDate, bt.ReturnDate, bt.IsReturned,
                               b.Title AS BookTitle
                        FROM BorrowingTransaction bt
                        JOIN Books b ON bt.BookID = b.BookID
                        WHERE bt.UserID = @uid";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new BorrowingTransaction
                                {
                                    TransactionID = Convert.ToInt32(reader["TransactionID"]),
                                    UserID = Convert.ToInt32(reader["UserID"]),
                                    BookID = Convert.ToInt32(reader["BookID"]),
                                    BorrowDate = Convert.ToDateTime(reader["BorrowDate"]),
                                    ReturnDate = Convert.ToDateTime(reader["ReturnDate"]),
                                    IsReturned = Convert.ToBoolean(reader["IsReturned"]),
                                    BookTitle = reader["BookTitle"].ToString()
                                });
                            }
                        }
                    }
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/transactions/borrow
        [HttpPost("borrow")]
        public IActionResult BorrowBook([FromBody] BorrowingTransaction transaction)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();

                    string insertQuery = @"INSERT INTO BorrowingTransaction 
                        (UserID, BookID, BorrowDate, ReturnDate, IsReturned)
                        VALUES (@uid, @bid, @bd, @rd, 0)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@uid", transaction.UserID);
                        cmd.Parameters.AddWithValue("@bid", transaction.BookID);
                        cmd.Parameters.AddWithValue("@bd", transaction.BorrowDate.Date);
                        cmd.Parameters.AddWithValue("@rd", transaction.ReturnDate.Date);
                        cmd.ExecuteNonQuery();
                    }

                    string updateQty = "UPDATE Books SET Quantity = Quantity - 1 WHERE BookID=@bid";
                    using (SqlCommand cmd = new SqlCommand(updateQty, con))
                    {
                        cmd.Parameters.AddWithValue("@bid", transaction.BookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Book borrowed successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/transactions/return/5
        [HttpPut("return/{transactionId}")]
        public IActionResult ReturnBook(int transactionId)
        {
            try
            {
                using (SqlConnection con = _db.GetNewConnection())
                {
                    con.Open();

                    int bookID;
                    string getBookQuery = "SELECT BookID FROM BorrowingTransaction WHERE TransactionID=@tid";
                    using (SqlCommand cmd = new SqlCommand(getBookQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tid", transactionId);
                        bookID = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string updateQuery = "UPDATE BorrowingTransaction SET IsReturned=1 WHERE TransactionID=@tid";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tid", transactionId);
                        cmd.ExecuteNonQuery();
                    }

                    string insertReturn = "INSERT INTO BookReturnTransaction (TransactionID, ActualReturnDate) VALUES (@tid, @date)";
                    using (SqlCommand cmd = new SqlCommand(insertReturn, con))
                    {
                        cmd.Parameters.AddWithValue("@tid", transactionId);
                        cmd.Parameters.AddWithValue("@date", DateTime.Today);
                        cmd.ExecuteNonQuery();
                    }

                    string restoreQty = "UPDATE Books SET Quantity = Quantity + 1 WHERE BookID=@bid";
                    using (SqlCommand cmd = new SqlCommand(restoreQty, con))
                    {
                        cmd.Parameters.AddWithValue("@bid", bookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                return Ok("Book returned successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}