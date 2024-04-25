using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalesUp.Business.Abstract;
using SalesUp.Entity.Identity;

namespace SalesUp.MVC.Areas.Customer.ViewComponents
{
    public class CustomerMessageNotificationViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IMessageService _messageManager;

        public CustomerMessageNotificationViewComponent(UserManager<User> userManager, IMessageService messageManager)
        {
            _userManager = userManager;
            _messageManager = messageManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var unreadMessageCount = await _messageManager.GetMessageCountAsync(userId);
            return View(unreadMessageCount.Data);
        }
    }
}