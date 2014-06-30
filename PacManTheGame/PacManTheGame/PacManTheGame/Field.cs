using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacManTheGame
{
    class Field 
    {
        public Texture2D fieldTexture2D ;
        public Rectangle fieldBackGroundRectangle;

         public List<Coin> coins  = new List<Coin>();
           


       public  int[,]  field =
        { 
              {5,3,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5},            // >_<
              {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5}, 
              {5,0,1,2,0,1,5,2,0,1,5,5,2,0,1,2,0,1,5,5,2,0,1,5,2,0,1,2,0,5},
              {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5}, 
              {5,0,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2,0,5},
              {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5}, 
              {5,5,2,0,1,5,5,5,2,0,1,5,5,5,5,5,5,5,5,2,0,1,5,5,5,2,0,1,5,5}, 
              {6,6,5,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,5,6,6}, 
              {6,6,5,0,1,0,1,5,5,5,2,0,5,2,0,0,1,5,0,1,5,5,5,2,0,1,0,5,6,6}, 
              {6,6,5,0,0,0,5,5,5,5,5,0,5,0,0,0,0,5,0,5,5,5,5,5,0,0,0,5,6,6}, 
              {6,6,5,0,1,0,5,5,5,5,5,0,5,0,0,0,0,5,0,5,5,5,5,5,0,1,0,5,6,6},
              {6,6,5,0,5,0,1,5,5,5,2,0,5,5,5,5,5,5,0,1,5,5,5,2,0,5,0,5,6,6}, 
              {6,6,5,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,5,6,6},
              {5,5,2,0,1,5,5,5,2,0,1,5,5,5,5,5,5,5,5,2,0,1,5,5,5,2,0,1,5,5},
              {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5},
              {5,0,1,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2,0,5},
              {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5}, 
              {5,0,1,2,0,1,5,2,0,1,5,5,2,0,1,2,0,1,5,5,2,0,1,5,2,0,1,2,0,5}, 
              {5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5}, 
              {5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5} 
              
            };

     

        public Field(Texture2D newFieldTexture2D, Rectangle newFieldBackGroundRectangle) // Конструктор 
        {
            fieldBackGroundRectangle = newFieldBackGroundRectangle;
            fieldTexture2D = newFieldTexture2D;

            CreateField();
      
        }

        public void Draw(SpriteBatch spriteBatch)  // Метод отрисовки поля 
        {
           

            for (int y = 0; y < 20; y++)
			{
                for (int x = 0; x < 30; x++)
			    {
                    if (field[y,x] != 0)
	                {
                        fieldBackGroundRectangle.X  = x * 35;
                        fieldBackGroundRectangle.Y = y * 35;
                        spriteBatch.Draw(fieldTexture2D, fieldBackGroundRectangle, Color.White);

		 
	                }
			 
			    }
			 
			}

             foreach (Coin coin in coins)
             {
                 coin.Draw(spriteBatch);
             }
               
            
        }

        public void CreateField()
        {
           for (int x = 0; x < 30; x++)
             {
                for (int y = 0; y < 20; y++)
                  {             
                           
                     if (field[y, x] == 0)
                      {
                            Coin coin = new Coin(Game1.GetInstance().Content.Load<Texture2D>("coin"), new Rectangle(x * 35, y * 35, 35, 35));
                            coins.Add(coin);           

                      }

                 }
              
            }

        }

  
    }
}
