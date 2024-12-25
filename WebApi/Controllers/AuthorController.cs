
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service.AuthorService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService):ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Author author)
    {
        return await authorService.Create(author);
    }
}