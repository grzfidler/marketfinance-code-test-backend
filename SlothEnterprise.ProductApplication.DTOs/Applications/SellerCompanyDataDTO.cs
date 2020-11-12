using System;
using System.Collections.Generic;

namespace SlothEnterprise.ProductApplication.DTOs.Applications
{
    public class SellerCompanyDataDTO : IEquatable<SellerCompanyDataDTO>
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string DirectorName { get; set; }
        public DateTime Founded { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SellerCompanyDataDTO);
        }

        public bool Equals(SellerCompanyDataDTO other)
        {
            return other != null &&
                   Name == other.Name &&
                   Number == other.Number &&
                   DirectorName == other.DirectorName &&
                   Founded == other.Founded;
        }

        public override int GetHashCode()
        {
            int hashCode = -1389478146;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DirectorName);
            hashCode = hashCode * -1521134295 + Founded.GetHashCode();
            return hashCode;
        }
    }
}