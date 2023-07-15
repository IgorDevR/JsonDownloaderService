using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace JsonDownloaderService.Controllers;

public class HomeController : Controller
{
    private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;

    public HomeController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
    {
        _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
    }

    public IActionResult Index()
    {
        var actionDescriptors = _actionDescriptorCollectionProvider.ActionDescriptors.Items;
        var controllerActions = actionDescriptors
            .Where(ad => ad.GetType() == typeof(ControllerActionDescriptor))
            .Cast<ControllerActionDescriptor>()
            .GroupBy(ad => ad.ControllerName);

        return View(controllerActions);
    }
}
