using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Text;
using Android.Views;
using LottoApp;
using LottoApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
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
            NumberButton button = (NumberButton)this.Element;

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

            canvas.DrawCircle((float)canvas.Width / 2, (float)canvas.Height / 2, (float)button.WidthRequest, backgroundPaint);
            canvas.DrawText(button.Text,
                (float)canvas.Width / 2,
                ((float)canvas.Height + bounds.Height()) / 2, textPaint);

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
                    button.TextColor = button.AlternateTextColor;

                    button.AlternateBackgroundColor = oldBgColor;
                    button.AlternateTextColor = oldTxtColor;

                    var result =
                    oldTxtColor == Xamarin.Forms.Color.Black ?
                        Task.Run(async () => await button.ScaleTo(1, 150, easing: Easing.SpringOut)) :
                        Task.Run(async () => await button.ScaleTo(1.3, 100, easing: Easing.SpringOut));

                    return false;
                default:
                    return base.OnTouchEvent(e);
            }

        }
    }

}