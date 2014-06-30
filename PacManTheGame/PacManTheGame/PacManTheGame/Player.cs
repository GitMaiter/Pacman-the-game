using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


namespace PacManTheGame
{   

    class Player : Character
    {

       public Texture2D pacmanTexture2DRight, pacmanTexture2DLeft, pacmanTexture2DUp, pacmanTexture2DDown;



       bool imageChange = false;

      public Player(Texture2D newghostTexture2D, Rectangle newghostBackGroundRectangle)  // Конструктор 
            : base(newghostTexture2D, newghostBackGroundRectangle)
        {
   
        }

      protected override void Update(Field field)
      {
          base.Update(field);
          CheckCoinsCollision();
      }

        public void CheckCoinsCollision() // проверка на столкновения pacman и coins
        {
            foreach (Coin coin in currentField.coins)
            {
                if (coin.isDeteleted == false)
                {
                    Rectangle newRectangle = new Rectangle();

                    newRectangle.X = coin.coinsdBackGroundRectangle.Center.X -5;
                    newRectangle.Y = coin.coinsdBackGroundRectangle.Center.Y -5;
                    newRectangle.Height = 10;
                    newRectangle.Width = 10;

                    if (newRectangle.Intersects(characterBackGroundRectangle) == true)
                    {

                        coin.isDeteleted = true;
                       

                    }
                }
                
            }
        
        
        }

       public  void changeDirection(CharacterDirection playerDirEx)    // Выбираем направление PacMan
       {
           characterDirEx = playerDirEx;

           switch (characterDirEx)
           {
               case CharacterDirection.characterUp:
                   currentTexture2D = pacmanTexture2DUp;  // В зависимости от положения присваиваем нужную текстуру               
                   break;

               case CharacterDirection.characterUpDown:
                   currentTexture2D = pacmanTexture2DDown;
                   break;

               case CharacterDirection.characterUpLeft:
                   currentTexture2D = pacmanTexture2DLeft;
                   break;

               case CharacterDirection.characterUpRight:
                   currentTexture2D = pacmanTexture2DRight;
                   break;

               default:
                   break;
           }

          // ShrinkToCurrentTexture();

       }

       public void SetLeftImage(Texture2D newImageLeft)
       {
           pacmanTexture2DLeft = newImageLeft;
       }

       public void SetRightImage(Texture2D newImageLeft)
       {
           pacmanTexture2DRight = newImageLeft;
       }

       public void SetDownImage(Texture2D newImageLeft)
       {
           pacmanTexture2DDown = newImageLeft;
       }

       public void SetUpImage(Texture2D newImageLeft)
       {
           pacmanTexture2DUp = newImageLeft;
       }


       
    }

}
