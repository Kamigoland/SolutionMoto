using AppMobileMoto.Utils;
using ServiceReferenceMoto;

namespace AppMobileMoto.Models
{
    class Brand
    {
        public int IdBrand { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Brand() { }

        public static implicit operator BrandForView(Brand Brand)
        {
            var res = new BrandForView();
            res.CopyProperties(Brand);
            return res;
        }
        public Brand(BrandForView Brand)
        {
            this.CopyProperties(Brand);
        }
    }
}
