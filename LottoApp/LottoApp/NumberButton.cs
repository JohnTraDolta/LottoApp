using System;
using Xamarin.Forms;

namespace LottoApp
{
    public class NumberButton : View
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadiusProperty),typeof(double),typeof(NumberButton), (double)0, BindingMode.Default);
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(TextProperty), typeof(String), typeof(NumberButton), "", BindingMode.Default);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColorProperty), typeof(Color), typeof(NumberButton), Color.Black, BindingMode.Default);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSizeProperty),typeof(double),typeof(NumberButton), (double)0, BindingMode.Default);
        public static readonly BindableProperty AlternateBackgroundColorProperty = BindableProperty.Create(nameof(AlternateBackgroundColorProperty), typeof(Color), typeof(NumberButton), Color.White, BindingMode.Default);
        public static readonly BindableProperty AlternateTextColorProperty = BindableProperty.Create(nameof(AlternateTextColorProperty), typeof(Color), typeof(NumberButton), Color.Black, BindingMode.Default);


        public double CornerRadius
        {
            get => (double) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public Color AlternateBackgroundColor
        {
            get => (Color)GetValue(AlternateBackgroundColorProperty);
            set => SetValue(AlternateBackgroundColorProperty, value);
        }
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        public Color AlternateTextColor
        {
            get => (Color)GetValue(AlternateTextColorProperty);
            set => SetValue(AlternateTextColorProperty, value);
        }
    }
}