using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanulmanyiRendszer.API.Models;

namespace TanulmanyiRendszer.API.Data
{
    public class TanulmanyiRendszerContext : DbContext
    {
        public TanulmanyiRendszerContext(DbContextOptions<TanulmanyiRendszerContext> options) : base(options)
        {
        }

        public DbSet<Szemeszter> Szemeszterek { get; set; }
    }
}
