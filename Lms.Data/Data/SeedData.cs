﻿using Bogus;
using Lms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Data
{
    public class SeedData
    {
        public static async Task InitAsync(IServiceProvider services)
        {
            using (var db = new LmsAPIContext(services.GetRequiredService<DbContextOptions<LmsAPIContext>>()))
            {
                var fake = new Faker("sv");

                if (db.Courses.Any())
                {
                    return;
                }

                var modules = GetModules();
                var courses = GetCourses();

                for (int i = 0; i < 30; i += 3)
                {
                    var list = modules.Skip(i).ToList();


                    foreach (var course in courses)
                    {
                        if (course.Modules != null)
                        {
                            continue;
                        }
                        course.Modules = list.Take(3).ToList();
                        break;
                    }

                }

                //for (int i = 0; i < 10; i+=3)
                //{
                //    var list = modules.Skip(i).ToList();
                //foreach (var course in courses)
                //{
                //        course.Modules = list.Take(3).ToList();
                //        break;
                //}

                //}
                
                await db.AddRangeAsync(courses);

                await db.SaveChangesAsync();
            };
        }

        private static List<Module> GetModules()
        {
            var fake = new Faker("sv");
            var modules = new List<Module>();
            for (int i = 0; i < 30; i++)
            {
                var module = new Module
                {
                    Title = fake.Name.JobTitle(),
                    StartDate = fake.Date.Soon()

                };
                modules.Add(module);
            }
            return modules;
        }

        private static List<Course> GetCourses()
        {
            var fake = new Faker("sv");
            var courses = new List<Course>();
            for (int i = 0; i < 10; i++)
            {
                var course = new Course
                {
                    Title = fake.Company.CatchPhrase(),
                    StartDate = DateTime.Now.AddDays(fake.Random.Int(-2, 2)),
                };
                courses.Add(course);
            }
            return courses;
        }
        //private static List<Module> GetThreeModules(List<Module> modules)
        //{

        //    var list = new List<Module>();
        //    for (int i = 0; i < 10; i+=3)
        //    {
        //        var result = modules.Skip(i).Take(3).ToList();
        //        foreach (var item in result)
        //        {
        //        list.Add(item);
        //            return list;
        //        } 

        //    }

        //}
        private static List<Module> GetRandomModules(List<Module> modules)
        {
            var rand = new Random();
            var rand2 = new Random();
            var skipped = rand.Next(0, 5);
            var taken = rand2.Next(1, 24);

            var result = modules.Skip(skipped).Take(taken).ToList();

            //var result = new List<Module>();

            //for (int i = 0; i < rand.Next(2,10); i++)
            //{
            //    result.Add(modules[rand2.Next(0, 30)]);
            //}

            return result;
        }
    }
}
