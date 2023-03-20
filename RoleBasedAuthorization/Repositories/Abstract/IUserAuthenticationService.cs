using RoleBasedAuthorization.Models.DTO;

namespace RoleBasedAuthorization.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationModel(RegistrationModel model);
        Task LogoutAsync();
    }
}
