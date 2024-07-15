using System;
using JwtTocken1.Model;

namespace JwtTocken1.Services
{
	public interface IuserService
	{
        public User Login(UserLogin log);

    }
}

