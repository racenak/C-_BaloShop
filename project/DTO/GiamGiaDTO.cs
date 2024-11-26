using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   
        public class GiamGiaDTO
        {
            // Properties
            public int OfferId { get; set; }
            public string OfferName { get; set; }
            public string Description { get; set; } // Nullable
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public decimal? DiscountPercentage { get; set; } // Nullable

            // Constructors
            public GiamGiaDTO() { }

            public GiamGiaDTO(int offerId, string offerName, string description, DateTime startDate, DateTime endDate, decimal? discountPercentage)
            {
                OfferId = offerId;
                OfferName = offerName;
                Description = description;
                StartDate = startDate;
                EndDate = endDate;
                DiscountPercentage = discountPercentage;
            }

            // Override ToString for easy debugging
            public override string ToString()
            {
                return $"DiscountDTO {{ OfferId = {OfferId}, OfferName = \"{OfferName}\", Description = \"{Description}\", StartDate = {StartDate}, EndDate = {EndDate}, DiscountPercentage = {DiscountPercentage} }}";
            }
        }
    }
