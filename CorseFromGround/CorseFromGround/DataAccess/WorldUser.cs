﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseFromGround.DataAccess
{
    public class WorldUser : IdentityUser
    {
        public DateTime FirstTrip { get; set; }
    }
}
