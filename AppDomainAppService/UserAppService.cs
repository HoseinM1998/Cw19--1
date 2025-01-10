using AppDomainCore.Contract.User;
using AppDomainCore.Entities;

namespace AppDomainAppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;

        public UserAppService(IUserService service)
        {
            _service = service;
        }
        public void Create(User newUser)
        {
            try
            {
                var user = new User
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Phone = newUser.Phone,
                    NationalCode = newUser.NationalCode,
                    Gender = newUser.Gender,
                    MembershipType = newUser.MembershipType,
                    BirthDay = newUser.BirthDay,
                    CreateAt = newUser.CreateAt,
                    

                };
                newUser.CreateAt= DateTime.Now;
                _service.Add(newUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Error");
            }
        }

        public void Update(int id,User upUser)
        {
            try
            {
                var user = _service.GetById(id);
                if (user != null)
                {
                    user.FirstName = upUser.FirstName;
                    user.LastName = upUser.LastName;
                    user.Phone = upUser.Phone;
                    user.NationalCode = upUser.NationalCode;
                    user.Gender = upUser.Gender;
                    user.MembershipType = upUser.MembershipType;

                    _service.Update(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Update");
            }
        }

        public void Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception("Error Delete");
            }
        }

        public User GetById(int id)
        {
            try
            {
               var user= _service.GetById(id);
                return  user ;
                ;
            }
            catch (Exception e)
            {
                throw new Exception("Error Get");
            }
        }


        public List<User> GetAll()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error NotFound");
            }
        }

        public List<User> Search(string search)
        {
            try
            {
                return _service.Search(search);
            }
            catch (Exception ex)
            {
                throw new Exception("Error NotFound");
            }
        }
    }
}
