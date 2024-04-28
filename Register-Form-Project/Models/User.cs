using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace Register_Form_Project.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }

        
        public User(string name,string surname,string username,string email,string password,string confirmPassword)
        {
            Id= Guid.NewGuid();
            Name=name;
            Surname=surname;
            Username=username;
            Email=email;
            Password=password;
            ConfirmPassword=confirmPassword;
        }
        public User() {
            Id= Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Id:{Id}\nName:{Name}\nSurname:{Surname}\nUsername:{Username}\nEmail:{Email}\nPassword:{Password}\nConfirm Password:{ConfirmPassword}";
        }
    }
}
