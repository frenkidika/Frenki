using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Currency_Exchange2022.Models
{
    public class Person
    {
        static Dictionary<string, string[]> registeredUsers = new Dictionary<string, string[]>()
        {
            {"admin", new string[] {"pass:Admin@2022","name:admin","role:admin"}},
            {"user1", new string[] {"name:user1", "pass:User1@2022","surname:user1Surname","role:user" }},
            {"user2", new string[] {"name:user2", "pass:User2@2022","surname:user2Surname","role:user" }},

        };
        public string Name { get; set; }


        public string Email { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public int ID { get; set; }

        public DateTime Birthday { get; set; }

        private static bool Login(out string username)
        {
            Console.Write("Jep username: ");
            username = Console.ReadLine();
            Console.Write("Jep password: ");
            string pass = Console.ReadLine();
            if (!registeredUsers.ContainsKey(username))
                return false;
            pass = "pass:" + pass;
            for (int i = 0; i < registeredUsers[username].Length; i++)
            {
                if (registeredUsers[username][i] == pass)
                {
                    return true;
                }
            }
            Console.WriteLine("Kredinciale te pasakta");
            return false;

        }
    }



}