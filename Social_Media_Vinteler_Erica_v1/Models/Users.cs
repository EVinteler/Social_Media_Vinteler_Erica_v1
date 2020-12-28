using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Social_Media_Vinteler_Erica_v1.Models
{
    public class Users
    {
        // username, email si followers nu pot fi nule
        // username si email trebuie sa fie unice

        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        [NotNull, Unique]
        public string UserName { get; set; } 
        [NotNull, Unique]
        public string UserEmail { get; set; }
        [NotNull]
        public string Password { get; set; }
        [NotNull]
        public int UserFollowers { get; set; } = 0; //automat, vom avea 0 followeri
                                                    // se calculeaza dupa tabelul Followers cu COUNT(*) WHERE FollowedID = UserID
    }
}
