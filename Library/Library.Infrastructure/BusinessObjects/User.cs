using Library.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.BusinessObjects
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public bool IsApproved { get; set; }
        public Role UserRole { get; set; }
        public List<Borrow> BorrowedBook { get; set; }
    }
}
