﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Identity.Menu
{
    public class SetMenuPermissionsRequest
    {
        public Guid MenuId { get; set; }
        public Guid[]? Permissions { get; set; }
    }
}
