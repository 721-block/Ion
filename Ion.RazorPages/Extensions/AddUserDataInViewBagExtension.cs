using Microsoft.AspNetCore.Mvc;

namespace Ion.RazorPages.Extensions
{
    public static class AddUserDataInViewBagExtension
    {
        public static void AddUserDataInViewBag(this Controller controller)
        {
            var viewBag = controller.ViewBag;
            viewBag.PathToPhoto = "/images/1/itadori.png";
            viewBag.Id = 1;
        } 

    }
}
