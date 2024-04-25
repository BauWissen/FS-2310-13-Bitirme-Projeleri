using Microsoft.AspNetCore.Builder;
using UlukunShopAPI.SignalR.Hubs;

namespace UlukunShopAPI.SignalR;

public static class HubRegistration
{
    public static void MapHubs(this WebApplication webApplication)
    {
        webApplication.MapHub<ProductHub>("/products-hub");
        webApplication.MapHub<OrderHub>("/orders-hub");
    }
}