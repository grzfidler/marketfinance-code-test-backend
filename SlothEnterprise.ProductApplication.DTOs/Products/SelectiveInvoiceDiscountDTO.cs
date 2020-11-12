using SlothEnterprise.ProductApplication.DTOs.Constants;
using System;

namespace SlothEnterprise.ProductApplication.DTOs.Products
{
    public class SelectiveInvoiceDiscountDTO : ProductDTO, IEquatable<SelectiveInvoiceDiscountDTO>
    {
        /// <summary>
        /// Proposed networth of the Invoice
        /// </summary>
        public decimal InvoiceAmount { get; set; }
        /// <summary>
        /// Percentage of the networth agreed and advanced to seller
        /// </summary>
        public decimal AdvancePercentage { get; set; } = AdvancePercentages.DefaultAdvancePercentage;

        public override bool Equals(object obj)
        {
            return Equals(obj as SelectiveInvoiceDiscountDTO);
        }

        public bool Equals(SelectiveInvoiceDiscountDTO other)
        {
            return other != null &&
                   InvoiceAmount == other.InvoiceAmount &&
                   AdvancePercentage == other.AdvancePercentage;
        }

        public override int GetHashCode()
        {
            int hashCode = -1627869719;
            hashCode = hashCode * -1521134295 + InvoiceAmount.GetHashCode();
            hashCode = hashCode * -1521134295 + AdvancePercentage.GetHashCode();
            return hashCode;
        }
    }
}