using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Threading.Tasks;
using Social_Media_Vinteler_Erica_v1.Models;

namespace Social_Media_Vinteler_Erica_v1.Data
{
    public class FollowersDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public FollowersDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Followers>().Wait();
        }

        public Task<List<Followers>> GetFollowersAsync() // returnam o Lista cu obiecte de tip Followers
        {
            return _database.Table<Followers>().ToListAsync(); // convertim tabelul Followers la List
        }
        public Task<Followers> GetFollowersAsync(int id) // returnam un obiect din clasa Followers
        {
            return _database.Table<Followers>()
                .Where(i => i.FollowID == id)
                .FirstOrDefaultAsync(); // returneaza primul element gasit sau null
        }
        public Task<int> SaveFollowersAsync(Followers sFollower) // salveaza sau updateaza un element din tabelul Followers, anume sFollower
        {
            if (sFollower.FollowID != 0)
            {
                return _database.UpdateAsync(sFollower); // daca exista id-ul elementului sFollower, doar il updatam
            }
            else
            {
                return _database.InsertAsync(sFollower); // daca nu exista un follower cu acest ID, inseram elementul sFollower
            }
        }
        public Task<int> DeleteFollowersAsync(Followers sFollower)
        {
            return _database.DeleteAsync(sFollower);
        }
    }
}