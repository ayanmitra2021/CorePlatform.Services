using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorePlatform.Services.UseCases.Result
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
