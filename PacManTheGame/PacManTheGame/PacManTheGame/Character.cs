using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacManTheGame
{

    enum CharacterDirection  // Направления персонажей 
    {
        characterUp,
        characterUpDown,
        characterUpLeft,
        characterUpRight
    };

    class Character : Microsoft.Xna.Framework.Game
    {
        public Texture2D currentTexture2D;
        public Rectangle characterBackGroundRectangle;

        
        public CharacterDirection characterDirEx;

        private SpriteBatch spriteCharacter;
        protected Field currentField;

        private static HashSet<Character> evenNumbers = new HashSet<Character>();  // хранение 

        public Character(Texture2D newCharacterTexture2D, Rectangle newCharacterBackGroundRectangle)  // Конструктор 
        {
            characterBackGroundRectangle = newCharacterBackGroundRectangle;

            currentTexture2D = newCharacterTexture2D;
           // ShrinkToCurrentTexture();
            evenNumbers.Add(this);
  
        }

        //protected void ShrinkToCurrentTexture()
      // {
            //characterColor = new Color[currentTexture2D.Width * currentTexture2D.Height];
               
       // }

        static public void DrawCharacters()
        {
            foreach (Character hashVal in evenNumbers)
            {                      
                hashVal.Draw();

            }

        }

        static public void UpdateCharacters(Field field)
        {
            foreach (Character hashVal in evenNumbers)
            {
                hashVal.Update(field);   

            }

        }


        public void SetSpriteBanch(SpriteBatch newSpriteCharacter)
        {
            spriteCharacter = newSpriteCharacter;
        
        }

        protected virtual void Update(Field field)
        {
            UpdatePlayer();
        }

        public void Draw()
        {
            spriteCharacter.Draw(currentTexture2D, characterBackGroundRectangle, Color.White);
        }

        protected virtual void OnCollisionDetected()
        {
        
        
        }


        public void MoveCharacterRight()
        {
            characterBackGroundRectangle.X += 3;
            int xCell = GetCellXHight();
            int yCell = GetCellYCenter();

            int yCellHight = GetCellYHight();
            int yCellLow = GetCellYLow();

            if (currentField.field[yCell, xCell] != 0 || currentField.field[yCellHight, xCell] != 0 || currentField.field[yCellLow, xCell] != 0) 
            {
                characterBackGroundRectangle.X -= 3;
                OnCollisionDetected();
            }
        }

        public void MoveCharacterLeft()
        {
            characterBackGroundRectangle.X -= 3;
         
            int xCell = GetCellXLow();
            int yCell = GetCellYCenter();

            int yCellHight = GetCellYHight();
            int yCellLow = GetCellYLow();

            if (currentField.field[yCell, xCell] != 0 || currentField.field[yCellHight, xCell] != 0 || currentField.field[yCellLow, xCell] != 0)
            {
                characterBackGroundRectangle.X += 3;
                OnCollisionDetected();
            }
    
        }

        public void MoveCharacterDown()
        {
            characterBackGroundRectangle.Y += 3;

            int xCell = GetCellXHight();
            int yCell = GetCellYCenter();

            int yCellHight = GetCellYHight();
            int yCellLow = GetCellYLow();

            if (currentField.field[yCell, xCell] != 0 || currentField.field[yCellHight, xCell] != 0 || currentField.field[yCellLow, xCell] != 0)
            {
                characterBackGroundRectangle.Y -= 3;
                OnCollisionDetected();
            }
        }

        public void MoveCharacterUp()
        {
            characterBackGroundRectangle.Y -= 3;

            int xCell = GetCellXLow();
            int yCell = GetCellYCenter();

            int yCellHight = GetCellYHight();
            int yCellLow = GetCellYLow();

            if (currentField.field[yCell, xCell] != 0 || currentField.field[yCellHight, xCell] != 0 || currentField.field[yCellLow, xCell] != 0)
            {
                characterBackGroundRectangle.Y += 3;
                OnCollisionDetected();
            }
           
        }

        public void changeDirection(CharacterDirection playerDirEx)
        {
            characterDirEx = playerDirEx;
 
        }

       public void UpdatePlayer()  // Обновляем положение 
        {
            switch (characterDirEx)
            {
                case CharacterDirection.characterUp:
                    MoveCharacterUp();
                    break;
                case CharacterDirection.characterUpDown:
                    MoveCharacterDown();
                    break;
                case CharacterDirection.characterUpLeft:
                    MoveCharacterLeft();
                    break;
                case CharacterDirection.characterUpRight:
                    MoveCharacterRight();
                    break;

                default:
                    break;
            }

        }

       private void MoveReverse()
       {
           if (characterDirEx == CharacterDirection.characterUpDown)
           {
               MoveCharacterUp();


           }
           else if (characterDirEx == CharacterDirection.characterUp)
           {
               MoveCharacterDown();


           }
           else if (characterDirEx == CharacterDirection.characterUpLeft)
           {
              MoveCharacterRight();


           }
           else if (characterDirEx == CharacterDirection.characterUpRight)
           {
               MoveCharacterLeft();

           }
       
       
       }

       public int GetCellXLow()
       {
           int position = (characterBackGroundRectangle.X + 3) / 35;

           return position;      
       
       }

       public int GetCellYLow()
       {
           int position = (characterBackGroundRectangle.Y + 3) / 35;

	        return position;

       }


       public int GetCellXHight()
       {
           int position = (characterBackGroundRectangle.X - 3) / 35;

           return position + 1;

       }

       public int GetCellYHight()
       {
           int position = (characterBackGroundRectangle.Y - 3) / 35;

           return position + 1;

       }

       public int GetCellXCenter()
       {
           int position = (characterBackGroundRectangle.Center.X) / 35;

           return position;

       }

       public int GetCellYCenter()
       {
           int position = (characterBackGroundRectangle.Center.Y) / 35;

           return position;

       }

       public void SetCurrentField(Field newField)
       {
           currentField = newField;
       }

    }
}
