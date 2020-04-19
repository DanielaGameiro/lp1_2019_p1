namespace WolfAndSheep
{
    /// <summary>
    /// Esta classe contém o método Tabuleiro onde vai criar o tabuleiro 8x8
    /// </summary>
    public class Tabuleiro
    {
        // Declarar variáveis
        private char[,] tabuleiro;

        /// <summary>
        /// Definir os valores do tabuleiro na posição escolhida
        /// </summary>
        /// <value>Posição X e Y</value>
        public char this[int x, int y]
        {
            get { return tabuleiro[x, y]; }
            set { tabuleiro[x, y] = value; }
        }

        // Dimensão X e Y do tabuleiro
        public int X => tabuleiro.GetLength(0);
        public int Y => tabuleiro.GetLength(1);

        /// <summary>
        /// Criar um tabuleiro com as dimensões escolhidas
        /// </summary>
        /// <param name="DimX">Largura</param>
        /// <param name="DimY">Altura</param>
        public Tabuleiro(int DimX, int DimY)
        {
            tabuleiro = new char[DimX, DimY];

            // Largura
            for (int x = 0; x < DimX; x++)
            {
                // Altura
                for (int y = 0; y < DimY; y++)
                {
                    // Verificar se a posição está num quadrado "não-jogável"
                    if (((x + y) % 2) == 0)
                    {
                        // Se sim, meter um X nesse quadrado
                        tabuleiro[x, y] = 'X';
                    }

                    // Se a posição está num quadrado "jogável", deixar esse
                    // espaço vazio
                    else
                    {
                        tabuleiro[x, y] = ' ';
                    }
                }
            }
        }
    }
}