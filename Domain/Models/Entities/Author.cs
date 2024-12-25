namespace Domain.Models;

public class Author
{
// 2. `Authors` со следующей структурой:  
// - `Id` — Primary Key, автоинкремент;  
// - `Name` — имя автора, строка длиной до 100 символов;  
// - `Country` — страна автора, строка длиной до 50 символов.
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}