using PMA.Data;
using PMA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMA.Services
{
    public class TypeService
    {
        public bool CreateType(TypeCreate model)
        {
            var entity = new MediaType()
            {
                /*TypeId = model.TypeId,*/
                TypeName = model.TypeName,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.MediaTypes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TypeListItem> GetTypes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.MediaTypes.Select(
                    model => new TypeListItem
                    {
                        TypeId = model.TypeId,
                        TypeName = model.TypeName,
                    }
                    );
                return query.ToArray();
            }
        }
        public TypeDetail GetTypeById(int typeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaTypes.Single(e => e.TypeId == typeId);
                return new TypeDetail
                {
                    TypeId = entity.TypeId,
                    TypeName = entity.TypeName,
                    TypeObjects = entity.TypeObjects,
                };
            }
        }
        public bool UpdateType(TypeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaTypes.Single(e => e.TypeId == model.TypeId);
                entity.TypeId = model.TypeId;
                entity.TypeName = model.TypeName;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteType(int typeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.MediaTypes.Single(e => e.TypeId == typeId);
                ctx.MediaTypes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
