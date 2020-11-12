using SlothEnterprise.External;
using SlothEnterprise.ProductApplication.DTOs.Applications;
using SlothEnterprise.ProductApplication.DTOs.Products;

namespace SlothEnterprise.ProductApplication.Helpers
{
    public class RequestHelper
    {
        public static CompanyDataRequest CreateCompanyDataRequest(SellerCompanyDataDTO sellerCompanyData)
        {
            return new CompanyDataRequest
            {
                CompanyFounded = sellerCompanyData.Founded,
                CompanyNumber = sellerCompanyData.Number,
                CompanyName = sellerCompanyData.Name,
                DirectorName = sellerCompanyData.DirectorName
            };
        }

        public static LoansRequest CreateLoansRequest(BusinessLoansDTO businessLoans)
        {
            return new LoansRequest
            {
                InterestRatePerAnnum = businessLoans.InterestRatePerAnnum,
                LoanAmount = businessLoans.LoanAmount
            };
        }
    }
}
