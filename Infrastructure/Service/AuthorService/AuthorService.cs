using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.AuthorService;

public class AuthorService(DapperContext context) : IAuthorService
{
    public async Task<Response<bool>> Create(Author author)
    {
        string sql = "insert into authors(name, country) values(@Name, @Country);";
        var res = await context.Connection().ExecuteAsync(sql, author);
        return res > 0
            ? new Response<bool>(HttpStatusCode.Created, "Created successfully")
            : new Response<bool>(HttpStatusCode.BadRequest, "Failed to create");
    }
}