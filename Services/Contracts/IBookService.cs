using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book GetOneBookById(int id, bool trackChanges);
        Book CreateOneBookById(Book book );
        void UpdateOneBookById(int id,Book book, bool trackChanges);
        void DeleteOneBookById(int id, bool trackChanges);
    }
}
    