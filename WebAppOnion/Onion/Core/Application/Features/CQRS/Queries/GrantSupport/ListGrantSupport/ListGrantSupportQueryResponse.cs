using Application.Models.GrantSupportViewModel;
using Common.ResponseObjects;
using X.PagedList;

namespace Application.Features.CQRS.Queries.GrantSupport.ListGrantSupport;


public class ListGrantSupportQueryResponse : Response<IPagedList<GrantSupportViewModel>> {
    public ListGrantSupportQueryResponse(ResponseType responseType) : base(responseType) {
    }

    public ListGrantSupportQueryResponse(ResponseType responseType, string message) : base(responseType, message) {
    }

    public ListGrantSupportQueryResponse(ResponseType responseType, IPagedList<GrantSupportViewModel> data) : base(responseType, data) {
    }

    public ListGrantSupportQueryResponse(ResponseType responseType, IPagedList<GrantSupportViewModel> data, string message) : base(responseType, data, message) {
    }

    public ListGrantSupportQueryResponse(ResponseType responseType, IPagedList<GrantSupportViewModel> data, IDictionary<string, dynamic> metaData) : base(responseType, data, metaData) {
    }

    public ListGrantSupportQueryResponse(ResponseType responseType, IPagedList<GrantSupportViewModel> data, List<CustomValidationError> errors) : base(responseType, data, errors) {
    }

    public ListGrantSupportQueryResponse(ResponseType responseType, IPagedList<GrantSupportViewModel> data, IDictionary<string, dynamic> metaData, List<CustomValidationError> errors) : base(responseType, data, metaData, errors) {
    }
}

