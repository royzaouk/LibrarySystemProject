namespace LibrarySystem.API.Models
{
    public class BorrowingTransaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        // For display
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
    }
}