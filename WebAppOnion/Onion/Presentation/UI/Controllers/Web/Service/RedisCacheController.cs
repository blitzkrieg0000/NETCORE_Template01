using Application.Attributes;
using Application.Consts.Auth;
using Application.Enums;
using Application.Interfaces.Service.Redis;
using Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;
using UI.Extensions;

namespace UI.Controllers.Web.Service;


public class RedisCacheController : Controller {
    //TODO CQRS yazılacak
    private readonly IRedisCacheService _redisCacheService;

    public RedisCacheController(IRedisCacheService redisCacheService) {
        _redisCacheService = redisCacheService;
    }


    [AuthorizeEndpoint(
        Menu = EndpointDefaults.Menu.Redis,
        ActionType = ActionType.Special,
        Definition = "Redis Ön Belleğini Temizleme Yetkisi",
        Identifier = EndpointDefaults.Identifier.Redis.Delete
    )]
    public async Task<IActionResult> RedisUserPermissionUpdate() {
        await _redisCacheService.RemoveBulkDataAsync("__rolePermissionCache_*");
        await _redisCacheService.RemoveBulkDataAsync("__endpointPermissionCache_*");
        return this.ResponseRedirectToAction(new Response(ResponseType.Success, "Redis Önbelleği Temizlendi."), "Settings", "Admin");
    }

}