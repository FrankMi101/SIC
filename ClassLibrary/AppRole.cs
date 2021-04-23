﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public  class AppRole
    {
        public string AppID { get; set; }
        public string RoleID { get; set; }
        public string ModelID { get; set; }
        public string RoleName { get; set; }
        public string RolePriority { get; set; }
        public string RoleType { get; set; }
        public string Permission { get; set; }
        public string AccessScope { get; set; }
        public string Comments { get; set; }
        public string IDs { get; set; }
    }
    public class AppRoleOperation : AppRole {
        public string Operate { get; set; }
        public string UserID { get; set; }
        public string UserRole { get; set; } 
    }
}
