using Application.Dtos;
using Application.Models.Paginator;
using Humanizer;
using X.PagedList;

namespace Application.Configurations.PaginationTable;

public class GrantSupportPaginationOptions : PaginationTableOptions {

    public GrantSupportPaginationOptions(IPagedList<Dto> model): base(model) {
        SelectedHeaderNames = new[] { "Image", "Title", "Description", "Active" };

        CustomHeaderNames = new Dictionary<string, string>() {
            {"Image", "Resim"},
            {"Title", "Başlık"},
            {"Description", "Açıklama"},
            {"Active", "Aktif mi?"}
        };

        Filters = new Dictionary<string, Func<object, string>>() {
            {"Description", x=> ((string)x).Truncate(50)},
            {"Active", x => ((bool)x)==true ? HTML["Approve"] : HTML["Deny"]},
            {"Image", x=> ((string)x)=="" ? HTML["Deny"] : HTML["Approve"]}
        };

    }

}
