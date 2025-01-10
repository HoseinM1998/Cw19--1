using AppDomainCore.Contract.User;
using AppDomainCore.Entities;

namespace AppDomainService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Add(User user)
        {

            if (user.Phone.Length != 11)
            {
                throw new Exception("Phone must be 11 characters");
            }


            if (user.NationalCode.Length != 10)
            {
                throw new Exception("NationalCode must be 10 characters");
            }

           var Nationalcode =  _repository.GetBYNationalCode(user.NationalCode);
           if (Nationalcode != null)
           {
               throw new Exception("National code exists, enter new national code");

            }

            _repository.Add(user);
        }
        public void Update(User user)
        {
            if (user != null)
            {
                _repository.Update(user);
            }
            
        }

        public void Delete(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            _repository.Delete(id);
        }

        public User GetById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            return user;
        }

        public List<User> GetAll()
        {
            var user = _repository.GetAll();
            if (user == null)
            {
                throw new Exception("List User Null");
            }

            return user;
        }

        public List<User> Search(string search)
        {
            if (search == null)
            {
                throw new Exception("Not Null");
            }

            var users = _repository.Search(search);
            return users;
        }

    }
}
