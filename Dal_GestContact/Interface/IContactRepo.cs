using Dal_GestContact.Entities;

namespace Dal_GestContact.Interface
{
    public interface IContactRepo
    {
        void Delete(int Id, string token);
        IEnumerable<Contact> GetAll();
        Contact GetById(int Id, string token);
        void Post(Contact c, string token);
        void Update(Contact c, string token);
    }
}