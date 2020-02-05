
using Microsoft.AspNetCore.Identity;
using order_meals_api.Data;
using order_meals_data.Constants;
using order_meals_data.Entities;
using order_meals_data.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_meals_data.DataContext
{
    public class SeedData
    {
        private static UserRepository _manager;
        private static ApplicationDbContext _context;
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            _manager = (UserRepository)serviceProvider.GetService(typeof(UserRepository));

            _context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            InitializeVMS().GetAwaiter().GetResult();


        }

        private static async Task InitializeVMS()
        {
            if (!_context.Roles.Any())
            {
                try
                {
                    _context.Roles.Add(new RoleModel(AppRoles.Administrator));
                    _context.Roles.Add(new RoleModel(AppRoles.Member));

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

           

            if (!_context.Users.Any())
            {

                //try
                //{
                //    UserModel newUser = new UserModel();
                //    newUser.Email = newUser.UserName = "admisnistrator@gmail.com";
                //    newUser.FirstName = newUser.UserName = "Barbara";
                //    newUser.LastName = newUser.UserName = "Ezomo";
                //    newUser.DateOfBirth = new DateTimeOffset(DateTime.Now);
                //    newUser.PhoneNumber = "07038875015";

                //    var result = _manager.CreateAsync(newUser, "Password@1").GetAwaiter().GetResult();
                //    var token = _manager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();
                //    var confirmEmail = _manager.ConfirmEmailAsync(newUser, token).GetAwaiter().GetResult();
                //    if (confirmEmail.Succeeded)
                //    {
                //        if (result.Succeeded)
                //        {
                //            var newResult = _manager.AddToRoleAsync(newUser, AppRoles.Administrator).GetAwaiter().GetResult();
                //            if (newResult.Succeeded)
                //            {
                //                Console.WriteLine("User created Successfully");
                //            }
                //        }
                //    }


                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    Console.WriteLine(ex.StackTrace);
                //}

                try
                {
                    UserModel newUser = new UserModel();
                    newUser.Email = newUser.UserName = "member@gmail.com";
                    newUser.PhoneNumber = "07038875015";
                    newUser.FirstName = "Barbara";
                    newUser.LastName ="Ezomo";
                    newUser.DateOfBirth = new DateTimeOffset(DateTime.Now);
                    var result = _manager.CreateAsync(newUser, "Password@1").GetAwaiter().GetResult();
                    var token = _manager.GenerateEmailConfirmationTokenAsync(newUser).GetAwaiter().GetResult();
                    var confirmEmail = _manager.ConfirmEmailAsync(newUser, token).GetAwaiter().GetResult();
                    if (confirmEmail.Succeeded)
                    {
                        if (result.Succeeded)
                        {
                            var newResult = _manager.AddToRoleAsync(newUser, AppRoles.Member).GetAwaiter().GetResult();
                            if (newResult.Succeeded)
                            {
                                Console.WriteLine("User created Successfully");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

            }

            if (!_context.Groups.Any())
            {
                try
                {
                    var user = _context.Users.FirstOrDefault(r => r.Email == "member@gmail.com");
                    var group = _context.Groups.FirstOrDefault(r => r.Name == "Team Lead");

                    _context.Groups.Add(new GroupModel { Name="Team Lead" }); 
                    _context.Groups.Add(new GroupModel { Name="Software Developer" }); 
                    _context.Groups.Add(new GroupModel { Name="Systems Analyst" }); 

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }

            if (!_context.Tasks.Any())
            {
                try
                {
                    var user = _context.Users.FirstOrDefault(r => r.Email == "member@gmail.com");
                    var group = _context.Groups.FirstOrDefault(r => r.Name == "Team Lead");

                    _context.Tasks.Add(new TaskModel { OwnerId = user.Id, GroupId = group.Id, Name = "Requiremnt Gathering", IsComplete = false }); 
                    _context.Tasks.Add(new TaskModel { OwnerId = user.Id, GroupId = group.Id, Name = "Coding", IsComplete = false }); 
                    _context.Tasks.Add(new TaskModel { OwnerId = user.Id, GroupId = group.Id, Name = "Scrum Review", IsComplete = false }); 

                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }



        }
    }
}
