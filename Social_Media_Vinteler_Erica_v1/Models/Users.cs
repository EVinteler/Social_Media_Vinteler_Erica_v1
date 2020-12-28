using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Social_Media_Vinteler_Erica_v1.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        [NotNull]
        public string UserName { get; set; } // username, email si followers nu pot fi nule
        [NotNull]
        public string UserEmail { get; set; }
        [NotNull]
        public int UserFollowers { get; set; } = 0; //automat, vom avea 0 followeri
    }
}
