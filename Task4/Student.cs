using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string DateOfBirth { get; set; }
        public Student(string name, string group, string dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
}
