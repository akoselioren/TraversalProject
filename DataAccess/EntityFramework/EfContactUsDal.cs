using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetListContactByFalse()
        {
            using (var context = new Context())
            {
                var values = context.ContactUses.Where(x => x.Status == false).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactByTrue()
        {
            using (var context = new Context())
            {
                var values = context.ContactUses.Where(x => x.Status == true).ToList();
                return values;
            }
        }
    }
}
