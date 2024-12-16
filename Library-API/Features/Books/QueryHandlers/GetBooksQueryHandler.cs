﻿using Library_API.Features.Books.Queries;
using Library_API.Models;
using Library_API.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Features.Books.QueryHandlers
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, ICollection<Book>>
    {
        private readonly AppDbContext _dbContext;

        public GetBooksQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _dbContext.Books.AsNoTracking().ToArrayAsync();
            return books;
        }
    }
}
