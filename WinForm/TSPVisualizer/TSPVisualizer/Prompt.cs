using System.Windows.Forms;

namespace TSPVisualizer
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label lbl = new Label() { Left = 10, Top = 20, Text = text, AutoSize = true };
            TextBox input = new TextBox() { Left = 10, Top = 50, Width = 260 };
            Button ok = new Button() { Text = "تأیید", Left = 200, Width = 70, Top = 80, DialogResult = DialogResult.OK };
            prompt.Controls.Add(lbl);
            prompt.Controls.Add(input);
            prompt.Controls.Add(ok);
            prompt.AcceptButton = ok;

            return prompt.ShowDialog() == DialogResult.OK ? input.Text : "";
        }
    }
}
