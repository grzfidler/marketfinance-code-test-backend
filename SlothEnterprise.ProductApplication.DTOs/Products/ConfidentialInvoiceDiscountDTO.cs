using SlothEnterprise.ProductApplication.DTOs.Constants;
using System;

namespace SlothEnterprise.ProductApplication.DTOs.Products
{
    public class ConfidentialInvoiceDiscountDTO : ProductDTO, IEquatable<ConfidentialInvoiceDiscountDTO>
    {
        public decimal TotalLedgerNetworth { get; set; }
        public decimal AdvancePercentage { get; set; }
        public decimal VatRate { get; set; } = VatRates.UkVatRate;

        public override bool Equals(object obj)
        {
            return Equals(obj as ConfidentialInvoiceDiscountDTO);
        }

        public bool Equals(ConfidentialInvoiceDiscountDTO other)
        {
            return other != null &&
                   TotalLedgerNetworth == other.TotalLedgerNetworth &&
                   AdvancePercentage == other.AdvancePercentage &&
                   VatRate == other.VatRate;
        }

        public override int GetHashCode()
        {
            int hashCode = 156497244;
            hashCode = hashCode * -1521134295 + TotalLedgerNetworth.GetHashCode();
            hashCode = hashCode * -1521134295 + AdvancePercentage.GetHashCode();
            hashCode = hashCode * -1521134295 + VatRate.GetHashCode();
            return hashCode;
        }
    }
}