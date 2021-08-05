using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public class AuthorDbRepository : IBookStoreRepository<Author>
    {
        BookStoreDbContext db;
        public AuthorDbRepository(BookStoreDbContext dbContext)
        {
            db = dbContext;

        }
        public void Add(Author entity)
        {
            //entity.Id = db.Authors.Max(a => a.Id) + 1;
            db.Authors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Author Find(int id)
        {
            var author = db.Authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return db.Authors.ToList();
        }

        public IList<Author> Search()
        {
            throw new NotImplementedException();
        }

        public IList<Author> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Author entity)
        {
            db.Authors.Update(entity);
            db.SaveChanges();
        }
    }
}
