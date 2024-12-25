namespace Domain.Models;

public class Book
{
// - Создавать две таблицы:  
// 1. `Books` со следующей структурой:  
// - `Id` — Primary Key, автоинкремент;  
// - `Title` — название книги, строка длиной до 200 символов;  
// - `AuthorId` — внешний ключ, ссылающийся на таблицу `Authors`;  
// - `PublishedYear` — год издания, целое число;  
// - `Genre` — жанр книги, строка длиной до 50 символов;  
// - `IsAvailable` — статус доступности, тип `boolean`.
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int PublishedYear { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}