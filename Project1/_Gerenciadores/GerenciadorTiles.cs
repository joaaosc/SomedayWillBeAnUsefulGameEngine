using System;
using Microsoft.Xna.Framework.Graphics;
using Project1._Modelos;

namespace Project1._Gerenciadores;

public class GerenciadorTiles
{

    public void TornarImpassavel(int x, int y, Texture2D textura)
    {
        if (x >= 0 && x < _tamanhoDoMaṕa.X && y >= 0 && y < _tamanhoDoMaṕa.Y)
        {
            _tiles[x, y] = new Tile(textura, MapaParaTela(x, y), true); // Cria um novo Tile com a nova textura e marca como impassável
        }
        else
        {
            throw new ArgumentOutOfRangeException("As coordenadas fornecidas estão fora dos limites do mapa.");
        }
    }
}