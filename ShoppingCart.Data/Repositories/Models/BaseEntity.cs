using Newtonsoft.Json;

namespace ShoppingCart.Data.Repositories.Models
{
    public abstract class BaseEntity
    {
        [JsonProperty("type")]
        public virtual string Type { get; }
    }
}
