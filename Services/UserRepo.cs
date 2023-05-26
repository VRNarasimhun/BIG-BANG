using LoginRegistration.Interfaces;
using LoginRegistration.Models;
using System.Diagnostics;

public class UserRepo : IBaseRepo<string, User>
{
    private readonly ContextClass _context;

    public UserRepo(ContextClass context)
    {
        _context = context;
    }

    public User add(User item)
    {
        try
        {
            _context.Users.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            Debug.WriteLine(item);
        }
        return null;
    }

    public User get(string Key)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == Key);
        return user;
    }
}
