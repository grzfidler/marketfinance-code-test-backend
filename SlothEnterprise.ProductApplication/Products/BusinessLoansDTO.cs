﻿namespace SlothEnterprise.ProductApplication.Products
{
    public class BusinessLoansDTO : ProductDTO
    {
        /// <summary>
        /// Per annum interest rate
        /// </summary>
        public decimal InterestRatePerAnnum { get; set; }

        /// <summary>
        /// Total available amount to withdraw
        /// </summary>
        public decimal LoanAmount { get; set; }
    }
}