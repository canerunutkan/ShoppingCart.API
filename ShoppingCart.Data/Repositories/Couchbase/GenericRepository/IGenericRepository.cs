using Couchbase.KeyValue;
using ShoppingCart.Data.Repositories.Couchbase.Entity;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IGetResult> GetAsync(string id, GetOptions options = null);
        Task<IMutationResult> InsertAsync(string id, T content, InsertOptions options = null);
        Task RemoveAsync(string id, RemoveOptions options = null);
        Task<IMutationResult> ReplaceAsync(string id, T content, ReplaceOptions options = null);
        Task<IMutationResult> UpsertAsync(string id, T content, UpsertOptions options = null);
        Task<IExistsResult> ExistsAsync(string id);
    }
}
