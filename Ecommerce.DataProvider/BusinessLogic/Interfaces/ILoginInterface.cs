using Azure;
using Ecommerce.Domain.DTO_Classes;
using Ecommerce.Domain.Respoances;
using System.Text.Json;

namespace Ecommerce.DataProvider.BusinessLogic.Interfaces
{
    public interface ILoginInterface
    {
        Task<UserRespoance> RegisterUser(UserProperties userProperties);

        Task<LoginRespoance> LoginUser(string Email , string password);

        Task<UserRespoance> DeleteUser(int ID);

        Task<UserRespoance> UpdateDataPatch(int iD, Microsoft.AspNetCore.JsonPatch.JsonPatchDocument user);
    }
}
