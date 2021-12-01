using PMA.Data;
using PMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Services
{
    public class ObjectService
    {
        public bool CreateObject(ObjectCreate model)
        {
            var entity = new MediaObject()
            {

                ObjectName = model.ObjectName,
                Contributor = model.Contributor,
                Description = model.Description,
                TypeId = model.TypeId,
                PlaylistId = model.PlaylistId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MediaObjects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ObjectListItem> GetObjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.MediaObjects.Select(
                    model => new ObjectListItem
                    {
                        ObjectId = model.ObjectId,
                        ObjectName = model.ObjectName,
                        Contributor = model.Contributor,
                        Description = model.Description,
                        TypeId = model.TypeId,
                        PlaylistId = model.PlaylistId
                    }
                    );
                return query.ToArray();
            }
        }
        public ObjectDetail GetObjectById(int objectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaObjects.Single(e => e.ObjectId == objectId);
                return new ObjectDetail
                {
                    ObjectId = entity.ObjectId,
                    ObjectName = entity.ObjectName,
                    Description = entity.Description,
                    TypeId = entity.TypeId,
                    PlaylistId = entity.PlaylistId
                };
            }
        }
        public bool UpdateObject(ObjectEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaObjects.Single(e => e.ObjectId == model.ObjectId);
                entity.ObjectId = model.ObjectId;
                entity.ObjectName = model.ObjectName;
                entity.Contributor = model.Contributor;
                entity.Description = model.Description;
                entity.TypeId = model.TypeId;
                entity.PlaylistId = model.PlaylistId;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteObject(int objectId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaObjects.Single(e => e.ObjectId == objectId);
                ctx.MediaObjects.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
