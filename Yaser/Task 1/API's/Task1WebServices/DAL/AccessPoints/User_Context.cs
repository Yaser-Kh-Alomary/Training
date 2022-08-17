

using DML.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.AccessPoints
{
    public class User_Context : DbContext
    {
        IConfiguration config;
        private IHostingEnvironment environment;
        public User_Context(DbContextOptions<User_Context> options, IConfiguration config, IHostingEnvironment hostingEnvironment) : base(options)
        {
            this.config = config;
            this.environment = hostingEnvironment;
        }

        public async Task< bool > AddUsers(User user)
        {
            if (user.File != null && user.File.Length != 0)
            {
                string uploads = Path.Combine(this.environment.ContentRootPath, "uploads");
                Directory.CreateDirectory(uploads);
                string filePath = Path.Combine(uploads, user.UserID + user.File.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    user.File.CopyTo(fileStream);
                }
            }
            var connection = this.Database.GetDbConnection();
            await connection.OpenAsync();
            //build process details
            var command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AddNewUser";

            // set process input
            command.Parameters.Add(new SqlParameter("@UserID", user.UserID));
            command.Parameters.Add(new SqlParameter("@Name", user.Name));
            command.Parameters.Add(new SqlParameter("@Email", user.Email));
            command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
            command.Parameters.Add(new SqlParameter("@RoleID", user.RoleID));
            command.Parameters.Add(new SqlParameter("@StatusID", user.StatusID));

            //start processing
            var reader = await command.ExecuteReaderAsync();


            int check = reader.RecordsAffected;


            await reader.CloseAsync();
            await connection.CloseAsync();


            return check == 1;
        }
        public async Task<User> GetUserByIDAsync(string userID)
        {
            User user = new User();
            var connection = this.Database.GetDbConnection();
            await connection.OpenAsync();
            //build process details
            var command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "GetUserByID";

            command.Parameters.Add(new SqlParameter("@UserID", userID));
            //start processing
            var reader = await command.ExecuteReaderAsync();


            while (await reader.ReadAsync())
            {
                user = new User
                {
                    UserID = reader.GetString("UserID"),
                    Name = reader.GetString("Name"),
                    Email = reader.GetString("Email"),
                    Phone = reader.GetString("Phone"),
                    RoleID = reader.GetInt32("RoleID"),
                    StatusID = reader.GetInt32("StatusID")

                };
            }


            await reader.CloseAsync();
            await connection.CloseAsync();
            return user;
        }
    }


}


