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
        string ReadWay(int numberOfWay, char Symbol);
        void WriteWay(int numberOfWay, char Symbol, int Way, int NumberOfGame);
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
