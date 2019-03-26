using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FiralApiReal.Models;
using Microsoft.EntityFrameworkCore;

namespace FiralApiReal.Data
{
    public class AuthRepository : IAuthRepository  // first thing we do tell it were using IAuthInterface
    {
        // this is where we are going to query entity framework or db
        // to do this we create constructor first

        private readonly DataContext _dataContext;

        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Username == username); // if it doesnt fidn a user will return null

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
            {
                return null;
            }
            return user;
                
                    //will return true or false depending on iff pw matches
        }

        private bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }

            }
            return true;

        }





        public async Task<User> Register(User user, string password)
        {
            // going to take a user entity and a string of password
            // dont want to store this in plain site so we are going to convert this
            byte[] passwordHash, passwordSalt;

           


            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            } 
                    // initializes sha512 class... gives us a randomly generated key. this key is our passwordSalt
            
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _dataContext.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
    }
}
