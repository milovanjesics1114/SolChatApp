using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatApp.Models;

namespace ChatApp.Data
{
    public class MvcChatContext : DbContext
    {
        public MvcChatContext(DbContextOptions<MvcChatContext> options)
            : base(options)
        {
        }

        public DbSet<ChatAppModel> ChatAppModel { get; set; }
    }
}
