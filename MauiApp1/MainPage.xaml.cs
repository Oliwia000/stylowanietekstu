using Microsoft.Maui.Controls;
using System;
namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void TextSliderSlide(object sender, ValueChangedEventArgs e)
        {
            int textSize = Convert.ToInt32(textSizeSlider.Value);
            textSizeLabel.Text = $"Rozmiar: {textSize}";
        }
            private string GenerateRandomQuote()
            {
                string[] quotes =
                [
                    "Believe you can and you're halfway there.",
                    "Do one thing every day that scares you.",
                    "If not us, who? If not now, when?",
                    "You only live once, but if you do it right, once is enough.",
                   " The purpose of our lives is to be happy."
            ];

                Random random = new Random();
                return quotes[random.Next(quotes.Length)];
            }
            private void ApplyChanges(object sender, EventArgs e)
            {
                LayoutOptions[] layoutOptions =
                [
                    LayoutOptions.End,
                    LayoutOptions.Center,
                    LayoutOptions.Start
                ];
                int textSize = Convert.ToInt32(textSizeSlider.Value);
                LayoutOptions textPosition =
                textPositionPicker.SelectedIndex != -1
                        ? layoutOptions[textPositionPicker.SelectedIndex]
                        : layoutOptions[2];
                bool isTextBald = textBoldSwitch.IsToggled;
                bool isTextItalic = textItalicSwitch.IsToggled;

                desiredText.FontSize = textSize;
                desiredText.HorizontalOptions = textPosition;

                if (isTextBald && isTextItalic)
                    desiredText.FontAttributes = FontAttributes.Italic | FontAttributes.Bold;
                else if (isTextBald)
                    desiredText.FontAttributes = FontAttributes.Bold;
                else if (isTextItalic)
                    desiredText.FontAttributes = FontAttributes.Italic;
                else
                    desiredText.FontAttributes = FontAttributes.None;

                desiredText.Text = GenerateRandomQuote();
            }
        } }

    