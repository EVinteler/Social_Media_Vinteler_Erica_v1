using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Threading.Tasks;
using Social_Media_Vinteler_Erica_v1.Models;

namespace Social_Media_Vinteler_Erica_v1.Data
{
    public class PostsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public PostsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Posts>().Wait();
        }

        public Task<List<Posts>> GetPostsAsync() // returnam o Lista cu obiecte de tip Posts
        {
            return _database.Table<Posts>().ToListAsync(); // convertim tabelul Posts la List
        }
        public Task<Posts> GetPostsAsync(int id) // returnam un obiect din clasa Posts
        {
            return _database.Table<Posts>()
                .Where(i => i.PostID == id)
                .FirstOrDefaultAsync(); // returneaza primul element gasit sau null
        }
        public Task<int> SavePostsAsync(Posts sPost) // salveaza sau updateaza un element din tabelul Posts, anume sPost
        {
            if (sPost.PostID != 0)
            {
                return _database.UpdateAsync(sPost); // daca exista id-ul elementului sPost, doar il updatam
            }
            else
            {
                return _database.InsertAsync(sPost); // daca nu exista un post cu acest ID, inseram elementul sPost
            }
        }
        public Task<int> DeletePostsAsync(Posts sPost)
        {
            return _database.DeleteAsync(sPost);
        }
    }
}
