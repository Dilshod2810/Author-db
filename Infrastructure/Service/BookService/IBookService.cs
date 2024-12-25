using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service;

public interface IBookService
{
    Task<Response<List<Book>>> GetAll();
    Task<Response<bool>> Create(Book book);
    Task<Response<bool>> Update(Book book);
    Task<Response<bool>> Delete(int id);
    Task<Response<string>> GetAllBooks(string name);

}