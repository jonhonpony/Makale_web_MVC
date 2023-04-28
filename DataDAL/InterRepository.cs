using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataDAL
{
    public interface InterRepository<T>
    {
        int Insert(T nesne);
        int Update(T nesne);
        int Delete(T nesne);

        List<T> Liste();

        List<T> Liste(Expression<Func<T, bool>> kosul);// koşul expression göndereceğimiz  için bu şekilde yazdık 

        T Find(Expression<Func<T, bool>> kosul);



    }
}
