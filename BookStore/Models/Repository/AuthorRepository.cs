using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public class AuthorRepository : IBookStoreRepository<Author>
    {
        List<Author> authors;
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author{ Id = 1 , FullName ="Mohammed Elsayed"},
                new Author{ Id = 2 , FullName ="Ahmed Mahmoud"},
                new Author{ Id = 3 , FullName ="Omar Mohammed"}
            };

        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(a => a.Id) + 1;
            authors.Add(entity); 
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(a=>a.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
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
            var author = Find(id);
            author.FullName = entity.FullName;
        }
    }
}
