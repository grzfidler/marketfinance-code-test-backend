using AutoFixture;
using NSubstitute;
using SlothEnterprise.External;
using SlothEnterprise.External.V1;
using SlothEnterprise.ProductApplication.DTOs.Applications;
using SlothEnterprise.ProductApplication.DTOs.Products;
using SlothEnterprise.ProductApplication.Services;
using Xunit;

namespace SlothEnterprise.ProductApplication.Tests
{
    public class ProductApplicationTests
    {
        private readonly Fixture _fixture;

        private ISelectInvoiceService _sidService;
        private IConfidentialInvoiceService _cidService;
        private IBusinessLoansService _loansService;
        public ProductApplicationTests()
        {
            _fixture = new Fixture();

            SetupServices();
        }

        private void SetupServices()
        {
            _sidService = Substitute.For<ISelectInvoiceService>();
            _cidService = Substitute.For<IConfidentialInvoiceService>();
            _loansService = Substitute.For<IBusinessLoansService>();
        }

        [Fact]
        public void SubmitApplicationFor_SelectInvoiceService()
        {
            var sidProduct = _fixture.Build<SelectiveInvoiceDiscountDTO>().Create();
            var companyData = _fixture.Build<SellerCompanyDataDTO>().Create();
            var application = _fixture.Build<SellerApplicationDTO>()
                .With(a => a.Product, sidProduct)
                .With(a => a.CompanyData, companyData)
                .Create();

            int applicationIdResult = 100;

            _sidService
                .SubmitApplicationFor(application.CompanyData.Number.ToString(), sidProduct.InvoiceAmount, sidProduct.AdvancePercentage)
                .Returns(applicationIdResult);

            var service = new ProductApplicationService(_sidService, _cidService, _loansService);
            var result = service.SubmitApplicationFor(application);

            _sidService.Received(1).SubmitApplicationFor(application.CompanyData.Number.ToString(), sidProduct.InvoiceAmount, sidProduct.AdvancePercentage);

            Assert.Equal(applicationIdResult, result);
        }

        [Fact]
        public void SubmitApplicationFor_ConfidentialInvoiceService()
        {
            var cidProduct = _fixture.Build<ConfidentialInvoiceDiscountDTO>().Create();
            var companyData = _fixture.Build<SellerCompanyDataDTO>().Create();
            var application = _fixture.Build<SellerApplicationDTO>()
                .With(a => a.Product, cidProduct)
                .With(a => a.CompanyData, companyData)
                .Create();

            IApplicationResult applicationIdResult = Substitute.For<IApplicationResult>();
            applicationIdResult.Success.Returns(true);
            applicationIdResult.ApplicationId.Returns(100);

            _cidService
                .SubmitApplicationFor(Arg.Any<CompanyDataRequest>(), cidProduct.TotalLedgerNetworth, cidProduct.AdvancePercentage, cidProduct.VatRate)
                .Returns(applicationIdResult);

            var service = new ProductApplicationService(_sidService, _cidService, _loansService);
            var result = service.SubmitApplicationFor(application);

            _cidService.Received(1).SubmitApplicationFor(
                Arg.Any<CompanyDataRequest>(), cidProduct.TotalLedgerNetworth, cidProduct.AdvancePercentage, cidProduct.VatRate);

            Assert.Equal(applicationIdResult.ApplicationId, result);
        }

        [Fact]
        public void SubmitApplicationFor_BusinessLoansService()
        {
            var loansProduct = _fixture.Build<BusinessLoansDTO>().Create();
            var companyData = _fixture.Build<SellerCompanyDataDTO>().Create();
            var application = _fixture.Build<SellerApplicationDTO>()
                .With(a => a.Product, loansProduct)
                .With(a => a.CompanyData, companyData)
                .Create();

            IApplicationResult applicationIdResult = Substitute.For<IApplicationResult>();
            applicationIdResult.Success.Returns(true);
            applicationIdResult.ApplicationId.Returns(100);

            _loansService.SubmitApplicationFor(Arg.Any<CompanyDataRequest>(), Arg.Any<LoansRequest>())
                .Returns(applicationIdResult);

            var service = new ProductApplicationService(_sidService, _cidService, _loansService);
            var result = service.SubmitApplicationFor(application);

            _loansService.Received(1).SubmitApplicationFor(Arg.Any<CompanyDataRequest>(), Arg.Any<LoansRequest>());

            Assert.Equal(applicationIdResult.ApplicationId, result);
        }
    }
}
