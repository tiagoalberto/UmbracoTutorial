﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.SampleSite;

namespace UmbracoTutorial.Controllers;

public class TutorialContactController:SurfaceController
{
    public TutorialContactController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
    }
    
    public IActionResult Submit(ContactFormViewModel model)
    {
        if (!base.ModelState.IsValid)
            return CurrentUmbracoPage();
        ITempDataDictionary tempDataDictionary = base.TempData;
        tempDataDictionary["Message"] = "Submitted successfully";
        
        return RedirectToCurrentUmbracoPage(QueryString.Create("submit", "true"));
    }

    // /umbraco/surface/tutorialcontact/testmethod?id={id}
    public IActionResult TestMethod(string id)
    {
        return Ok(id);
    }
}
