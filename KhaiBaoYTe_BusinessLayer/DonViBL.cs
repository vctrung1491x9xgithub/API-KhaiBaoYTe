using API_KhaiBaoYTe.Entities;
using KhaiBaoYTe_DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaiBaoYTe_BusinessLayer
{
    public class DonViBL
    {
        public IEnumerable<DonVi> GetDonViList()
        {
            var donViDL = new DonViDL();
            var donVi = donViDL.GetDonViList();
            return donVi;
        }

        // GET: api/DonVi/5
        public DonVi GetDonViByID(string id)
        {
            var donViDL = new DonViDL();
            var donVi = donViDL.GetDonViByID(id);
            return donVi;
        }

        // POST: api/DonVi  
        public bool PostDonVi(DonVi donvi)
        {
            var donViDL = new DonViDL();
            var donVi = donViDL.PostDonVi(donvi);
            return donVi;
        }

        // PUT: api/DonVi/5 
        public bool PutDonVi(DonVi donvi)
        {
            var donViDL = new DonViDL();
            var donVi = donViDL.PutDonVi(donvi);
            return donVi;
        }

        // DELETE: api/DonVi/5 
        public bool DeleteDonVi(string madonvi)
        {
            var donViDL = new DonViDL();
            var donVi = donViDL.DeleteDonVi(madonvi);
            return donVi;
        }
    }
}
