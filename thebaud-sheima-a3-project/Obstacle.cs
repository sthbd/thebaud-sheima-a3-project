using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{ 

   public class Obstacle
{
    public Texture2D smallMet;
    public Texture2D bigMet;
    public float xPosition;
    public float yPosition;
    public int newWidth;
    public int newHeight;
    public string obstacleType; // Type of the obstacle: "small" or "big"

    // Ground level constant (same as player's ground level)
    private const float groundLevel = 400f;

    public Obstacle(string type, float x)
    {
        obstacleType = type;
        xPosition = x;
        // Default yPosition (this can be adjusted if needed)
        yPosition = groundLevel - 50f; // Placing obstacles slightly above the ground
    }

    // Load the textures for the obstacles
    public void LoadTextures()
    {
        if (obstacleType == "small")
        {
            smallMet = Graphics.LoadTexture("MohawkGame2D/Texture/smallmet.png");
            newWidth = (int)(smallMet.Width * 0.2f);
            newHeight = (int)(smallMet.Height * 0.2f);
        }
        else if (obstacleType == "big")
        {
            bigMet = Graphics.LoadTexture("MohawkGame2D/Texture/bigmet.png");
            newWidth = (int)(bigMet.Width * 0.2f);
            newHeight = (int)(bigMet.Height * 0.2f);
        }
    }

    // Draw the obstacle
    public void Draw()
    {
        if (obstacleType == "small")
        {
            Graphics.Draw(smallMet, new Vector2(xPosition, yPosition), new Vector2(newWidth, newHeight));
        }
        else if (obstacleType == "big")
        {
            Graphics.Draw(bigMet, new Vector2(xPosition, yPosition), new Vector2(newWidth, newHeight));
        }
    }
}
}
