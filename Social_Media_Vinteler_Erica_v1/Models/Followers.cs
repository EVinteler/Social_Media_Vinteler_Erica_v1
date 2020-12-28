using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Social_Media_Vinteler_Erica_v1.Models
{
    public class Followers
    {
        // cand cineva apasa pe unfollow, vom cauta dupa FollowerID si UserID pentru a sterge valoarea din tabel
        // la fel de fiecare data cand cineva isi sterge contul
        
        [PrimaryKey, AutoIncrement]
        public int FollowID { get; set; } [NotNull]
        public string FollowedID { get; set; } // textul continut de post
        [NotNull]
        public int FollowerID { get; set; }
    }
}
