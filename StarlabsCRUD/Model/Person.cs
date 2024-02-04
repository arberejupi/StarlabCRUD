﻿using System.ComponentModel.DataAnnotations;

namespace StarlabsCRUD.Model
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
