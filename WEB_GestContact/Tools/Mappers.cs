using Dal_GestContact.Entities;
using WEB_GestContact.Models;

namespace WEB_GestContact.Tools
{
    public static class Mappers
    {
        public static Contact CreateToDal(this ContactForm f)
        {
            return new Contact
            {
                FirstName = f.FirstName,
                LastName = f.LastName,
                Email = f.Email,
                BirthDate = f.BirthDate
            };
        }

        public static ContactUpdateForm ToUpdate(this Contact c)
        {
            return new ContactUpdateForm
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                BirthDate = c.BirthDate,
                Email = c.Email
            };
        }

        public static Contact UpdateToDal(this ContactUpdateForm c)
        {
            return new Contact
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                BirthDate = c.BirthDate,
                Email = c.Email
            };
        }

        public static AppUser ToASP(this User u)
        {
            return new AppUser
            {
                Id = u.Id,
                NickName = u.NickName,
                Email = u.Email
            };
        }
    }
}
