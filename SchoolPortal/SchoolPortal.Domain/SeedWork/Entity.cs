using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPortal.Domain.SeedWork
{
    public class Entity
    {
        public int Id { get; private set; }
        public DateTime DateCreated { get; private set; } = DateTime.UtcNow;
    }
}
