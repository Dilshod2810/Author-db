using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Book>>> GetBooks()
    {
        return await bookService.GetAll();
    }
}