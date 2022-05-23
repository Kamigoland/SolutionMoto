using System.Runtime.Serialization;
using WcfMoto.Model;
using WcfMoto.Utils;

namespace WcfMoto.ViewModels
{
    [DataContract]
    public class UserForView
    {
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool IsActive { get; set; }

        public static implicit operator Users(UserForView user)
        {
            var res = new Users();
            res.CopyProperties(user);
            return res;
        }
        public UserForView() { }
        public UserForView(UserForView user)
        {
            this.CopyProperties(user);
        }
        public UserForView(Users user) {
            this.CopyProperties(user);
        }
    }
}