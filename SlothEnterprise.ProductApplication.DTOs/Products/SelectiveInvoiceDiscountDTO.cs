﻿using SlothEnterprise.ProductApplication.DTOs.Constants;

namespace SlothEnterprise.ProductApplication.DTOs.Products
{
    public class SelectiveInvoiceDiscountDTO : ProductDTO
    {
        /// <summary>
        /// Proposed networth of the Invoice
        /// </summary>
        public decimal InvoiceAmount { get; set; }
        /// <summary>
        /// Percentage of the networth agreed and advanced to seller
        /// </summary>
        public decimal AdvancePercentage { get; set; } = AdvancePercentages.DefaultAdvancePercentage;
    }
}