using System.Runtime.Serialization;
using WcfMoto.Model;
using WcfMoto.Utils;

namespace WcfMoto.ViewModels
{
    [DataContract]
    public class BrandForView
    {
        [DataMember]
        public int IdBrand { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        public BrandForView(Brands Brand)
        {
            this.CopyProperties(Brand);
        }
    }
}