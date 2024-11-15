using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace MedSched.Repositories
{
    public interface IAuthRepository
    {
        // Method to authenticate a user (doctor or patient) and generate a JWT token
        Task<JwtSecurityToken> LoginAsync(string email, string password);
    }
}