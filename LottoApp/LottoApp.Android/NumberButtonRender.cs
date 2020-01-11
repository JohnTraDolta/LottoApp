using System;
using System.Reflection;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Text;
using Android.Views;
using Java.Nio.Channels;
using LottoApp;
using LottoApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;
using Color = Android.Graphics.Color;
using FrameRenderer = Xamarin.Forms.Platform.Android.FrameRenderer;
using View = Android.Views.View;

[assembly: ExportRendererAttribute(typeof(NumberButton), typeof(NumberButtonRender))]
namespace LottoApp.Droid
{
    public sealed class NumberButtonRender : ViewRenderer<NumberButton, View>
    {
        
        public NumberButtonRender(Context context) : base(context)
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            NumberButton button = (NumberButton) this.Element;

            Paint backgroundPaint = new Paint()
            {
                Color = button.BackgroundColor.ToAndroid(),
                AntiAlias = true
            };
            TextPaint textPaint = new TextPaint()
            {
                Color = button.TextColor.ToAndroid(),
                AntiAlias = true,
                TextSize = (float)button.FontSize,
                TextAlign = Paint.Align.Center
            };

            
            Rect bounds = new Rect();
            textPaint.GetTextBounds(button.Text, 0, button.Text.Length, bounds);

            canvas.DrawCircle((float)canvas.Width/2, (float)canvas.Height/2, (float)button.WidthRequest, backgroundPaint);
            canvas.DrawText(button.Text,
                (float)canvas.Width/2, 
                ((float)canvas.Height + bounds.Height())/2 , textPaint);

        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            var motionEventActions = e.Action;
            NumberButton button = (NumberButton)this.Element;
            switch (motionEventActions)
            {
                case MotionEventActions.Down:
                    var oldBgColor = button.BackgroundColor;
                    var oldTxtColor = button.TextColor;

                    button.BackgroundColor = button.AlternateBackgroundColor;
                    button.AlternateBackgroundColor = oldBgColor;

                    button.TextColor = button.AlternateTextColor;
                    button.AlternateTextColor = oldTxtColor;

                    return false;
                default:
                    return base.OnTouchEvent(e);
            }
            
        }
    }

}