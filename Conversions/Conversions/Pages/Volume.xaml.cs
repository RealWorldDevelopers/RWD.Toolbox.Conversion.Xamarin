/******************************************************************************
 * Copyright(C) 2016 - All Right Reserved 
 * Real World Developers (www.realworlddevelopers.com) 
 * Unauthorized copying of this file, via any medium is strictly prohibited 
 * Written by Jim Stevens <jstevens@realworlddevelopers.com>  
 ******************************************************************************/

using RWD.Conversions.Controls;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace RWD.Conversions.Pages
{
    public partial class Volume : ContentPage
    {
        private double VolUnits;
        private bool OriginalEntry = false;
        private const string TextboxFormat = "###,###.###";
        private const string RegEx_Decimal = @"^[+-]?((\d+(\.\d+)?)|(\.\d+))$";
        private string EntryFormat = "###,###,##0";

        public Volume()
        {
            InitializeComponent();
        }

        private void English_Vol_TextChanged(object sender, EventArgs e)
        {
            var txBox = sender as NumericEntry;
            try
            {
                if (!OriginalEntry)
                {
                    if (txBox.Text.StartsWith("."))
                    {
                        txBox.Text = "0.";
                    }
                    var rawNum = txBox.Text.Replace(",", "");
                    if (rawNum.EndsWith("."))
                        rawNum += "0";

                    OriginalEntry = true;
                    if (string.IsNullOrEmpty(txBox.Text))
                    {
                        VolUnits = 0;
                        FillEnglishToMetric_Vol(null);
                        OriginalEntry = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(rawNum, RegEx_Decimal))
                        {
                            VolUnits = Math.Abs(Convert.ToDouble(rawNum)) / Convert.ToDouble(txBox.Tag);

                            FillEnglishToMetric_Vol(txBox.Id);
                            if (Regex.IsMatch(txBox.Text, RegEx_Decimal))
                                FormatEntryTextbox(txBox);

                        }
                        else
                        {
                            txBox.Text = txBox.Text.Substring(0, txBox.Text.Length - 1);
                        }

                        OriginalEntry = false;
                    }
                }
            }
            catch (Exception)
            {
                // ex.Data.Add("txBox.Name", txBox.Name);
                // ex.Data.Add("txBox.Text", txBox.Text);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                OriginalEntry = false;
                FillEnglishToMetric_Vol(null);
            }

        }

        private void Metric_Vol_TextChanged(object sender, EventArgs e)
        {
            var txBox = sender as NumericEntry;
            try
            {
                if (!OriginalEntry)
                {
                    if (txBox.Text.StartsWith("."))
                    {
                        txBox.Text = "0.";
                    }
                    var rawNum = txBox.Text.Replace(",", "");
                    if (rawNum.EndsWith("."))
                        rawNum += "0";

                    OriginalEntry = true;
                    if (string.IsNullOrEmpty(txBox.Text))
                    {
                        VolUnits = 0;
                        FillMetricToEnglish_Vol(null);
                        OriginalEntry = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(rawNum, RegEx_Decimal))
                        {
                            VolUnits = Math.Abs(Convert.ToDouble(rawNum)) * Convert.ToDouble(txBox.Tag);

                            FillMetricToEnglish_Vol(txBox.Id);

                            if (Regex.IsMatch(txBox.Text, RegEx_Decimal))
                                FormatEntryTextbox(txBox);

                        }
                        else
                        {
                            txBox.Text = txBox.Text.Substring(0, txBox.Text.Length - 1);
                        }

                        OriginalEntry = false;
                    }

                }
            }
            catch (Exception)
            {
                // ex.Data.Add("txBox.Name", txBox.Name);
                // ex.Data.Add("txBox.Text", txBox.Text);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                OriginalEntry = false;
                FillMetricToEnglish_Vol(null);
            }
        }

        /// <summary>
        /// Recalculate Metric Volume Values
        /// </summary>
        /// <remarks>If originating textbox is Metric Measurment then VolUnits is in Liters.</remarks>
        private void FillMetricToEnglish_Vol(Guid? id)
        {
            try
            {
                // VolUnits = liters

                Guid? senderId = Guid.Empty;
                if (id.HasValue)
                    senderId = id;

                if (!(senderId == entryMilliLiters.Id))
                    entryMilliLiters.Text = RWD.Toolbox.Conversion.Volume.LitersToMilliLiters(VolUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryLiters.Id))
                    entryLiters.Text = (VolUnits).ToString(TextboxFormat);

                if (!(senderId == entryFluidOunce.Id))
                    entryFluidOunce.Text = RWD.Toolbox.Conversion.Volume.LitersToOunces(VolUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryGallons.Id))
                    entryGallons.Text = RWD.Toolbox.Conversion.Volume.LitersToGallons(VolUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryPints.Id))
                    entryPints.Text = RWD.Toolbox.Conversion.Volume.QuartsToPints(RWD.Toolbox.Conversion.Volume.LitersToQuarts(VolUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryCups.Id))
                    entryCups.Text = RWD.Toolbox.Conversion.Volume.QuartsToCups(RWD.Toolbox.Conversion.Volume.LitersToQuarts(VolUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryQuarts.Id))
                    entryQuarts.Text = RWD.Toolbox.Conversion.Volume.LitersToQuarts(VolUnits).Value.ToString(TextboxFormat);

                if (!(senderId == entryTableSpoons.Id))
                    entryTableSpoons.Text = RWD.Toolbox.Conversion.Volume.MilliLitersToTablespoons(RWD.Toolbox.Conversion.Volume.LitersToMilliLiters(VolUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryTeaSpoons.Id))
                    entryTeaSpoons.Text = RWD.Toolbox.Conversion.Volume.MilliLitersToTeaspoons(RWD.Toolbox.Conversion.Volume.LitersToMilliLiters(VolUnits)).Value.ToString(TextboxFormat);

            }
            catch (Exception)
            {
                // ex.Data.Add("SenderName", SenderName);
                // ex.Data.Add("VolUnits", VolUnits);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                VolUnits = 0;
                FillEnglishToMetric_Vol(null);
            }

        }

        /// <summary>
        /// Recalculate US Volume Values
        /// </summary>
        /// <remarks>If originating textbox is US Measurment then VolUnits is in Gallons.</remarks>
        private void FillEnglishToMetric_Vol(Guid? id)
        {
            try
            {
                // VolUnits = gallons

                Guid? senderId = Guid.Empty;
                if (id.HasValue)
                    senderId = id;

                if (!(senderId == entryMilliLiters.Id))
                    entryMilliLiters.Text = RWD.Toolbox.Conversion.Volume.LitersToMilliLiters(RWD.Toolbox.Conversion.Volume.GallonsToLiters(VolUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryLiters.Id))
                    entryLiters.Text = RWD.Toolbox.Conversion.Volume.GallonsToLiters(VolUnits).Value.ToString(TextboxFormat);

                if (!(senderId == entryFluidOunce.Id))
                    entryFluidOunce.Text = RWD.Toolbox.Conversion.Volume.GallonsToOunces(VolUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryGallons.Id))
                    entryGallons.Text = (VolUnits).ToString(TextboxFormat);
                if (!(senderId == entryPints.Id))
                    entryPints.Text = RWD.Toolbox.Conversion.Volume.GallonsToPints(VolUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryCups.Id))
                    entryCups.Text = RWD.Toolbox.Conversion.Volume.GallonsToCups(VolUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryQuarts.Id))
                    entryQuarts.Text = RWD.Toolbox.Conversion.Volume.GallonsToQuarts(VolUnits).Value.ToString(TextboxFormat);

                if (!(senderId == entryTableSpoons.Id))
                    entryTableSpoons.Text = RWD.Toolbox.Conversion.Volume.OuncesToTablespoons(RWD.Toolbox.Conversion.Volume.GallonsToOunces(VolUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryTeaSpoons.Id))
                    entryTeaSpoons.Text = RWD.Toolbox.Conversion.Volume.OuncesToTeaspoons(RWD.Toolbox.Conversion.Volume.GallonsToOunces(VolUnits)).Value.ToString(TextboxFormat);

            }
            catch (Exception)
            {
                // ex.Data.Add("SenderName", SenderName);
                // ex.Data.Add("VolUnits", VolUnits);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                VolUnits = 0;
                FillMetricToEnglish_Vol(null);
            }
        }


        private void FormatEntryTextbox(Entry txBox)
        {
            var rawNum = txBox.Text.Replace(",", "");
            var placeHolder = rawNum.EndsWith("0") ? '0' : '#';
            var format = EntryFormat;

            double dValue;
            if (double.TryParse(rawNum, out dValue))
            {
                var idx = rawNum.IndexOf('.');
                if (idx >= 0)
                {
                    var p = rawNum.Length - idx - 1;
                    format += "." + new string(placeHolder, p);
                }

                txBox.Text = dValue.ToString(format);
            }
        }

    }
}
