using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace PrairieVox
{
    // requires the TextInfo class
    public class TextManager
    {
        SpriteFont defaultSpriteFont;
        List<TextInfo> lines = new List<TextInfo>();
        Vector2 borderSpacing;
        
        public TextManager(SpriteFont defaultSpriteFont)
        {
            this.defaultSpriteFont = defaultSpriteFont;

            borderSpacing.X = (int)defaultSpriteFont.MeasureString(" ").X;
            borderSpacing.Y = borderSpacing.X;
        }
         
        public void Draw(SpriteBatch spriteBatch)
        { 
            spriteBatch.Begin();

            foreach (TextInfo tnp in lines)
            {
                spriteBatch.DrawString(defaultSpriteFont, tnp.text, tnp.position, tnp.color);
            }

            spriteBatch.End();

        }

        public void ClearAll()
        {
            lines.Clear();
        }

        public void ClearLastLine()
        {
            if (lines.Count > 0)
                lines.RemoveAt(lines.Count - 1);
        }

        public void AppendToCurrentLine(string text)
        {
            if (lines.Count == 0)
                lines.Add(new TextInfo(defaultSpriteFont, text, borderSpacing, Color.White));
            else
                lines[lines.Count - 1].text += text;
        }

        public void ReplaceLastLine(string text)
        {
            if (lines.Count == 0)
                lines.Add(new TextInfo(defaultSpriteFont, text, borderSpacing, Color.White));
            else
                lines[lines.Count - 1].text = text;
        }

        /// <summary>
        /// This function will add a line of text using the same settings as the last line but below it.
        /// </summary>
        /// <param name="text"></param>
        internal void AddLine(string text)
        {
            if (lines.Count < 1)
            {
                lines.Add(new TextInfo(defaultSpriteFont, text, borderSpacing, Color.White));
            }
            else
            {
                TextInfo temp = lines[lines.Count - 1];
                Vector2 pos;
                pos.X = temp.position.X;
                pos.Y = temp.position.Y + temp.font.MeasureString(temp.text).Y;
                lines.Add(new TextInfo(temp.font, text, pos, Color.White));              
            }
        }

        internal void AddLine(string text, Color theColor)
        {
            if (lines.Count < 1)
            {
                lines.Add(new TextInfo(defaultSpriteFont, text, borderSpacing, theColor));
            }
            else
            {
                TextInfo temp = lines[lines.Count - 1];
                Vector2 pos;
                pos.X = temp.position.X;
                pos.Y = temp.position.Y + temp.font.MeasureString(temp.text).Y;
                lines.Add(new TextInfo(temp.font, text, pos, theColor));
            }
        }

        internal void AddText(TextInfo textInfo)
        {
            lines.Add(textInfo);
        }
    }
}
