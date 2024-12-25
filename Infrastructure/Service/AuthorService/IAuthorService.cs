using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.AuthorService;

public interface IAuthorService
{
    Task<Response<bool>> Create(Author author);
    
}