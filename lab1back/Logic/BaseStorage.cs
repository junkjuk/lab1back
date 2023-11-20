using lab1back.Models;

namespace lab1back.Logic;

public class BaseStorage
{
    protected static List<Category> _category = new();
    protected static List<User> _user = new();
    protected static List<Record> _record = new();
}