﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; private set; }

        public List<SeatDatePair> BookedSeats = new List<SeatDatePair>();

        public User(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
    }
}
