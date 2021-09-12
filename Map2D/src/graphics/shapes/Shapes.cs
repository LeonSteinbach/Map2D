using System.Collections.Generic;
using System.Linq;
using Map2D.math.geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.shapes
{
    public class Shapes
    {
        private static Texture2D pixel;
        
        private static void CreatePixel(GraphicsResource spriteBatch)
        {
            pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
        }
        
        public static void DrawPixel(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            if (pixel == null)
                CreatePixel(spriteBatch);

            spriteBatch.Draw(pixel, position, color);
        }

        public static void DrawLine(SpriteBatch spriteBatch, Line line, 
            Color color, float thickness, float layer = 1.0f)
        {
            if (pixel == null)
                CreatePixel(spriteBatch);

            spriteBatch.Draw(pixel, line.a.ToVector2(), null, color, line.Angle(), 
                Vector2.Zero, new Vector2(line.Length(), thickness), SpriteEffects.None, layer);
        }

        private static void DrawLines(SpriteBatch spriteBatch, GeometricObject geometricObject,
            Color color, float thickness, float layer = 1.0f)
        {
            foreach (Line line in geometricObject.sides)
                DrawLine(spriteBatch, line, color, thickness, layer);
        }

        public static void DrawRectangle(SpriteBatch spriteBatch, math.geometry.Rectangle rectangle,
            Color color, float thickness, float layer = 1.0f)
        {
            DrawLines(spriteBatch, rectangle, color, thickness, layer);
        }

        public static void DrawFilledRectangle(SpriteBatch spriteBatch, math.geometry.Rectangle rectangle, 
            Color color, float angle, float layer = 1.0f)
        {
            if (pixel == null)
                CreatePixel(spriteBatch);

            spriteBatch.Draw(pixel, new Microsoft.Xna.Framework.Rectangle(
                    rectangle.left, rectangle.top, rectangle.width, rectangle.height), 
                null, color, angle, Vector2.Zero, SpriteEffects.None, layer);
        }

        public static void DrawTriangle(SpriteBatch spriteBatch, Triangle triangle,
            Color color, float thickness, float layer = 1.0f)
        {
            DrawLines(spriteBatch, triangle, color, thickness, layer);
        }

        public static void DrawFilledTriangle(SpriteBatch spriteBatch, Effect effect, Triangle triangle, Color color)
        {
            List<Point> points = new List<Point>() { triangle.a, triangle.b, triangle.c };
            Polygon polygon = new Polygon(points);
            
            DrawFilledPolygon(spriteBatch, effect, polygon, color);
        }
        
        public static void DrawCircle(SpriteBatch spriteBatch, Circle circle, 
            Color color, float thickness, float layer = 1.0f)
        {
            DrawLines(spriteBatch, circle, color, thickness, layer);
        }
        
        private static void DrawFilledCircle(SpriteBatch spriteBatch, Effect effect, Circle circle, Color color)
        {
            Polygon polygon = new Polygon(circle.points.ToList());
            
            DrawFilledPolygon(spriteBatch, effect, polygon, color);
        }
        
        public static void DrawPolygon(SpriteBatch spriteBatch, Polygon polygon, 
            Color color, float thickness, float layer = 1.0f)
        {
            DrawLines(spriteBatch, polygon, color, thickness, layer);
        }
        
        private static void DrawFilledPolygon(SpriteBatch spriteBatch, Effect effect, Polygon polygon, Color color)
        {
            VertexPositionColor[] vertices = new VertexPositionColor[polygon.points.Count];
            for (int i = 0; i < polygon.points.Count; i++)
            {
                vertices[i] =
                    new VertexPositionColor(new Vector3(polygon.points[i].X, polygon.points[i].Y, 0), color);
            }

            EffectTechnique technique = effect.Techniques[0];
            EffectPassCollection passes = technique.Passes;

            foreach (EffectPass pass in passes)
            {
                pass.Apply();
                spriteBatch.GraphicsDevice.DrawUserPrimitives(
                    PrimitiveType.TriangleList, vertices, 0, 1);
                
                // TODO: Fix polygon drawing
            }
        }
    }
}