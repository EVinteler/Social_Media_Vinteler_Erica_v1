using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Threading.Tasks;
using Social_Media_Vinteler_Erica_v1.Models;

namespace Social_Media_Vinteler_Erica_v1.Data
{
    public class UsersDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UsersDatabase (string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Users>().Wait();
        }

        // GetUsersAsync se va termina in Async bc of c# naming conventions
        // an async method has to return either void, Task, or Task<T> - returning void should only be used when making an event handler async
        // Task class represents a single operation that does not return a value and that usually executes asynchronously
        // Inheritance: Object -> Task
        // Reverse<T>(T[] array) is like Reverse(string[] array)
        public Task<List<Users>> GetUsersAsync() // returnam o Lista cu obiecte de tip Users, ? folosind Task pt a fi async ?
        {
            return _database.Table<Users>().ToListAsync(); // convertim tabelul Users la List
        }
        public Task<Users> GetUsersAsync (int id) // returnam un obiect din clasa Users
        {
            return _database.Table<Users>()
                .Where(i => i.UserID == id)
                .FirstOrDefaultAsync(); // returneaza primul element gasit sau null
        }
        public Task<int> SaveUsersAsync(Users sUser) // salveaza sau updateaza un element din tabelul Users, anume sUser
        {
            if (sUser.UserID != 0)
            {
                return _database.UpdateAsync(sUser); // daca exista id-ul elementului sUser, doar il updatam
            }
            else
            {
                return _database.InsertAsync(sUser); // daca nu exista un user cu acest ID, inseram elementul sUser
            }
        }
        public Task<int> DeleteUsersAsync(Users sUser)
        {
            return _database.DeleteAsync(sUser);
        }
    }
}
