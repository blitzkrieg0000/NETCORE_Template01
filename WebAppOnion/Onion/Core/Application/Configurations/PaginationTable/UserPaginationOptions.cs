using Application.Dtos;
using Application.Models.Paginator;
using Humanizer;
using X.PagedList;

namespace Application.Configurations.PaginationTable;


public class UserPaginationOptions : PaginationTableOptions {
    public UserPaginationOptions(IPagedList<Dto> model) : base(model) {
        // SelectedHeaderNames = new[] { "Image", "Title", "Description", "Active" };
        CustomHeaderNames = new Dictionary<string, string>() {
            {"Name", "İsim"},
            {"Username", "Kullanıcı Adı"},
            {"EmailApproved", "Email Onayı"},
            {"PhoneNumber", "Telefon Numarası"},
            {"Password", "Parola"},
            {"Gender", "Cinsiyet"},
            {"Description", "Açıklama"},
            {"TwoFactorEnabled", "Çift Taraflı Doğrulama"},
            {"AccessFailedCount", "Başarısız Oturum Açma"},
            {"PhoneNumberApproved", "Telefon Onayı"},
            {"LockoutEnabled","Hesap Kilitleme"},
            {"Active", "Aktif"},
            {"IsPersistent", "Kalıcı"}
        };
        Filters = new Dictionary<string, Func<object, string>>() {
            {"Description", x=> ((string)x).Truncate(50)},
            {"Password", x => ((string)x)=="" ? HTML["Deny"] : HTML["Approve"]},
            {"Active", x=> ((bool)x)==true ? HTML["Approve"]: HTML["Deny"]},
            {"EmailApproved", x=> ((bool)x)==true ? HTML["Approve"]: HTML["Deny"]},
            {"TwoFactorEnabled", x=> ((bool)x)==true ? HTML["Approve"]: HTML["Deny"]},
            {"LockoutEnabled", x=> ((bool)x)==true ? HTML["Approve"]: HTML["Deny"]},
            {"PhoneNumberApproved", x=> ((bool)x)==true ? HTML["Approve"]: HTML["Deny"]},
            {"IsPersistent", x=> ((bool)x)==true ? HTML["Approve"]: HTML["Deny"]},
            {"RefreshToken", x=> ((string)x)=="" ? HTML["Deny"] : HTML["Approve"]}
        };

        Actions = new[] { "Remove", "Update" };
    }
}
