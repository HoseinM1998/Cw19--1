using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.User
{
    public interface IUserRepository
    {
        public void Add(Entities.User user);
        public void Update(Entities.User user);
        public void Delete(int id);
        public Entities.User? GetById(int id);
        public Entities.User? GetBYNationalCode(string nationalCode);
        public List<Entities.User> GetAll();
        public List<Entities.User> Search(string search);
    }
}
