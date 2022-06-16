using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
        Task Register(UserVO userVO);
    }
}
