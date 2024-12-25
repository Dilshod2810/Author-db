using System.Net;
using Dapper;
using Domain.Models;
using Domain.Models.DTOs;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service;

public class BookService(DapperContext context)
{
    public async Task<Response<List<Book>>> GetAll()
    {
        string sql = "SELECT books.id AS book_id,  books.title AS book_title,  books.published_date, authors.id AS author_id, authors.name AS author_name FROM  books JOIN authors ON books.author_id = authors.id;";
        var res = await context.Connection().QueryAsync<Book>(sql);
        return new Response<List<Book>>(res.ToList());
    }

    public async Task<Response<bool>> Create(Book book)
    {
        string sql =
            "insert into books(title, authorid, publishedyear, genre, isavailable) values(@Title, @Authorid, @PublishedYear, @Genre, @IsAvailable);";
        var res = await context.Connection().ExecuteAsync(sql, book);
        return res > 0
            ? new Response<bool>(HttpStatusCode.Created, "Created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create");
    }

    public async Task<Response<bool>> Update(Book book)
    {
        var sql = "update books set title=@Title, authorid=@AuthorId, publishedyear=@PublishedYear, genre=@Genre, isavailable=@IsAvailable where id=@Id;";
        var res = await context.Connection().ExecuteAsync(sql, book);
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = "delete from books where id = @Id";
        // var product = GetById(id).Result.Data;
        // if (product == null)
        // {
        //     return new Response<bool>(HttpStatusCode.NotFound, "Not found");
        // }

        var deleted = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return deleted > 0
            ? new Response<bool>(HttpStatusCode.OK, "Deleted successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Not found");
    }

    public async Task<Response<List<GetBookWithAuthorDTO>>> GetAllBooks()
    {
        string sqlBooks = "select * from Books";
        string sqlAuthors = "select * from Authors where Id=@id";
        var result = await context.Connection().QueryAsync<GetBookWithAuthorDTO>(sqlBooks);
        var books = result.ToList();
        foreach (var book in books)
        {
            var author = await context.Connection().QueryFirstOrDefaultAsync<Author>(sqlAuthors, new { Id = book.AuthorId });
            book.Authors = new List<Author> { author };
        }
        return new Response<List<GetBookWithAuthorDTO>>(books);

    }

    public async Task<Response<Book>> GetByBookByAuthor(string author)
    {
        var sql = @"SELECT * FROM books 
                    WHERE authorId=select id from authors
                    WHERE name=@author;";
        var book = await context.Connection().QueryFirstOrDefaultAsync<Book>(sql, new { author });
        return book!= null
           ? new Response<Book>(book)
            : new Response<Book>(HttpStatusCode.NotFound, "Not found");
    }
    
    
}