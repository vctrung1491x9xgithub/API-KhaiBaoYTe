using API_KhaiBaoYTe.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_DataLayer
{
    public class DonViDL
    {
        public IEnumerable<DonVi> GetDonViList()
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.GetDonViList();
            }
        }

        // GET: api/DonVi/5
        public DonVi GetDonViByID(string id)
        {
            using(DBContext dBContext = new DBContext())
            {
                return dBContext.GetDonViByID(id).FirstOrDefault();
            }
        }

        // POST: api/DonVi  
        public bool PostDonVi(DonVi donvi)
        {
            using(DBContext dBContext = new DBContext())
            {
                return dBContext.PostDonVi(donvi);
            }
        }

        // PUT: api/DonVi/5 
        public bool PutDonVi(DonVi donvi)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.PutDonVi(donvi);
            }
        }

        // DELETE: api/DonVi/5 
        public bool DeleteDonVi(string madonvi)
        {
            using (DBContext dBContext = new DBContext())
            {
                return dBContext.DeleteDonVi(madonvi);
            }
        }
    }
}
