using System;
namespace WolfAndSheep
{
    /// <summary>
    /// Mantém o valor da posição das ovelhas e move-as no tabuleiro
    /// </summary>
    public class Ovelhas
    {
        int escolha;

        public int OvelhaX { get; set; }

        public int OvelhaY { get; set; }

        /// <summary>
        /// Constrói as ovelhas novas
        /// </summary>
        /// <param name="linha">Posição em X</param>
        /// <param name="coluna">Posição em Y</param>
        public Ovelhas(int linha = 0, int coluna = 0)
        {

            OvelhaX = linha;

            OvelhaY = coluna;
        }

        /// <summary>
        /// Move as ovelhas no tabuleiro
        /// </summary>
        /// <param name="tabuleironovo">Estado do board atual</param>
        /// <param name="OvelhaDir">Corredor inicial das ovelhas</param>
        /// <param name="escolhaO">Ovelhas escolhida para ser movida</param>
        /// <returns></returns>
        public bool OvelhaM(Tabuleiro tabuleironovo, int OvelhaDir,
         int escolhaO)
        {

            /// Vê se o movimento foi sucedido passando a false quando falha
            bool check = true;

            /// Espera um input valido para uma direção da ovelha
            while(!int.TryParse(Console.ReadLine(), out escolha) ||
            escolha < 1 || escolha > 4) ;

            ///Retira a ovelha da posiçao antiga visualmente 
            tabuleironovo[OvelhaX,OvelhaY] = ' ';

            /// <summary>
            /// Vê se o moviemnto escolhido é possível dependendo do corredor
            /// inicial das ovelhas e da sua posição atual
            /// </summary>
            if (escolha == 1 && (OvelhaDir == 2 || OvelhaDir == 3))
            {
                ///If para a ovelha não conseguir ir para cima de outra ovelha
                /// ou do lobo
                if (OvelhaX > 0 && OvelhaY > 0
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '1'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '2'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '3'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != '4'
                    && tabuleironovo[OvelhaX - 1 , OvelhaY - 1] != 'L')
                {
                    ///Troca da posição da ovelha em cordenadas
                    OvelhaX -= 1;
                    OvelhaY -= 1;
                    
                    
                }

                else
                {
                    
                    check = false;

                }
            }

            else if (escolha == 2 && (OvelhaDir == 3 || OvelhaDir == 4))
            {
               if (OvelhaX > 0 && OvelhaY < 7
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '1'
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '2' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '3' 
                && tabuleironovo[OvelhaX - 1 , OvelhaY + 1] != '4' 
               && tabuleironovo[OvelhaX - 1, OvelhaY + 1] != 'L')
               {
                    OvelhaX -= 1;
                    OvelhaY += 1;
                    
                    
               }
               else
               {
                  
                    check = false;
               }
            }

            else if (escolha == 3 && (OvelhaDir == 1 || OvelhaDir == 2))
            {
                if (OvelhaX < 7 && OvelhaY > 0
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '1'
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '2' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '3' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != '4'
                && tabuleironovo[OvelhaX + 1 , OvelhaY - 1] != 'L')
               {
                    OvelhaX += 1;
                    OvelhaY -= 1;
                    
               }
               else
               {

                    check = false;
               }
            }


            else if (escolha == 4 && (OvelhaDir == 1 || OvelhaDir == 4))
            {
                if (OvelhaX < 7 && OvelhaY < 7 
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '1'
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '2' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '3' 
                && tabuleironovo[OvelhaX + 1 , OvelhaY + 1] != '4'
                && tabuleironovo[OvelhaX + 1, OvelhaY + 1] != 'L')
               {
                    OvelhaX += 1;
                    OvelhaY += 1;
                    
                    
                    
               }
               else
               {
                    check = false;
               }
            }
            else
            {
                check = false;
            }

            // Vê qual ovelha foi movida e atualiza-a visualmente no tabuleiro
            if (escolhaO == 0)
            {
                tabuleironovo[OvelhaX, OvelhaY] = '1';
            }
            else if(escolhaO == 1)
            {
                tabuleironovo[OvelhaX, OvelhaY] = '2';
            }
            else if(escolhaO == 2)
            {
                tabuleironovo[OvelhaX, OvelhaY] = '3';
            }else
            {
                tabuleironovo[OvelhaX, OvelhaY] = '4';
            }
                if (check == false){
                    return false;
                }
                return true;
            }
        }
    }
