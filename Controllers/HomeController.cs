using System.Diagnostics;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using sample_app.Models;
using sample_app.Services;

namespace sample_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private LanguageService _localization;

    public HomeController(ILogger<HomeController> logger, LanguageService localization)
    {
        _logger = logger;
        _localization = localization;
    }

    public IActionResult Index()
    {
        ViewBag.IndexPageContent = _localization.Getkey("index_page_content");
        return View();
    }

    public IActionResult Privacy()
    {
        ViewBag.PrivacyPageContent = _localization.Getkey("privacy_page_content");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    #region Localization
    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
        {
            Expires = DateTimeOffset.UtcNow.AddYears(1)
        });
        return Redirect(Request.Headers["Referer"].ToString());
    }
    #endregion
}
