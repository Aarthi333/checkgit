using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using day_22_activity.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("6b540827-32be-44e9-a215-796dc6dea014")]

namespace day_22_activity.Services
{
    public class UserManager : IRepo<User>
    {
        private UserContext _context;
        private ILogger<UserManager> _logger;

        public UserManager(UserContext context, ILogger<UserManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public bool Register(User t)
        {
            try
            {
                _context.Users.Add(t);
                _context.SaveChanges();
                return true;
            }
           catch (Exception e)
           {
                _logger.LogDebug(e.Message);
                return false;
           }
            
            }
        public bool Login(User t)
        {
            try
            {
                User user = _context.Users.SingleOrDefault(u => u.UserName == t.UserName);
                if (user.Password == t.Password)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}


