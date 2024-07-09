using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1._Modelos;

namespace Project1;

public class GeradorDeTerreno
{
    private static Mapa _mapa = Mapa.GerarMapa();
    private static Texture2D _texturaRio = Globais.Cm.Load<Texture2D>("shallow45");

    public GeradorDeTerreno()
    {
        //_mapa = mapa;
        //_tile = tile;
    }

    public void GerarRio(Mapa mapa)
    {
        Random random = new Random();
        // Escolha um ponto inicial e final aleatório para o rio
        int startX = random.Next(0, _mapa.LarguraMapa);
        int startY = random.Next(0, _mapa.AlturaMapa);
        int endX = random.Next(10, _mapa.LarguraMapa);
        int endY = random.Next(10, _mapa.AlturaMapa);

        // Use um algoritmo de caminhada aleatória para traçar um caminho do ponto inicial ao final
        List<Point> riverPath  = RandomWalk(startX, startY, endX, endY);

        // Para cada ponto no caminho do rio, mude o tile para uma textura de água
        foreach (Point point in riverPath)
        {
            _mapa.AlterarTextura(point.X, point.Y, _texturaRio, true); // O rio é impassável
        }
    
        
    }

    public void AddForest()
    {
        // Implemente a lógica para adicionar uma floresta ao mapa.
        // Isso pode envolver a seleção de uma região aleatória do mapa e a alteração dos tiles correspondentes para representar as árvores.
    }
    
    public List<Point> RandomWalk(int startX, int startY, int endX, int endY)
    {
        List<Point> path = new List<Point>();
        Point currentPoint = new Point(startX, startY);
        path.Add(currentPoint);

        Random random = new Random();
        while (currentPoint.X != endX || currentPoint.Y != endY)
        {
            int direction = random.Next(4); // Gera um número aleatório entre 0 e 3
            switch (direction)
            {
                case 0: // Norte
                    currentPoint.Y--;
                    break;
                case 1: // Sul
                    currentPoint.Y++;
                    break;
                case 2: // Leste
                    currentPoint.X++;
                    break;
                case 3: // Oeste
                    currentPoint.X--;
                    break;
            }

            // Certifique-se de que o ponto está dentro dos limites do mapa
            currentPoint.X = Math.Clamp(currentPoint.X, 0, _mapa.LarguraMapa - 1);
            currentPoint.Y = Math.Clamp(currentPoint.Y, 0, _mapa.AlturaMapa - 1);

            path.Add(currentPoint);
        }
        CorrigirRandomWalk();
        CorrigirRandomWalk();
        return path;
    }

    public void CorrigirRandomWalk()
    {
        for (int x = 0; x < _mapa.LarguraMapa; x++)
        {
            for (int y = 0; y < _mapa.AlturaMapa; y++)
            {
                // Se o tile atual é grama...
                if (_mapa.ObterTile(x, y).GetTexture() == _texturaRio)
                {
                    bool cercadoPorAgua = true;

                    // Verifique os tiles adjacentes
                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (_mapa.ObterTile(x + dx, y + dy).GetTexture() != _texturaRio)
                            {
                                cercadoPorAgua = false;
                                break;
                            }
                        }

                        if (!cercadoPorAgua)
                            break;
                    }

                    // Se o tile de grama está cercado por água, mude-o para água
                    if (cercadoPorAgua)
                    {
                        _mapa.AlterarTextura(x, y, _texturaRio, true);
                    }
                }
            }
        }
    }


    
    public static List<Point> BresenhamLine(int x1, int y1, int x2, int y2)
    {
        List<Point> result = new List<Point>();

        int dx = Math.Abs(x2 - x1), sx = x1 < x2 ? 1 : -1;
        int dy = -Math.Abs(y2 - y1), sy = y1 < y2 ? 1 : -1;
        int err = dx + dy, e2;

        while (true)
        {
            result.Add(new Point(x1, y1));
            if (x1 == x2 && y1 == y2) break;
            e2 = 2 * err;
            if (e2 >= dy) { err += dy; x1 += sx; }
            if (e2 <= dx) { err += dx; y1 += sy; }
        }

        return result;
    }
}

