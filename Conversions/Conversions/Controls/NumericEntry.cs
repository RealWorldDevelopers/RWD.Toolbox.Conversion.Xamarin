// Copyright(C) 2016  
// Real World Developers (www.realworlddevelopers.com) 
// All Right Reserved

using Xamarin.Forms;

namespace RWD.Conversions.Controls
{
    public class NumericEntry : Entry
    {
        public NumericEntry()
        {
            // moved to xaml
            //  this.Keyboard = Keyboard.Numeric;
            //  this.HorizontalTextAlignment = TextAlignment.End;
        }

        public object Tag { get; set; }
    }
}

