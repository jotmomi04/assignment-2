using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MobileStore.NewPhones;

    public class newMobilesContext : DbContext
    {
        public newMobilesContext (DbContextOptions<newMobilesContext> options)
            : base(options)
        {
        }

        public DbSet<MobileStore.NewPhones.NewMobiles> NewMobiles { get; set; }
    }
