using System.Drawing;
using System.Windows.Forms;

namespace GraphColoringApp.Utils
{
    public static class ThemeManager
    {
        public static bool DarkMode { get; private set; } = false;

        public static Color BackgroundColor => DarkMode ? Color.FromArgb(30, 30, 30) : Color.WhiteSmoke;
        public static Color NodeColor => DarkMode ? Color.Gray : Color.LightGray;
        public static Color TextColor => DarkMode ? Color.WhiteSmoke : Color.Black;
        public static Color EdgeColor => DarkMode ? Color.LightGray : Color.Gray;

        public static void ToggleTheme()
        {
            DarkMode = !DarkMode;
            foreach (Form f in Application.OpenForms)
                f.Invalidate();
        }
    }
}
