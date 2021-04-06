namespace PersonApi4.Toolkit
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IStorageProvider{StorageType}" />
    /// </summary>
    /// <typeparam name="StorageType"></typeparam>
    public interface IStorageProvider<StorageType>
    {
        /// <summary>
        /// The Save
        /// </summary>
        /// <param name="obj">The obj<see cref="StorageType"/></param>
        /// <returns>The <see cref="Task{StorageType}"/></returns>
        Task<StorageType> Save(StorageType obj);

        Task<string> Save(string storeProcedure);

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="IQueryable{StorageType}"/></returns>
        IQueryable<StorageType> Get();

        string Get(string storeProcedure);
    }
}
