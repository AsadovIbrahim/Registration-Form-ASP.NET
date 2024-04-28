using Register_Form_Project.Models;
using System.Text.Json;
using static Register_Form_Project.Models.JsonHandler;

namespace Register_Form_Project.Services
{
    public static class UserDB
    {
        public static List<User> Users { get; set; } = new();

        static UserDB()
        {
            Users = ReadData<List<User>>("users")!;
        }
    }
}
