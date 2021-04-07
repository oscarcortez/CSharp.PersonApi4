namespace PersonApi4.DataAccess
{
    using PersonApi4.Models;
    using PersonApi4.Models.Contexts;
    using PersonApi4.Toolkit;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Collections;

    public class StorageProvider<GenericModel> : IStorageProvider<GenericModel> where GenericModel : class  //
    {

        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
        }

        public async Task<IQueryable<GenericModel>> Get()
        {
            List<GenericModel> result = new();
            using (PersonDBContext context = new())
            {
                result = await context.Set<GenericModel>().ToListAsync();
            }
            return result.AsQueryable();
        }

        public string Get(string storeProcedure)
        {
            //string result = "";
            //using (var context = new PersonDBContext())
            //{
            //    result = result = JsonConvert.SerializeObject(context.ViewFormattedPeople.ToList());
            //}
            //return result;

            return "{}";
        }

        public Task<GenericModel> Save(GenericModel model)
        {
            using (var context = new PersonDBContext())
            {
                context.Add(model);
                context.SaveChanges();
            }

            return Task.FromResult(model);
        }

        public Task<string> Save(string storeProcedure)
        {
            string result = "";
            using (var context = new PersonDBContext())
            {
                //result = JsonConvert.SerializeObject(context.ViewFormattedPeople.FromSql(storeProcedure).ToList());
            }

            return Task.FromResult(result);
        }
    }
}
