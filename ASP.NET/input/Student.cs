﻿namespace TagHelpers_Form01.Models
{
    public class Student
    {
        public string Name { get; set; }   
        public int Age { get; set; }
        public string HP { get; set; }
        public Gender Gender { get; set; }
        public string IsEmployed { get; set; }
        public string Description { get; set; }
    }
    public enum Gender {남,여 }
}
