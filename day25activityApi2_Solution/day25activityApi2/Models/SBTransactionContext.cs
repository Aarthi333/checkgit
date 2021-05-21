using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using day25activityApi2.Models;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("409bc9e2-1cb3-4790-ab00-fa25e2e7009e")]
namespace day25activityApi2.Models
{
    public class SBTransactionContext : DbContext
    {

        public SBTransactionContext() : base()
        {

        }
        public SBTransactionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SBTransaction> sBTransactions { get; set; }

    }

}
