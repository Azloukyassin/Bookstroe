using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.Models.Repositories
{
    public interface IBookstoreRepoository<TEntity>
    {
        IList<TEntity> liste();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id , TEntity entity);
        void Delete(int id);
        List<TEntity> Serach(string term); 
        
    }
}
