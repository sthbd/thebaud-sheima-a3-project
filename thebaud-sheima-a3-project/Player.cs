using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        public Texture2D walk1;
        public Texture2D walk2;
        public float animationTimer = 0f;
        public bool useWalkTexture = false;

        public float xPosition = 0f;  // Keep xPosition fixed
        public float yPosition = 280f;  // Starting yPosition (aligned with ground level)
        public float moveSpeed = 100f;
        public float scaleWalk = 0.2f;
        public int newWidth;
        public int newHeight;

        // Jumping variables
        public float velocityY = 0f;  // Vertical velocity
        public float gravity = 500f;  // Gravity force (pulls player down)
        public float jumpForce = -300f;  // How high the player jumps (negative for upward movement)
        public bool isJumping = false;  // Whether the player is currently jumping
        public bool isOnGround = false; // Whether the player is on the ground
        public float groundLevel = 280f; // The ground level

        /// <summary>
        /// Load the player textures.
        /// </summary>
        public void LoadTextures()
        {
            walk1 = Graphics.LoadTexture("MohawkGame2D/Texture/lucywalk1.png");
            walk2 = Graphics.LoadTexture("MohawkGame2D/Texture/lucywalk2.png");

            newWidth = (int)(walk1.Width * scaleWalk);
            newHeight = (int)(walk1.Height * scaleWalk);
        }

        /// <summary>
        /// Update the player's position and animation.
        /// </summary>
        public void Update()
        {
            // Animation logic (keeps player walking animation)
            animationTimer += Time.DeltaTime;
            if (animationTimer > 1f)
            {
                useWalkTexture = !useWalkTexture;
                animationTimer = 0f;
            }

            // Check if the player is on the ground
            if (yPosition >= groundLevel)
            {
                yPosition = groundLevel;  // Ensure the player stays on the ground level
                isOnGround = true;
                velocityY = 0f;  // Stop downward velocity once the player is on the ground
            }
            else
            {
                isOnGround = false;
            }

            // Handle Jumping and Gravity
            if (isJumping && isOnGround)  // Can only jump if on the ground
            {
                velocityY = jumpForce;  // Apply the jump force upwards
                isJumping = false;  // Reset the jumping flag
            }

            // Apply gravity if not on the ground
            if (!isOnGround)
            {
                velocityY += gravity * Time.DeltaTime;  // Apply gravity over time
            }

            // Update the yPosition based on velocity
            yPosition += velocityY * Time.DeltaTime;

            // Keep xPosition fixed (no horizontal movement)
            xPosition = 0f;  // Ensure horizontal position stays the same
        }

        /// <summary>
        /// Draw the player.
        /// </summary>
        public void Draw()
        {
            if (useWalkTexture)
            {
                Graphics.Draw(walk1, new Vector2(xPosition, yPosition), new Vector2(newWidth, newHeight));
            }
            else
            {
                Graphics.Draw(walk2, new Vector2(xPosition, yPosition), new Vector2(newWidth, newHeight));
            }
        }

        /// <summary>
        /// Make the player jump.
        /// </summary>
        public void Jump()
        {
            if (isOnGround)  // Can only jump if on the ground
            {
                isJumping = true;
            }
        }
    }
}
