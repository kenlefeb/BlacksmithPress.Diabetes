using System;

namespace Diabetes.Models
{
    public class Patient : User
    {
        public DateTime Diagnosed { get; set; }
    }
}