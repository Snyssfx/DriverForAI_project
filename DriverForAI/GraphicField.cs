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
        //TODO: change digits to constants
        public const int cellNums = 10;
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
                        int way = int.Parse(reader.ReadToEnd());
                        for ( int j = cellNums - 1; j > 0; j-- ) {
                            if ( (way != 4) && (way != 5) || (j != 1) ) {
                                Field[j, way] = Field[j - 1, way];
                            }
                        }
                        if ( (way == 4) || (way == 5) )
                            Field[1, way] = symbol;
                        else
                            Field[0, way] = symbol;
                    }
                }
            }
        }

        public GraphicField()
        {
            generateNewField();
        }

        public GraphicField(Game g, char symbol, int way)
        {
            Field = g.Field;
            for ( int j = cellNums - 1; j > 0; j-- ) {
                if ( (way != 4) && (way != 5) || (j != 1) ) {
                    Field[j, way] = Field[j - 1, way];
                }
            }
            if ( (way == 4) || (way == 5) )
                Field[1, way] = symbol;
            else
                Field[0, way] = symbol;
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
