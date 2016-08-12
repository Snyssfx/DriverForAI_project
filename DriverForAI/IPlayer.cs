/*
    **************************************************************************
    * Judge for AI ("Connect Five" game).                                 	 *
    *                                                                     	 *
    * This program should be used for Connect Five Competition.           	 *
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

namespace DriverForAI
{
    /// <summary>
    /// interface for players
    /// </summary>
    interface IPlayer
    {
        string ReadTurn(int numberOfWay, char Symbol);
        void WriteTurn(int numberOfWay, char Symbol, int Way, int NumberOfGame);
        int NumberOfWins { get; set; }
        int NumberOfDraws { get; set; }
        int NumberOfLoses { get; set; }
        string Path { get; set; }
        int NumberOfPoints { get; }
        string Name { get; }
        char Symbol { get; set; }
        double TimeLimit { get; set; }
    }
}
