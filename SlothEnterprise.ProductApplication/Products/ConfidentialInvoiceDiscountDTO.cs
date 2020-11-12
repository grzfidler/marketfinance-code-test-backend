namespace SlothEnterprise.ProductApplication.Products
{
    public class ConfidentialInvoiceDiscountDTO : ProductDTO
    {
        public decimal TotalLedgerNetworth { get; set; }
        public decimal AdvancePercentage { get; set; }
        public decimal VatRate { get; set; } = VatRates.UkVatRate;
    }
}