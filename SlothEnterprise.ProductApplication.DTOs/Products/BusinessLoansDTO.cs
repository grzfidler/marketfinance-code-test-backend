namespace SlothEnterprise.ProductApplication.DTOs.Products
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

        public override bool Equals(object obj)
        {
            return obj is BusinessLoansDTO dTO &&
                   InterestRatePerAnnum == dTO.InterestRatePerAnnum &&
                   LoanAmount == dTO.LoanAmount;
        }

        public override int GetHashCode()
        {
            int hashCode = 1972863316;
            hashCode = hashCode * -1521134295 + InterestRatePerAnnum.GetHashCode();
            hashCode = hashCode * -1521134295 + LoanAmount.GetHashCode();
            return hashCode;
        }
    }
}