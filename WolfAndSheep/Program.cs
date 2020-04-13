using System;

namespace WolfAndSheep
{
    /// <summary>
    /// Esta classe contém o método Main onde vai fazer loop do jogo
    /// </summary>
    class Program
    {
        /// <summary>
        /// Inicialização do jogo
        /// </summary>
        private static void Main()
        {
            // Cria um Menu Inicial e chama a função Menu
            MenuInicial menuInicial = new MenuInicial();
            menuInicial.Menu();
        }
    }
}