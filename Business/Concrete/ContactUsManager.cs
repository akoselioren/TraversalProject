using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TAdd(ContactUs t)
        {
            throw new NotImplementedException();
        }

        public void TContactUsStatusChangeFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void TDelete(ContactUs t)
        {
            throw new NotImplementedException();
        }

        public ContactUs TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> TGetList()
        {
           return _contactUsDal.GetList();
        }

        public List<ContactUs> TGetListContactByFalse()
        {
            return _contactUsDal.GetListContactByFalse();
        }

        public List<ContactUs> TGetListContactByTrue()
        {
            return _contactUsDal.GetListContactByTrue();
        }

        public void TUpdate(ContactUs t)
        {
            throw new NotImplementedException();
        }
    }
}
