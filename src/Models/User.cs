using System;

namespace Diabetes.Models
{
    public class User
    {
        public Name Name { get; set; } = new Name();
        public DateTime? Birthdate { get; set; }
    }
}