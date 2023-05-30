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
        public static List<MusicAlbum> listOfAlbums = new List<MusicAlbum>()
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
        public  HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, listOfAlbums);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            MusicAlbum album = listOfAlbums.Find(p => p.Id == id);
           
            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Album Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, album);
            
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] MusicAlbum newAlbum)
        {
            foreach(MusicAlbum album in listOfAlbums)
            {
                if (album.Title == newAlbum.Title || album.Id == newAlbum.Id)
                {
                    return Request.CreateResponse(HttpStatusCode.Found, $"Album in list: {album.Title}, {album.Artist} ");
                }
            };

            listOfAlbums.Add(new MusicAlbum { Id = newAlbum.Id, Title = newAlbum.Title, Artist = newAlbum.Artist, Genre = newAlbum.Genre });
            
            return Request.CreateResponse(HttpStatusCode.OK, listOfAlbums);
        }


        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] MusicAlbum updateAlbum)
        {
            MusicAlbum album = listOfAlbums.FirstOrDefault(p => p.Id == id);

            if (album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Album Not Found");

            }

            else
            {
                if (updateAlbum.Title != null)
                { album.Title = updateAlbum.Title; }

                if (updateAlbum.Artist != null)
                { album.Artist = updateAlbum.Artist; }

                if (updateAlbum.Genre != null)
                { album.Genre = updateAlbum.Genre; }

                return Request.CreateResponse(HttpStatusCode.OK, $"Succesful update: {album.Title}, {album.Artist}, {album.Genre}");
            };
            
            
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            /* foreach(MusicAlbum album in listOfAlbum)
             {
                 if (album.Id == id)
                 {
                     listOfAlbum.Remove(album);
                     break;
                 };
             }*/

            MusicAlbum album = listOfAlbums.FirstOrDefault(p => p.Id == id);

            if(album == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Album Not Found");
            }

            listOfAlbums.RemoveAll(p => p.Id == id);

            return Request.CreateResponse(HttpStatusCode.OK, $"Deleted: {album.Title}, {album.Artist}");
            
        }
    }
}
