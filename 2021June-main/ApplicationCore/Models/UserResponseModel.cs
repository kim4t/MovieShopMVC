﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
