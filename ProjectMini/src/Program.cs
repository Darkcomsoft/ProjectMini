﻿using System;

namespace ProjectMini
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Application())
            {
                game.Run();
            }
        }
    }
}
