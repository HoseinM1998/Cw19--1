using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomainCore.Contract.User;
using AppDomainCore.Entities;
using AppInfraDbSqlServer;
using Microsoft.EntityFrameworkCore;

namespace AppInfraDataAccessEf.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            var updateUser = _context.Users.Find(user.Id);
            if (updateUser != null)
            {
                updateUser.FirstName = user.FirstName;
                updateUser.LastName = user.LastName;
                updateUser.BirthDay = user.BirthDay;
                updateUser.Phone = user.NationalCode;
                updateUser.NationalCode = user.NationalCode;
                updateUser.Gender = user.Gender;
                updateUser.MembershipType = user.MembershipType;
                _context.SaveChanges();

            }
        }

        public User? GetById(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public User? GetBYNationalCode(string nationalCode)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.NationalCode == nationalCode);
        }

        public List<User> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> Search(string search)

        {
            return _context.Users
                .Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search))
                .ToList();
        }
    }
}
