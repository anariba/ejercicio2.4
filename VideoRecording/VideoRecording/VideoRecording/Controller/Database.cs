using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoRecording.Models;

namespace VideoRecording.Controller
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;

        public Database(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Video>().Wait();
        }

        // Get All Videos
        public Task<List<Video>> getListVideos()
        {
            return db.Table<Video>().ToListAsync();
        }

        // Get Video by Code
        public Task<Video> getVideoByCode(int codeParam)
        {
            return db.Table<Video>()
                .Where(i => i.code == codeParam)
                .FirstOrDefaultAsync();
        }

        // Create person
        public Task<int> saveVideo(Video Video)
        {
            if (Video.code != 0)
            {
                return db.UpdateAsync(Video);
            }
            else
            {
                return db.InsertAsync(Video);
            }

        }

        public Task<int> deleteVideo(Video Video)
        {
            return db.DeleteAsync(Video);
        }
    }
}
