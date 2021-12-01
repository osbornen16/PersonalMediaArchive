using PMA.Data;
using PMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Services
{
    public class PlaylistService
    {
        public bool CreatePlaylist(PlaylistCreate model)
        {
            var entity = new MediaPlaylist()
            {
                PlaylistName = model.PlaylistName,
                Description = model.Description,
                Rating = model.Rating,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MediaPlaylists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlaylistListItem> GetPlaylists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.MediaPlaylists.Select(
                    model => new PlaylistListItem
                    {
                        PlaylistId = model.PlaylistId,
                        PlaylistName = model.PlaylistName,
                        Description = model.Description,
                        Rating = model.Rating,
                        PlaylistObjects = model.PlaylistObjects,
                    }
                    );
                return query.ToArray();
            }
        }
        public PlaylistDetail GetPlaylistById(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaPlaylists.Single(e => e.PlaylistId == playlistId);
                return new PlaylistDetail
                {
                    PlaylistId = entity.PlaylistId,
                    PlaylistName = entity.PlaylistName,
                    Description = entity.Description,
                    Rating = entity.Rating,
                    PlaylistObjects = entity.PlaylistObjects,
                };
            }
        }
        public bool UpdatePlaylist(PlaylistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaPlaylists.Single(e => e.PlaylistId == model.PlaylistId);
                entity.PlaylistId = model.PlaylistId;
                entity.PlaylistName = model.PlaylistName;
                entity.Description = model.Description;
                entity.Rating = model.Rating;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePlaylist(int playlistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaPlaylists.Single(e => e.PlaylistId == playlistId);
                ctx.MediaPlaylists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
