using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataDAL
{
    public class repository<T> :Singleton, InterRepository<T> where T : class // set t tipinin bir classs olduğunu belirtmiş olduk t tipi yollayacağının garantisi
    {
       
        private DbSet<T> Dbset;

        public repository()
        {
            Dbset = db.Set<T>();
        }
        public List<T> Liste()
        {
            return Dbset.ToList();
        }

        public List<T> Liste(Expression<Func<T,bool>>kosul) 
        {
            return Dbset.Where(kosul).ToList();
        }

        public int Delete(T nesne)
        {
            Dbset.Remove( nesne );
            return db.SaveChanges();
        }

        public int Insert(T nesne)
        {
            Dbset.Add( nesne );
            return db.SaveChanges();
        }

        public int Update(T nesne)
        {
            return db.SaveChanges(); // save edilince zaten en son değeri save ediliyor nesne falan yollamadık ondan

        }

        public T Find(Expression<Func<T, bool>> kosul) // makale falan bulmak aramak istediğimizde bu metodu kullanacağız ama henüz where koşulu ile neyi arayacağımızı seçmedik
        {
            return Dbset.FirstOrDefault(kosul);
        }

        
    }
}
