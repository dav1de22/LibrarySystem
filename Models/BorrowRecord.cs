using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class BorrowRecord
    {
        [Key]
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;

        public DateTime? ReturnDate { get; set;}

    }
}
