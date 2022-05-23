using ServiceReferenceMoto;
using AppMobileMoto.Utils;
namespace AppMobileMoto.Models
{
    public class Client
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Client() { }

        public static implicit operator UserForView(Client user)
        {
            var res = new UserForView();
            res.CopyProperties(user);
            return res;
        }
        public Client(UserForView client)
        {
            this.CopyProperties(client);
        }

    }
}
