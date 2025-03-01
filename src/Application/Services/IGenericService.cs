using Application.Models.Common;

namespace Application.Services
{
    public interface IGenericService<T, TAddModel, TUpdateModel, TResponseModel>
    {
        Task<Result<TResponseModel>> GetByIdAsync(string id);
        Task<Result<string>> AddAsync(TAddModel model);
        Task<Result<string>> UpdateAsync(TUpdateModel model);
        Task<Result<string>> DeleteAsync(Guid id);
    }
}
