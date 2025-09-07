using Application.Dtos;
using Application.Models.Paginator;
using Humanizer;
using X.PagedList;

namespace Application.Configurations.PaginationTable
{
    public class ProductGrowingSuggestionPaginationOptions :PaginationTableOptions
    {
        public ProductGrowingSuggestionPaginationOptions(IPagedList<Dto> model) : base(model)
        {
            SelectedHeaderNames = new[] { "Image", "Title", "Description", "Active" };
            CustomHeaderNames = new Dictionary<string, string>() {
            {"Image", "Resim"},
            {"Title", "Başlık"},
            {"Description", "Açıklama"},
            {"Active", "Aktiflik"}
        };
            Filters = new Dictionary<string, Func<object, string>>() {
            {"Active", x => ((bool)x)==true ? HTML["Approve"] : HTML["Deny"]},
            {"Description", x=> ((string)x).Truncate(50)},
            {"Image", x=> ((string)x)=="" ? HTML["Deny"] : HTML["Approve"]}
        };
        }

    }
}
