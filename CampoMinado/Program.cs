using System;

namespace CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            Campo mineField = new Campo();

            mineField.Tabuleiro(5, 12);
            mineField.Start();
            mineField.Update();
        }
    }
}
