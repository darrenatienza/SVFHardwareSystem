﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVFHardwareSystem.DAL.Entities
{
    public class User
    {
        public User() { }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}