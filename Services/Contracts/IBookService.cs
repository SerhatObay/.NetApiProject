﻿using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<(IEnumerable<ExpandoObject> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges);
        Task<BookDto> CreateOneBookByIdAsync(BookDtoForInsertion book);
        Task UpdateOneBookByIdAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
        Task DeleteOneBookByIdAsync(int id, bool trackChanges);

        Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges);

        Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book);
    }
}
