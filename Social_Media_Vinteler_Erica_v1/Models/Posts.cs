using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Social_Media_Vinteler_Erica_v1.Models
{
    public class Posts
    {
        [PrimaryKey, AutoIncrement]
        public int PostID { get; set; }
        [NotNull]
        public string PostText { get; set; } // textul continut de post
        [NotNull]
        public string UserID { get; set; } // id-ul userului care l-a postat
        [NotNull]
        public int PostLikes { get; set; } = 0; //automat, posturile vor avea 0 likes
                                                // daca este apasat butonul de Like la un post, incrementam valoarea cu 1
                                                // daca butonul era apasat si apasam din nou, scadem valoarea cu 1
    }
}
