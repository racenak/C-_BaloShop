using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.GiamGiaBLL;
using DAL;


namespace BLL
{

    public class GiamGiaBLL

    {
        private GiamGiaDAL GiamGiaDAL = new GiamGiaDAL();
        public List<GiamGiaDTO> GetAllSpecialOffers()
        {
            return GiamGiaDAL.GetAllSpecialOffers();
        }
        public bool AddSpecialOffer(GiamGiaDTO specialOffer)
        {
            return GiamGiaDAL.AddSpecialOffer(specialOffer);
        }
        public bool DeleteSpecialOffer(int offerId)
        {
            return GiamGiaDAL.DeleteSpecialOffer(offerId);
        }
    }

}
