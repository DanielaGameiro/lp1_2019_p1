using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Esta classe contém o método Main onde vai fazer loop do jogo
    /// </summary>
    class Program
    {
        private static int OvelhaDir;
        private static bool check = false;
        private static int escolhaO;
        /// <summary>
        /// Inicializar o jogo
        /// </summary>
        private static void Main()
        {
            // Criar um Menu Inicial e chamar a função Menu
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Menu();

            // Criar e renderizar um tabuleiro 8x8
            Tabuleiro tabuleiroNovo = new Tabuleiro (8,8);
            Render(tabuleiroNovo);
            ///Pergunta ao jogador a posiçao inicial das ovelhas
            Console.WriteLine("Onde quer por as ovelhas?\n"
                + "1 = cima , 2 = direita\n"
                + "3 = baixo, 4 = esquerda");
            /// Pede o input e espera por algo válido
            while (!int.TryParse(Console.ReadLine(), out OvelhaDir) ||
                OvelhaDir < 1 || OvelhaDir > 4);
            
            /// <summary>
            /// funçao que cria um array de ovelhas e mete-as no tabuleiro
            /// </summary>
            /// <returns></returns>
            Ovelhas[] ovelhas = PoeOvelhas(tabuleiroNovo, OvelhaDir);

            while(true){
                ///Controlo para saber se a ovelha foi movida com sucesso
                check = false;

                ///Pede o número da ovelha a mover
                Console.WriteLine("Que ovelha queres mexer?\n"
                    + "1 , 2 , 3 , 4");


                ///Espera por um numero de ovelha válido
                while (!int.TryParse(Console.ReadLine(), out escolhaO) ||
                    escolhaO < 1 || escolhaO > 4) ;

                ///Faz loop até uma ovelha ser movida com sucesso
                while(check == false)
                {
                    /// Pede ao jogador para onde quer mover a ovelha
                    Console.WriteLine("Para onde queres mexer a ovelha?\n"
                     + "1 - Cima-esquerda  2 - Cima-Direita\n"
                     + "3 - Baixo-esquerda 4 - Baixo-Direira");

                    /// Inicia a função que irá mover a ovelha com o tabuleiro
                    /// atual e a posição das ovelhas escolhida inicialmente
                    check = ovelhas[escolhaO-1].OvelhaM(tabuleiroNovo, OvelhaDir
                    ,escolhaO-1);

                    ///Se o movimento não for completo apresenta frase de erro
                    if (check == false){
                        Console.WriteLine("Nao podes mexer a ovelha para ai");

                    }

                 
                }
                


                ///Atualiza o tabuleiro para os olhos do jogador
                Render(tabuleiroNovo);
            }  
        }

        private static Ovelhas[] PoeOvelhas(Tabuleiro tabuleiroNovo,
         int OvelhaDir){
            ///Cria o array de ovelhas
            Ovelhas[] ovelhas = new Ovelhas[4];

            int x = OvelhaDir == 1 || OvelhaDir == 4 ? 0 :
                tabuleiroNovo.Y - 1;
            
            /// int para guardar o número da ovelha nova no array
            int i = 0;

            /// Loop para a altura do tabuleiro
            for (int y = 0 ; y < tabuleiroNovo.Y; y++)
            {
                ///Vê qual a direção das ovelhas (em coluna)
                if(OvelhaDir == 1 || OvelhaDir == 3)
                {
                    ///Vê se é uma casa jogável para por a ovelha
                    if (tabuleiroNovo[x, y] == ' ')
                    {
                        ///Cria a nova ovelha na cordenada x e y dada
                        ovelhas[i] = new Ovelhas(x, y);

                        i++;
                    }
                }
                /// Outra direção das ovelhas(em linha)
                else {

                    ///Vê se é uma casa jogável para por a ovelha
                    if (tabuleiroNovo[y, x] == ' ')
                    {
                        ///Cria a nova ovelha na cordenada y e x dada
                        ovelhas[i] = new Ovelhas(y, x);

                        i++;

                    }
                }
            }
            
                ///Atualiza o visualmente o tabuleiro com
                ///o número de cada ovelha no tabuleiro
                tabuleiroNovo[ovelhas[0].OvelhaX, ovelhas[0].OvelhaY] = '1';
                tabuleiroNovo[ovelhas[1].OvelhaX, ovelhas[1].OvelhaY] = '2';
                tabuleiroNovo[ovelhas[2].OvelhaX, ovelhas[2].OvelhaY] = '3';
                tabuleiroNovo[ovelhas[3].OvelhaX, ovelhas[3].OvelhaY] = '4';

            ///Mostra o tabuleiro atual ao jogador
            Render(tabuleiroNovo);

            return ovelhas;
        }

        /// <summary>
        /// Renderizar o tabuleiro completo
        /// </summary>
        /// <param name="tabuleiroNovo">Tabuleiro completo</param>
        private static void Render(Tabuleiro tabuleiroNovo)
        {
            // Parte de cima do tabuleiro
            Console.WriteLine("__________________________________________\n" +
            "__________________________________________");

            // Loop da largura do tabuleiro
            for (int x = 0; x < tabuleiroNovo.X; x++)
            {
                // Loop da altura do tabuleiro
                for (int y = 0; y < tabuleiroNovo.Y; y++)
                {
                    // Separadores entre os quadrados do tabuleiro
                    Console.Write("||");
                    
                    // Exibe os espaços vazios e os X's no tabuleiro
                    Console.Write($" {tabuleiroNovo[x, y]} ");
                }
                // Lado direito do tabuleiro
                Console.Write("||\n");           
            }
            // Parte de baixo do tabuleiro
            Console.WriteLine("__________________________________________\n" +
            "__________________________________________");
        }
        public void OvelhasPerdem(int OvelhaDir){

            if(OvelhaDir == 1){
                
                
            }else if(OvelhaDir == 2){

            }else if(OvelhaDir == 3){

            }else if(OvelhaDir == 4){
                
            }
        }
        
    }
}
