﻿using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }


        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == pass);
        }



        public async Task Register(UserVO userVO)
        {
            var pass = ComputeHash(userVO.Password, new SHA256CryptoServiceProvider());
            userVO.Password = pass;

            User user = new User();
            user.UserName = userVO.UserName;
            user.Password = pass;

            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }



        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(x => x.Id.Equals(user.Id))) return null;


            var result = _context.Users.SingleOrDefault(p => p.Id == user.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            else
            {
                return result;
            }
        }



        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Users.SingleOrDefault(u => (u.UserName == userName));

            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
    }
}
