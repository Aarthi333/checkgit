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

//[assembly: Guid("e2595daf-33a0-4dab-ae49-c4e935e108f8")]
namespace DAY21.Services
{
    public class BookManager : IRepo<Book>
    {
        private PublicationContext _context;
        private ILogger<BookManager> _logger;

        public BookManager(PublicationContext context, ILogger<BookManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        public void Add(Book t)
        {
            try
            {
                _context.Books.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                _logger.LogDebug(e.Message);
            }
        }

        
        public void Delete(Book t)
        {
            try
            {
                _context.Books.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }

        }
        public void Update(int id, Book t)
        {
           
            Book book = Get(id);
            if (book != null)
            {
                book.Title = t.Title;
                book.Price= t.Price;              
            }
            _context.SaveChanges();
        }

        private Book Get(int id)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(a => a.Id == id);
                return book;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        Book IRepo<Book>.Get(int id)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(a => a.Id == id);
                return book;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;



        }

        IEnumerable<Book> IRepo<Book>.GetAll()
        {
            try
            {
                if (_context.Books.Count() == 0)
                    return null;
                return _context.Books.ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }
    }
}

