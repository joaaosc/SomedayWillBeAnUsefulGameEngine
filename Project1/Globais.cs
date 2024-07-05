using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project1;

public abstract class Globais
{
    public readonly Point _tamanhoDoMaṕa = new Point(30, 20);
    public static float SegundosTotais { get; set; }
    public static GraphicsDevice Gd { get; set; }
    public static ContentManager Cm;
    public static SpriteBatch Sb { get; set; }

    public static void Update(GameTime gt)
    {
        SegundosTotais = (float)gt.ElapsedGameTime.TotalSeconds;
    }
    
}