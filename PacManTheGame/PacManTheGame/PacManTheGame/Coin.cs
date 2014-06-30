using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacManTheGame
{
    class Coin
    {
        public Texture2D coinsTexture2D;
        public Rectangle coinsdBackGroundRectangle;

        public bool isDeteleted = false;

        public Coin(Texture2D newcoinsTexture2D, Rectangle newcoinsdBackGroundRectangle)
          
        {
            coinsdBackGroundRectangle = newcoinsdBackGroundRectangle;
            coinsTexture2D = newcoinsTexture2D;

        }



        public void Draw(SpriteBatch spriteBatch)
        {
            if (isDeteleted == false)
            {
                spriteBatch.Draw(coinsTexture2D, coinsdBackGroundRectangle, Color.White);
            }
            
           
        }


        public void RemoveCoins()
        {
            isDeteleted = true;
           
        }

    }
}
