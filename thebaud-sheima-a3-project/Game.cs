// Include the namespaces (code libraries) you need below.
using System;
using System.Collections.Generic;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    public class Game
    {
        public Player player;
        public List<Obstacle> obstacles;

        // Moving background variables
        public float gradientPositionX = 0f;
        public float gradientSpeed = 50f;

        public Game()
        {
            player = new Player();
            obstacles = new List<Obstacle>();
        }

        public void Setup()
        {
            // Set up window
            Window.SetTitle("Lucy the Space Cat");
            Window.SetSize(800, 600);

            // Initialize player and load textures
            player.LoadTextures();

            // Add obstacles and load their textures
            obstacles.Add(new Obstacle("small", 100));  // 
            obstacles.Add(new Obstacle("big", 200));    // 

            foreach (var obstacle in obstacles)
            {
                obstacle.LoadTextures();
            }
        }

        public void Update()
        {
            // Handle jump input
            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                player.Jump();
            }

            // Update player
            player.Update();

            // Scroll the background
            gradientPositionX -= gradientSpeed * Time.DeltaTime;
            if (gradientPositionX < -800)
                gradientPositionX = 0f;

            DrawScrollingGradient();    
            DrawObstacles();            
            player.Draw();              
        }

        public void DrawObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.Draw();
            }
        }

        public void DrawScrollingGradient()
        {
            // Draw gradient sky
            for (int i = 0; i < 400; i++)
            {
                float t = i / 400.0f;
                int r = (int)(202 + t * (255 - 202));
                int g = (int)(119 + t * (255 - 119));
                int b = (int)(217 + t * (255 - 217));

                Draw.LineSize = 1;
                Draw.LineColor = new Color(r, g, b);
                Draw.LineSharp(new Vector2(gradientPositionX + 0, i), new Vector2(gradientPositionX + 800, i));
            }

            // Draw ground
            Draw.FillColor = new Color("#E3D3A2");
            Draw.Rectangle(0, 400, 800, 200);

            Draw.LineSize = 1;
            Draw.LineColor = new Color("#B89C6C");
            Draw.LineSharp(new Vector2(0, 400), new Vector2(800, 400));

            // Optional small rocks for decoration
            for (int i = 0; i < 20; i++)
            {
                float x = i * 40.0f;

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#997543");
                Draw.PolyLine(new Vector2(x, 405), new Vector2(x + 3, 405));

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#997543");
                Draw.PolyLine(new Vector2(x + 10, 410), new Vector2(x + 15, 410));

                Draw.LineSize = 1;
                Draw.LineColor = new Color("#997543");
                Draw.PolyLine(new Vector2(x + 25, 402), new Vector2(x + 28, 402));
            }
        }
    }
}