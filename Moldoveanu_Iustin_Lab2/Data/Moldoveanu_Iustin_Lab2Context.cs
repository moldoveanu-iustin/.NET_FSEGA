using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Iustin_Lab2.Models;

namespace Moldoveanu_Iustin_Lab2.Data
{
    public class Moldoveanu_Iustin_Lab2Context : DbContext
    {
        public Moldoveanu_Iustin_Lab2Context (DbContextOptions<Moldoveanu_Iustin_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Moldoveanu_Iustin_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Moldoveanu_Iustin_Lab2.Models.Author> Authors { get; set; } = default!;
    }
}
