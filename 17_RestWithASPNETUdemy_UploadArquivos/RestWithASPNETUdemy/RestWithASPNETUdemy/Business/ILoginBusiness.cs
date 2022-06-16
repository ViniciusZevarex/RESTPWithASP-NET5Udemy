using RestWithASPNETUdemy.Data.VO;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string userName);

        Task Register(UserVO user);
    }
}
