using System.Collections.Generic;

namespace DFS.Services
{
    public class UserModel
    {
        public int id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string token { get; set; }
        public string contact { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int roleId { get; set; }
        public int clientId { get; set; }
        public List<Module> modules { get; set; }

    }

    public class Module
    {
        public int id { get; set; }
        public string name { get; set; }
        public string className { get; set; }
        public string linkToRouter { get; set; }
        public List<object> subModules { get; set; }

    }
}