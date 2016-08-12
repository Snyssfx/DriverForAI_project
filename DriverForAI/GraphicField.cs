/*
    **************************************************************************
    * Judge for AI ("Connect Five" game).                               	   *
    *                                                                     	 *
    * This program should be used for Connect Five Competition.            	 *
    * Connect Five is the game like Connect Four; for more information see   *
    * http://www.math.spbu.ru/user/chernishev/connectfive/connectfive.html   *
    *                                                                     	 *
    * Author: Gleb Zakharov                                                	 *
    * Email: <last name><first name>i@gmail.com                           	 *
    * Year: 2015                                                          	 *
    * See the LICENSE.txt file in the project root for more information.     *
    **************************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DriverForAI
{
    class GraphicField
    {
        public const int cellNums = 10;
        public const int centerOfField = cellNums / 2;
        private char[,] field = new char[10, 10];
        public char[,] Field
        {
            get {return field;}
            set {field = value;}
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Step"></param>
        /// <param name="g"></param>
        public GraphicField(int Step, Game g)
        {
            generateNewField();
            if (Step != 0 ) {
                for ( int i = 1; i <= Step; i++ ) {
                    char symbol = 'O';
                    int j1 = 0;
                    if ( i % 2 == 1 ) {
                        symbol = 'X';
                        j1 = i / 2 + 1;
                    } else {
                        symbol = 'O';
                        j1 = i / 2;
                    }
                    string pathh = Program.Path + @"\" + g.NumberOfGame + '\\' + 'X' + '\\' +
                        symbol + (j1) + ".txt";
                    using ( var reader = new StreamReader(pathh) ) {
                        int turn = int.Parse(reader.ReadToEnd());
                        for ( int j = cellNums - 1; j > 0; j-- ) {
                            if ( (turn != centerOfField - 1) && (turn != centerOfField) || (j != 1) ) {
                                Field[j, turn] = Field[j - 1, turn];
                            }
                        }
                        if ( (turn == centerOfField - 1) || (turn == centerOfField) )
                            Field[1, turn] = symbol;
                        else
                            Field[0, turn] = symbol;
                    }
                }
            }
        }

        public GraphicField()
        {
            generateNewField();
        }

        public GraphicField(Game g, char symbol, int turn)
        {
            Field = g.Field;
            for ( int j = cellNums - 1; j > 0; j-- ) {
                if ( (turn != centerOfField - 1) && (turn != centerOfField) || (j != 1) ) {
                    Field[j, turn] = Field[j - 1, turn];
                }
            }
            if ( (turn == centerOfField - 1) || (turn == centerOfField) )
                Field[1, turn] = symbol;
            else
                Field[0, turn] = symbol;
        }

        private void generateNewField()
        {
            for ( int i = 0; i < cellNums; i++ ) {
                for ( int j = 0; j < cellNums; j++ )
                    field[i, j] = '.';
            }
            field[0, 4] = '#';
            field[0, 5] = '#';
        }
    }

    
}
