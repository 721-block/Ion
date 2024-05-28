using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Extensions
{
    public static class AddUserDataInViewBagExtension
    {
        public static void AddUserDataInViewBag(this Controller controller)
        {
            var viewBag = controller.ViewBag;
            viewBag.PathToPhoto = "static/UserLogo.png";
            viewBag.Id = 1;
        } 

    }
}
