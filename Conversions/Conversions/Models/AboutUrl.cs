// Copyright(C) 2016  
// Real World Developers (www.realworlddevelopers.com) 
// All Right Reserved

using System.Collections.Generic;


namespace RWD.Conversions.Models
{
    public class AboutUrl
    { 
        public string Display { get; set; }

        public string Uri { get; set; }

        public override string ToString()
        {
            return Display;
        }

        public static List<AboutUrl> GetUrlList()
        {
            var displayList = new List<AboutUrl>();
            displayList.Add(new AboutUrl
            {
                Uri = "http://realworlddevelopers.com/legal/privacymobile.html",
                Display = "Privacy Policy"

            });
            displayList.Add(new AboutUrl
            {
                Uri = "http://realworlddevelopers.com/legal/eula.html",
                Display = "License Agreement"

            });
            displayList.Add(new AboutUrl
            {
                Uri = "http://realworlddevelopers.com/legal/credits.html",
                Display = "Acknowledgements"

            });


            return displayList;
        }
    }
}
