using SlothEnterprise.ProductApplication.DTOs.Products;
using System;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.DTOs.Applications
{
    public class SellerApplicationDTO : IEquatable<SellerApplicationDTO>
    {
        public ProductDTO Product { get; set; }
        public SellerCompanyDataDTO CompanyData { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SellerApplicationDTO);
        }

        public bool Equals(SellerApplicationDTO other)
        {
            return other != null &&
                   EqualityComparer<ProductDTO>.Default.Equals(Product, other.Product) &&
                   EqualityComparer<SellerCompanyDataDTO>.Default.Equals(CompanyData, other.CompanyData);
        }

        public override int GetHashCode()
        {
            int hashCode = -73314800;
            hashCode = hashCode * -1521134295 + EqualityComparer<ProductDTO>.Default.GetHashCode(Product);
            hashCode = hashCode * -1521134295 + EqualityComparer<SellerCompanyDataDTO>.Default.GetHashCode(CompanyData);
            return hashCode;
        }
    }
}