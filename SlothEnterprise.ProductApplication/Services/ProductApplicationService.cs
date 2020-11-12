using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.DTOs.Applications;
using SlothEnterprise.ProductApplication.DTOs.Products;
using SlothEnterprise.ProductApplication.Helpers;
using SlothEnterprise.ProductApplication.Interfaces;
using System;

namespace SlothEnterprise.ProductApplication.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly ISelectInvoiceService _selectInvoiceService;
        private readonly IConfidentialInvoiceService _confidentialInvoiceWebService;
        private readonly IBusinessLoansService _businessLoansService;
        private const int _failedResultValue = -1;

        public ProductApplicationService(ISelectInvoiceService selectInvoiceService, IConfidentialInvoiceService confidentialInvoiceWebService, IBusinessLoansService businessLoansService)
        {
            _selectInvoiceService = selectInvoiceService;
            _confidentialInvoiceWebService = confidentialInvoiceWebService;
            _businessLoansService = businessLoansService;
        }

        public int SubmitApplicationFor(SellerApplicationDTO application)
        {

            if (application.Product is SelectiveInvoiceDiscountDTO sid)
            {
                return _selectInvoiceService.SubmitApplicationFor(application.CompanyData.Number.ToString(), sid.InvoiceAmount, sid.AdvancePercentage);
            }

            if (application.Product is ConfidentialInvoiceDiscountDTO cid)
            {
                var result = _confidentialInvoiceWebService.SubmitApplicationFor(
                    RequestHelper.CreateCompanyDataRequest(application.CompanyData), cid.TotalLedgerNetworth, cid.AdvancePercentage, cid.VatRate);

                return (result.Success) ? result.ApplicationId ?? _failedResultValue : _failedResultValue;
            }

            if (application.Product is BusinessLoansDTO loans)
            {
                var result = _businessLoansService.SubmitApplicationFor(
                    RequestHelper.CreateCompanyDataRequest(application.CompanyData), RequestHelper.CreateLoansRequest(loans));

                return (result.Success) ? result.ApplicationId ?? _failedResultValue : _failedResultValue;
            }

            throw new InvalidOperationException();
        }
    }
}
