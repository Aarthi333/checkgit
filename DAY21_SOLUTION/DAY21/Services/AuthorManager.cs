using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAY21.Models;
using Microsoft.Extensions.Logging;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

//[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

//[assembly: Guid("5633d747-1073-4ddc-a37a-ba3acfe3ccab")]
namespace DAY21.Services
{
    public class AuthorManager : IRepo<Author>
    {
        private PublicationContext _context;
        private ILogger<AuthorManager> _logger;

        public AuthorManager(PublicationContext context, ILogger<AuthorManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public void Add(Author t)
        {
            try
            {
                _context.Authors.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Author t)
        {
            try
            {
                _context.Authors.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Author Get(int id)
        {
            try
            {
                Author author = _context.Authors.FirstOrDefault(a => a.Id == id);
                return author;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                if (_context.Authors.Count() == 0)
                    return null;
                return _context.Authors.ToList();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Author t)
        {
            Author author = Get(id);
            if (author != null)
            {
                author.Name = t.Name;
                author.About = t.About;
                author.Books = t.Books;
            }
            _context.SaveChanges();
        }
    }
}

