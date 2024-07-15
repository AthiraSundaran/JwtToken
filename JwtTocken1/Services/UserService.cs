using System;
using JwtTocken1.Model;

namespace JwtTocken1.Services
{
	public class UserService : IuserService//interfacing userservice,that contain the declaration of userservice methods
	{
		public List<User> users = new List<User> { new User { Id=1,UserName="Ramu",Password="123",Role="admin" },new User{
		Id=2,UserName="string",Password="string",Role="user"},new User{Id=3,UserName="Raju",Password="456",Role="user" } };//Creating a users List taking User as datatype

		public User Login(UserLogin log)//implementingthe login method defined in service class.here using User as Dtatype of method and UserLogin taken as data type of parameter inside the method.
		{
			var user = users.FirstOrDefault(x => x.UserName == log.UserName && x.Password == log.Password);//Checking the entered data present in Db or saved list;
			return user;	
		}
	}
}

