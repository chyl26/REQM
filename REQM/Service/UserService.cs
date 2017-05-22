using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using REQM.Domain;
using REQM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REQM.Service
{
    public class UserService
    {
        private SqlMapper sqlMapper = null;

        public UserService()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }


        public bool Create(User user)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertUser", user);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return false;
        }

        public User GetUserById(string userID)
        {
            User user = sqlMapper.QueryForObject<User>("SelectUserById", userID);
            return user;
        }

        public User CheckUser(User user)
        {
            User user1 = sqlMapper.QueryForObject<User>("CheckUser", user);
            return user1;
        }


        public IList<User> GetUsers()
        {
            IList<User> users = sqlMapper.QueryForList<User>("SelectAllUser", null);
            return users;
        }

        public IList<User> GetUsers(int index, int size)
        {
            IList<User> userList = sqlMapper.QueryForList<User>("SelectAllUser", null, index, size);
            return userList;
        }


        public bool Update(User user)
        {
            int result = sqlMapper.Update("UpdateUser", user);
            return result > 0;
        }


        public bool Delete(string userID)
        {
            int result = sqlMapper.Delete("DeleteUser", userID);
            return result > 0;
        }
    }
}