using Dal_GestContact.Entities;

namespace Dal_GestContact.Interface
{
    public interface IContactRepo
    {
        void Delete(int Id);
        IEnumerable<Contact> GetAll();
        Contact GetById(int Id);
        void Post(Contact c);
        void Update(Contact c);
    }
}