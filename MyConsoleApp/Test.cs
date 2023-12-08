using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyConsoleApp
{
    class Test
    {
        public class User
        {          
            public int Id { get; set; } // property
            public string Name { get; set; }
            public DateTime Registered { get; set; }
            public bool IsActive { get; set; }

            public User()
            {
               
            }
        }

        public static void RunTest()
        {
            Console.WriteLine("Starting Test");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<User> users = new List<User> 
            { 
                new User { Id = 1111111, Name = "Andrew", Registered = new DateTime(2023,01,01), IsActive = true },
                new User { Id = 2222222, Name = "Barbara", Registered = new DateTime(2023,02,02), IsActive = false },
                new User { Id = 3333333, Name = "Colin", Registered = new DateTime(2023,03,03), IsActive = false },
                new User { Id = 4444444, Name = "Daphne", Registered = new DateTime(2023,04,04), IsActive = true },
            };

            foreach (User user in users)
            {
                Console.WriteLine("Id: {0} - Name: {1} - Registered: {2} - IsActive: {3}", user.Id, user.Name, user.Registered, user.IsActive);
            }

            sw.Stop();
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
        }

    }
}
