using System.Text.Json.Serialization;

namespace CorePlatform.Services.Core.Abstraction.Result
{
    public class PagedResult<T> : ResultInfo<T>
    {
        [JsonInclude]
        public PagedInfo PagedInfo { get; init; }

        public PagedResult(PagedInfo pagedInfo, T value)
            : base(value)
        {
            PagedInfo = pagedInfo;
        }
    }
}
