using Application.Dtos;
using Application.Dtos.NewsAnnouncementCategory;
using Application.Models.Paginator;
using Humanizer;
using X.PagedList;

namespace Application.Configurations.PaginationTable;


public class NewsAnnouncementPaginationOptions : PaginationTableOptions {

    public NewsAnnouncementPaginationOptions(IPagedList<Dto> model) : base(model) {
        SelectedHeaderNames = new[] { "Image", "Title", "Description", "Active", "NewsAnnouncementCategoryDto" };
        CustomHeaderNames = new Dictionary<string, string>() {
            {"Image", "Resim"},
            {"Title", "Başlık"},
            {"Description", "Açıklama"},
            {"Active", "Aktif Mi?"},
            {"NewsAnnouncementCategoryDto", "Kategori"}
        };
        Filters = new Dictionary<string, Func<object, string>>() {
            {"Description", x=> ((string)x).Truncate(50)},
            {"Active", x => ((bool)x)==true ? HTML["Approve"] : HTML["Deny"]},
            {"Image", x=> ((string)x)=="" ? HTML["Deny"] : HTML["Approve"]},
            {"NewsAnnouncementCategoryDto", x=> ((NewsAnnouncementCategoryDto)x).Name}
        };
    }


}
