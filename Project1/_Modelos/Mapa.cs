using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1._Gerenciadores;


namespace Project1._Modelos
{
    public class Mapa
    {
        private readonly Point _tamanhoDoMaṕa = new Point(30, 20);
        private readonly Vector2 _offsetMapa = new Vector2(5.5f, 0.5f);
        
        private readonly Point _tamanhoTile;
        private Point _tileSelecionadoKeyboard = new(0, 0);

        private readonly Tile[,] _tiles;


        public Mapa()
        {
            _tiles = new Tile[_tamanhoDoMaṕa.X, _tamanhoDoMaṕa.Y];


            Texture2D[] texturas =
            {
                Globais.Cm.Load<Texture2D>("grass45"),
                Globais.Cm.Load<Texture2D>("grass135"),
                Globais.Cm.Load<Texture2D>("grass225"),
                Globais.Cm.Load<Texture2D>("grass315")
            };

            _tamanhoTile.X = texturas[0].Width;
            _tamanhoTile.Y = texturas[0].Height / 2;

            Random random = new();
            
            for (int y = 0; y < _tamanhoDoMaṕa.Y; y++)
            {
                for (int x = 0; x < _tamanhoDoMaṕa.X; x++)
                {
                    int r = random.Next(0, texturas.Length);
                    _tiles[x, y] = new(texturas[r], MapaParaTela(x, y));
                }
            }
            
            _tiles[_tileSelecionadoKeyboard.X,_tileSelecionadoKeyboard.Y].SelecionarTile();
            
        }

        private Vector2 MapaParaTela(int x, int y)
        {
            var telaX = ((x - y) * _tamanhoTile.X / 2) + (_offsetMapa.X * _tamanhoTile.X);
            var telaY = ((x + y) * _tamanhoTile.Y / 2) + (_offsetMapa.Y * _tamanhoTile.Y);

            return new(telaX, telaY);
        }
        
        /// <summary>
        /// Método para impedir que o jogador passe por tiles selecionados como impassável
        /// </summary>
        /// <param name="novoX"></param>
        /// <param name="novoY"></param>
        public void MoverTileSelecionado(int novoX, int novoY)
        {
            if (!_tiles[novoX, novoY]._tileImpassavel)
            {
                _tiles[_tileSelecionadoKeyboard.X,_tileSelecionadoKeyboard.Y].DesselecionarTile();
        
                _tileSelecionadoKeyboard.X = novoX;
                _tileSelecionadoKeyboard.Y = novoY;
        
                _tiles[_tileSelecionadoKeyboard.X,_tileSelecionadoKeyboard.Y].SelecionarTile();
            }
        }
        public void TornarImpassavel(int x, int y)
        {
            if (x >= 0 && x < _tamanhoDoMaṕa.X && y >= 0 && y < _tamanhoDoMaṕa.Y)
            {
                _tiles[x, y]._tileImpassavel = true;
            }
            else
                throw new ArgumentOutOfRangeException("As coordenadas fornecidas estão fora dos limites do mapa.");
        }

        public void Update()
        {
            if (GerenciadorInput.Direcao != Point.Zero)
            {
                var novoX = Math.Clamp(_tileSelecionadoKeyboard.X + GerenciadorInput.Direcao.X, 0, _tamanhoDoMaṕa.X - 1);
                var novoY = Math.Clamp(_tileSelecionadoKeyboard.Y + GerenciadorInput.Direcao.Y, 0, _tamanhoDoMaṕa.Y - 1);

                MoverTileSelecionado(novoX, novoY);

                // Zera a direção do input após ser usada
                GerenciadorInput.ZerarDirecao();
            }
        }
        public void Draw()
        {
            for (int y = 0; y < _tamanhoDoMaṕa.Y; y++)
            {
                for (int x = 0; x < _tamanhoDoMaṕa.X; x++)
                {
                    _tiles[x, y].Draw();
                    TornarImpassavel(6,5);
                    TornarImpassavel(6,6);
                    TornarImpassavel(6,7);
                }
            }
        }
        
    }
    
}
