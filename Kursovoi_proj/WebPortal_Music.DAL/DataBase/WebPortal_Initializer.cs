using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.DAL.DataBase
{
    public class WebPortal_Initializer : DropCreateDatabaseIfModelChanges<WebPortalContext>
    {
        protected override void Seed(WebPortalContext context)
        {
            var userList = new List<Users>()
            {
            new Users(){ LastName = "Моисеенко", FirstName = "Артем", Email = "tyty@mail.ru", Phone = 0993459595 }
            };
            userList.ForEach(s => context.User.Add(s));
            context.SaveChanges();

            var musicList = new List<Music>()
            {
            new Music(){Name_Song = "Пупкин", Singer = "Вася", Time = DateTime.Today }
            };
            musicList.ForEach(s => context.Musics.Add(s));
            context.SaveChanges();

            var singerList = new List<Singer_Group>()
            {
            new Singer_Group(){ Name_Singer = "Пупкин", Genre = "Rock" , Year_Create  = 1995  }
            };
            singerList.ForEach(s => context.Singer_Groups.Add(s));
            context.SaveChanges();

            var genreList = new List<Genre>()
            {
            new Genre(){ Name_Genre = "Rock" }
            };
            genreList.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            var commentList = new List<Comments>()
            {
            new Comments(){ Comment_Description = "Курица ананас", Date_Time = DateTime.Today}
            };
            commentList.ForEach(s => context.Comment.Add(s));
            context.SaveChanges();

        }

    }
}
