/******************************************************************************
 * Copyright(C) 2016 - All Right Reserved 
 * Real World Developers (www.realworlddevelopers.com) 
 * Unauthorized copying of this file, via any medium is strictly prohibited 
 * Written by Jim Stevens <jstevens@realworlddevelopers.com>  
 ******************************************************************************/

using RWD.Toolbox.Conversion;
using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace RWD.Conversions.Pages
{
    public partial class Temp : ContentPage
    {
        private bool OriginalEntry = false;
        private const string TextboxFormat = "###,#0.###";
        private const string RegEx_Decimal = @"^[+-]?((\d+(\.\d+)?)|(\.\d+))$";           

        public Temp()
        {
            InitializeComponent();         
            // this is now in xaml
            // entryCelcius.TextChanged += EntryCelcius_TextChanged; 
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {               
                if (!OriginalEntry)
                {
                    var txBox = sender as Entry;
                    if (txBox.Text.StartsWith("."))
                        txBox.Text = "0.";

                    var rawNum = txBox.Text.Replace(",", "");
                    if (rawNum.EndsWith("."))
                        rawNum += "0";

                    if (string.IsNullOrEmpty(txBox.Text))
                    {
                        entryFahrenheit.Text = string.Empty;
                        entryCelcius.Text = string.Empty;
                    }
                    else
                    {
                        OriginalEntry = true;
                        if (Regex.IsMatch(rawNum, RegEx_Decimal))
                        {
                            if (entryFahrenheit.Id == txBox.Id)
                                entryCelcius.Text = Temperature.ConvertFahrenheitToCelcius(Convert.ToDouble(rawNum)).Value.ToString(TextboxFormat);
                            else
                                entryFahrenheit.Text = Temperature.ConvertCelciusToFahrenheit(Convert.ToDouble(rawNum)).Value.ToString(TextboxFormat);
                        }
                        else
                        {
                            if (txBox.Text == "-")
                            {
                                if (entryFahrenheit.Id == txBox.Id)
                                    entryCelcius.Text = "";
                                else
                                    entryFahrenheit.Text = "";
                            }
                            else
                            {
                                txBox.Text = txBox.Text.Substring(0, txBox.Text.Length - 1);
                            }
                        }
                    }
                }
            }
            catch (Exception )
            {
                // ex.Data.Add("NewValue", e.NewTextValue);
                // ex.Data.Add("OldValue", e.OldTextValue);
                // TODO _exceptionHelper.LogException(ex, LogLevel.Error);
                entryFahrenheit.Text = "";
                entryCelcius.Text = "";
            }
            finally
            {
                OriginalEntry = false;
            }

        }


    }
}
