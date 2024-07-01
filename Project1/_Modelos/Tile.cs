using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1._Modelos;

public class Tile
{
    private readonly Texture2D _textura;
    private readonly Vector2 _posicao;
    private bool _tileSelecionado;
    
    public Tile(Texture2D textura, Vector2 posicao)
    {
        this._textura = textura;
        this._posicao = posicao;
    }

    public void SelecionarTile()
    {
        _tileSelecionado = true;
    }

    public void DesselecionarTile()
    {
        _tileSelecionado = false;
    }
    
    public void Draw()
    {
        var cor = Microsoft.Xna.Framework.Color.White;
        if (_tileSelecionado) cor = Color.Red;
        
        Globais.Sb.Draw(_textura,_posicao,cor);
    }
}