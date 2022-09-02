using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Common
{
    public class Draw
    {
        private static float xr = 1;
        private static float yr = 1;
        private static float xo = 0;
        private static float yo = 0;

        public static void SetRatio(float x, float y)
        {
            xr = x;
            yr = y;
        }

        public static void SetOffset(float x, float y)
        {
            xo = x;
            yo = y;
        }

        public static Font GetFont(string fontName, float fontSize, bool fontBold, bool fontItalic, bool fontUnderline)
        {
            FontStyle fontStyle = FontStyle.Regular;
            if (fontBold) fontStyle |= FontStyle.Bold;
            if (fontItalic) fontStyle |= FontStyle.Italic;
            if (fontUnderline) fontStyle |= FontStyle.Underline;

            return new Font(fontName, fontSize, fontStyle);
        }

        public static void DrawText(System.Drawing.Graphics g, float x0, float y0, float x1, float y1, string text, string fontName, float fontSize, bool fontBold, bool fontItalic, bool fontUnderline, Color color, StringAlignment alignment)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = alignment;

            g.DrawString(text, GetFont(fontName, fontSize, fontBold, fontItalic, fontUnderline), new SolidBrush(color), new RectangleF((xo + x0) * xr, (yo + y0) * yr, (x1 - x0) * xr, (y1 - y0) * yr), stringFormat);
        }

        public static void DrawImage(System.Drawing.Graphics g, float x0, float y0, float x1, float y1, Image image)
        {
            if (image != null)
            {
                g.DrawImage(image, (xo + x0) * xr, (yo + y0) * yr, (x1 - x0) * xr, (y1 - y0) * yr);
            }
        }

        public static void DrawBox(System.Drawing.Graphics g, float x0, float y0, float x1, float y1, Color color)
        {
            g.DrawRectangle(new Pen(color), (xo + x0) * xr, (yo + y0) * yr, (x1 - x0) * xr, (y1 - y0) * yr);
        }

        public static void DrawBoxF(System.Drawing.Graphics g, float x0, float y0, float x1, float y1, Color color)
        {
            g.FillRectangle(new SolidBrush(color), (xo + x0) * xr, (yo + y0) * yr, (x1 - x0) * xr, (y1 - y0) * yr);
        }

        public static void DrawBoxR(System.Drawing.Graphics g, float x0, float y0, float x1, float y1, Color color, float r)
        {
            Pen pen = new Pen(color);

            g.DrawArc(pen, (xo + x0) * xr, (yo + y0) * yr, (r * 2) * xr, (r * 2) * yr, 180, 90);
            g.DrawArc(pen, (xo + x1 - r * 2) * xr, (yo + y0) * yr, (r * 2) * xr, (r * 2) * yr, 270, 90);
            g.DrawArc(pen, (xo + x1 - r * 2) * xr, (yo + y1 - r * 2) * yr, (r * 2) * xr, (r * 2) * yr, 0, 90);
            g.DrawArc(pen, (xo + x0) * xr, (yo + y1 - r * 2) * yr, (r * 2) * xr, (r * 2) * yr, 90, 90);

            g.DrawLine(pen, (xo + x0 + r) * xr, (yo + y0) * yr, (xo + x1 - r) * xr, (yo + y0) * yr);
            g.DrawLine(pen, (xo + x0) * xr, (yo + y0 + r) * yr, (xo + x0) * xr, (yo + y1 - r) * yr);
            g.DrawLine(pen, (xo + x1) * xr, (yo + y0 + r) * yr, (xo + x1) * xr, (yo + y1 - r) * yr);
            g.DrawLine(pen, (xo + x0 + r) * xr, (yo + y1) * yr, (xo + x1 - r) * xr, (yo + y1) * yr);
        }

        public static void DrawLine(System.Drawing.Graphics g, float x0, float y0, float x1, float y1, Color color)
        {
            g.DrawLine(new Pen(color), (xo + x0) * xr, (yo + y0) * yr, (xo + x1) * xr, (yo + y1) * yr);
        }

        public static Image GetImage(byte[] data)
        {
            if (data == null)
                return null;
            else
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(data);
                return Image.FromStream(stream);
            }
        }

    }
}
