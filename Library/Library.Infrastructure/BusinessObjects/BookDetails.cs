using Library.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.BusinessObjects
{
    public class BookDetails
    {
        public int Id { get; set; }
        public Guid BookId { get; set; }
        public bool IsBorrowed { get; set; }
        public Book Book { get; set; }
        public Borrow BookBorrowed { get; set; }
    }
}
