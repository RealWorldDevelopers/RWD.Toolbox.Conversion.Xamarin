/******************************************************************************
 * Copyright(C) 2016 - All Right Reserved 
 * Real World Developers (www.realworlddevelopers.com) 
 * Unauthorized copying of this file, via any medium is strictly prohibited 
 * Written by Jim Stevens <jstevens@realworlddevelopers.com>  
 ******************************************************************************/

using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RWD.Conversions.Controls.NumericEntry), typeof(RWD.Conversions.Droid.Renderers.NumericEntryRenderer))]
namespace RWD.Conversions.Droid.Renderers
{
    public class NumericEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var native = Control as EditText;
            
            native.InputType = Android.Text.InputTypes.ClassNumber | Android.Text.InputTypes.NumberFlagSigned | Android.Text.InputTypes.NumberFlagDecimal;
        }

    }
}