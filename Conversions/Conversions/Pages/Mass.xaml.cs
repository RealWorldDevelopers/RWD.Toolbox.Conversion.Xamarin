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
    public partial class Mass : ContentPage
    {
        private double MassUnits;
        private bool OriginalEntry = false;
        private const string TextboxFormat = "###,###.###";
        private const string RegEx_Decimal = @"^[+-]?((\d+(\.\d+)?)|(\.\d+))$";
        private string EntryFormat = "###,###,##0";

        public Mass()
        {
            InitializeComponent();

        }

        private void English_Mass_TextChanged(object sender, TextChangedEventArgs e)
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
                        MassUnits = 0;
                        FillEnglishToMetric_Mass(null);
                        OriginalEntry = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(rawNum, RegEx_Decimal))
                        {
                            if (txBox.Id == entryOunces.Id)
                                MassUnits = Math.Abs(Convert.ToDouble(rawNum)) / Convert.ToDouble(txBox.Tag);
                            else
                                MassUnits = Math.Abs(Convert.ToDouble(rawNum)) * Convert.ToDouble(txBox.Tag);

                            FillEnglishToMetric_Mass(txBox.Id);

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
                FillEnglishToMetric_Mass(null);
            }

        }

        private void Metric_Mass_TextChanged(object sender, TextChangedEventArgs e)
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
                        MassUnits = 0;
                        FillMetricToEnglish_Mass(null);
                        OriginalEntry = false;
                    }
                    else
                    {
                        if (Regex.IsMatch(rawNum, RegEx_Decimal))
                        {
                            if (txBox.Id == entryMetricTons.Id)
                                MassUnits = Math.Abs(Convert.ToDouble(rawNum)) * Convert.ToDouble(txBox.Tag);
                            else
                                MassUnits = Math.Abs(Convert.ToDouble(rawNum)) / Convert.ToDouble(txBox.Tag);

                            FillMetricToEnglish_Mass(txBox.Id);

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
                FillMetricToEnglish_Mass(null);
            }

        }

        /// <summary>
        /// Recalculate Metric Mass Values
        /// </summary>
        /// <remarks>If originating textbox is Metric Measurment then VolUnits is in KiloGrams.</remarks>
        private void FillMetricToEnglish_Mass(Guid? id)
        {
            try
            {
                // MassUnits = KiloGrams

                Guid? senderId = Guid.Empty;
                if (id.HasValue)
                    senderId = id;

                if (!(senderId == entryGrams.Id))
                    entryGrams.Text = RWD.Toolbox.Conversion.Mass.KiloGramsToGrams(MassUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryMilliGrams.Id))
                    entryMilliGrams.Text = RWD.Toolbox.Conversion.Mass.KiloGramsToMilliGrams(MassUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryKiloGrams.Id))
                    entryKiloGrams.Text = (MassUnits).ToString(TextboxFormat);
                if (!(senderId == entryMetricTons.Id))
                    entryMetricTons.Text = RWD.Toolbox.Conversion.Mass.KilogramsToMetricTons(MassUnits).Value.ToString(TextboxFormat);

                if (!(senderId == entryOunces.Id))
                    entryOunces.Text = RWD.Toolbox.Conversion.Mass.GramsToOunces(RWD.Toolbox.Conversion.Mass.KiloGramsToGrams(MassUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryPounds.Id))
                    entryPounds.Text = RWD.Toolbox.Conversion.Mass.KiloGramsToPounds(MassUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryTons.Id))
                    entryTons.Text = RWD.Toolbox.Conversion.Mass.PoundsToTons(RWD.Toolbox.Conversion.Mass.KiloGramsToPounds(MassUnits).Value).Value.ToString(TextboxFormat);

            }
            catch (Exception)
            {
                // ex.Data.Add("SenderName", SenderName);
                // ex.Data.Add("MassUnits", MassUnits);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                MassUnits = 0;
                FillEnglishToMetric_Mass(null);
            }
        }

        /// <summary>
        /// Recalculate US Mass Values
        /// </summary>
        /// <remarks>If originating textbox is US Measurment then VolUnits is in Pounds.</remarks>
        private void FillEnglishToMetric_Mass(Guid? id)
        {
            try
            {
                // MassUnits = pounds

                Guid? senderId = Guid.Empty;
                if (id.HasValue)
                    senderId = id;

                if (!(senderId == entryGrams.Id))
                    entryGrams.Text = RWD.Toolbox.Conversion.Mass.KiloGramsToGrams(RWD.Toolbox.Conversion.Mass.PoundsToKiloGrams(MassUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryMilliGrams.Id))
                    entryMilliGrams.Text = RWD.Toolbox.Conversion.Mass.KiloGramsToMilliGrams(RWD.Toolbox.Conversion.Mass.PoundsToKiloGrams(MassUnits)).Value.ToString(TextboxFormat);
                if (!(senderId == entryKiloGrams.Id))
                    entryKiloGrams.Text = RWD.Toolbox.Conversion.Mass.PoundsToKiloGrams(MassUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryMetricTons.Id))
                    entryMetricTons.Text = RWD.Toolbox.Conversion.Mass.KilogramsToMetricTons(RWD.Toolbox.Conversion.Mass.PoundsToKiloGrams(MassUnits)).Value.ToString(TextboxFormat);

                if (!(senderId == entryOunces.Id))
                    entryOunces.Text = RWD.Toolbox.Conversion.Mass.PoundsToOunces(MassUnits).Value.ToString(TextboxFormat);
                if (!(senderId == entryPounds.Id))
                    entryPounds.Text = (MassUnits).ToString(TextboxFormat);
                if (!(senderId == entryTons.Id))
                    entryTons.Text = RWD.Toolbox.Conversion.Mass.PoundsToTons(MassUnits).Value.ToString(TextboxFormat);

            }
            catch (Exception)
            {
                // ex.Data.Add("SenderName", SenderName);
                // ex.Data.Add("MassUnits", MassUnits);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                MassUnits = 0;
                FillMetricToEnglish_Mass(null);
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
