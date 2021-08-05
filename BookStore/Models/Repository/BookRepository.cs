using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repository
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> books;
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                { Id = 1 ,
                    Title="C# Programming",
                    Description="No Description here",
                    ImageUrl="Jellyfish.jpg",
                    Author = new Author{ Id=2}
                },
                new Book
                { Id = 2 , 
                    Title="Jave Programming",
                    Description="Nothing data",
                    ImageUrl = "Koala.jpg",
                    Author = new Author()
                },
                new Book
                { Id = 3 ,
                    Title="Paython Programming",
                    Description="No data here",
                    ImageUrl="Tulips.jpg",
                    Author = new Author()
                }
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;

        }

        public IList<Book> List()
        {
            return books;
        }

        public IList<Book> Search()
        {
            throw new NotImplementedException();
        }

        public IList<Book> Search(string term)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Book entity)
        {
            var book = Find(id);
            book.Title = entity.Title;
            book.Description = entity.Description;
            book.Author = entity.Author;
            book.ImageUrl = entity.ImageUrl;
        }
    }
}
