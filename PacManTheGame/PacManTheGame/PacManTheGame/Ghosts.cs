using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacManTheGame
{

     

    class Ghost : Character
    {
        public Rectangle ghostBackGroundRectangle;

        private Random rand = new Random(DateTime.Now.Second);  // Меняем число в зависимости от текущего времени установленного на пк
      

        public Ghost(Texture2D newghostTexture2D, Rectangle newghostBackGroundRectangle)  // Конструктор 
            : base(newghostTexture2D, newghostBackGroundRectangle)
        {
            ghostBackGroundRectangle = newghostBackGroundRectangle;

        }

        protected override void OnCollisionDetected()
        {
            SetRandomDirection();
        }

        protected override void Update(Field field)  // Обновляет позицию привидений
        {
            UpdatePlayer();
            int iRand = rand.Next(0, 100); // Случайное число из-за которого привидения могут поменять направление движения
            if (iRand <  2)
            {
                SetRandomDirection();
                
            }
           // if (CollidedWithMaze(field))
           // {
          //      SetRandomDirection();
          //  }
        }

        public void SetRandomDirection()  // В зависимости от числа randomNumber привидение выбирает путь (от 0 до 4х)
        {
           int randomNumber = rand.Next(0, 4);

           changeDirection((CharacterDirection)randomNumber);
        }
    }
}
