using Dal_GestContact.Entities;

namespace Dal_GestContact.Interface
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAll();
        User GetById(int Id, string token);
        string Login(string email, string password);
    }
}