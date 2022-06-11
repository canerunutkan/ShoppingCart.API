using Newtonsoft.Json;

namespace ShoppingCart.Data.Repositories.Couchbase.Entity
{
    public abstract class BaseEntity
    {
        [JsonProperty("type")]
        public virtual string Type { get; }
    }
}
