using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public class BookDbRepository : IBookStoreRepository<Book>
    {
        BookStoreDbContext db;
        public BookDbRepository(BookStoreDbContext dbContext)
        {
            db = dbContext;
        }
        public void Add(Book entity)
        {
           // entity.Id = books.Max(b => b.Id) + 1;

            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
            return book;

        }

        public IList<Book> List()
        {
            return db.Books.Include(a => a.Author).ToList();
        }

        public IList<Book> Search(string term)
        {
            var res = db.Books.Include(a=>a.Author).Where(b=>b.Title.Contains(term)
            ||b.Description.Contains(term)||b.Author.FullName.Contains(term)).ToList();
            return res;
        }

        public void Update(int id, Book entity)
        {
            db.Books.Update(entity);
            db.SaveChanges();
        }
    }
}

