using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.assets
{
    public static class FontHelper
    {
        public static SpriteFont SpacingFont(SpriteFont font, float spacing, int lineSpacing)
        {
            font.Spacing = spacing;
            font.LineSpacing = lineSpacing;
            return font;
        }
        
        public static Vector2 TextSize(SpriteFont font, string text)
        {
            return font.MeasureString(text);
        }
    }
}