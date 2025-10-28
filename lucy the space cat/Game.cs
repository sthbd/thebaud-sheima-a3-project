// Include the namespaces (code libraries) you need below.
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            // Set up window 
            Window.SetTitle("lucy the space cat");
            Window.SetSize(800, 600);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()

        {
            
                Window.ClearBackground(color: Color.OffWhite);


        {

                // Lets draw the map

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#B89C6C");
                Draw.LineSharp(new Vector2(0, 400), new Vector2(800, 400));

            for (int i = 0; i < 20; i++)
            {
                float x = (i * 40.0f);

                // Draw small rocks randomly

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#B89C6C");
                Draw.PolyLine(new Vector2(x, 405), new Vector2(x + 3, 405));


                // Draw bigger rocks randomly

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#8C7A55");
                Draw.PolyLine(new Vector2(x + 10, 410), new Vector2(x + 15, 410));

                // Draw more small rocks randomly

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#B89C6C");
                Draw.PolyLine(new Vector2(x + 25, 402), new Vector2(x + 28, 402));


                // Make a 

            }












            }


        }
    }
}

