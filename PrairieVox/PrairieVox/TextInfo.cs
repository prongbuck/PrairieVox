using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrairieVox
{
    class TextInfo
    {
        public SpriteFont font { get; protected set; }
        public string text; //want to be able to easily update the text
        public Vector2 position { get; protected set; }
        public Color color { get; protected set; }
        
        public TextInfo(SpriteFont font, string text, Vector2 position, Color color)
        {
            this.font = font;
            this.text = text;
            this.position = position;
            this.color = color;
        }
    }
}
