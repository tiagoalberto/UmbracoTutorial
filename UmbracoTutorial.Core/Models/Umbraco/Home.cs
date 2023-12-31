﻿namespace UmbracoTutorial.Core.UmbracoModels;

public partial class Home
{
    public string ShortHeroDescription
    {
        get
        {
            if (string.IsNullOrEmpty(this.HeroDescription))
            {
                return "";
            }
            else
            {
                return $"{this.HeroDescription.Substring(0, 30)} ...";
            }
        }
    }
}