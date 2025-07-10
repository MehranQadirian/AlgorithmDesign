using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace Sum_of_Subsets
{
    public class RoundedPictureBox : PictureBox
    {
        public int CornerRadius { get; set; } = 30; // مقدار پیش‌فرض شعاع

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.Image == null) return;

            // ایجاد مسیر گرافیکی با گوشه‌های گرد
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90); // بالا-چپ
            path.AddArc(Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90); // بالا-راست
            path.AddArc(Width - CornerRadius, Height - CornerRadius, CornerRadius, CornerRadius, 0, 90); // پایین-راست
            path.AddArc(0, Height - CornerRadius, CornerRadius, CornerRadius, 90, 90); // پایین-چپ
            path.CloseFigure();

            // اعمال منطقه گرد به کنترل
            Region = new Region(path);

            // رسم تصویر با کیفیت بالا
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(Image, new Rectangle(0, 0, Width, Height));
        }
    }
}