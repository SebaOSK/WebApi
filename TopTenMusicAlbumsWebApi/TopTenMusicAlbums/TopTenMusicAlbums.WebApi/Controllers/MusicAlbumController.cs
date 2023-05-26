using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TopTenMusicAlbums.WebApi.Models;

namespace TopTenMusicAlbums.WebApi.Controllers
{
    public class MusicAlbumController : ApiController
    {
        public static List<MusicAlbum> listOfAlbums = new List<MusicAlbum>
                {
            new MusicAlbum{Id = 1, Title = "The Nashville Session", Artist = "The New Mastersounds", Genre = "Funk"},
            new MusicAlbum{Id = 2, Title = "Kind Of Blue", Artist = "Miles Davis", Genre = "Jazz"},
            new MusicAlbum{Id = 3, Title = "Tragic Kingdom", Artist = "No Doubt", Genre = "Punk Rock"},
            new MusicAlbum{Id = 4, Title = "Texas Sun", Artist = "Khruangbin", Genre = "World Music"},
            new MusicAlbum{Id = 5, Title = "Funk Overload", Artist = "Maceo Parker", Genre = "Funk Jazz"},
            new MusicAlbum{Id = 6, Title = "Renegades", Artist = "RATM", Genre = "Punk Rock"},
            new MusicAlbum{Id = 7, Title = "In Bloom", Artist = "Nirvana", Genre = "Grunge"},
            new MusicAlbum{Id = 8, Title = "Close But No Cigar", Artist = "Delvon Lamarr Trio", Genre = "Funk Jazz"},
            new MusicAlbum{Id = 9, Title = "Nerve", Artist = "Nerve", Genre = "Drum'n'Bass"},
            new MusicAlbum{Id = 10, Title = "We Like It Here", Artist = "Snarky Puppy", Genre = "Jazz"},

        };
        
        // GET api/values
        public  List<MusicAlbum> Get()
        {
            return listOfAlbums;
        }

        // GET api/values/5
        public MusicAlbum Get(int id)
        {
            return listOfAlbums.Find(p => p.Id == id);
        }

        // POST api/values
        public MusicAlbum Post([FromBody] MusicAlbum newAlbum)
        {
            listOfAlbums.Add(new MusicAlbum { Id = newAlbum.Id, Title = newAlbum.Title, Artist = newAlbum.Artist, Genre = newAlbum.Genre });
            return listOfAlbums.Find(p => p.Id==newAlbum.Id);
        }


        // PUT api/values/5
        public MusicAlbum Put(int id, [FromBody] MusicAlbum updateAlbum)
        {
            MusicAlbum album = listOfAlbums.FirstOrDefault(p => p.Id == id);

            if (album.Id != 0)
            {
                album.Title  = updateAlbum.Title;
                album.Artist = updateAlbum.Artist;
                album.Genre = updateAlbum.Genre;

            }
            return listOfAlbums[album.Id];
        }

        // DELETE api/values/5
        public List<MusicAlbum> Delete(int id)
        {
            /* foreach(MusicAlbum album in listOfAlbum)
             {
                 if (album.Id == id)
                 {
                     listOfAlbum.Remove(album);
                     break;
                 };
             }*/
            listOfAlbums.RemoveAll(p => p.Id == id);
            return listOfAlbums;
        }
    }
}
