using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainCore.Contract.User
{
    public interface IUserAppService
    {
        public void Create(Entities.User user);
        public void Update(int id,Entities.User user);
        public void Delete(int id);
        public Entities.User GetById(int id);
        public List<Entities.User> GetAll();
        public List<Entities.User> Search(string search);
    }
}
