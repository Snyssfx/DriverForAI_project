using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace DriverForAI
{
    /*
    **************************************************************************
    * Judge for AI ("Connect Five" game).                               	 *
    *                                                                   	 *
    * This program should be used for Connect Five Competition.          	 *
    * Connect Five is the game like Connect Four; for more information see   *
    * http://www.math.spbu.ru/user/chernishev/connectfive/connectfive.html   *
    *                                                                   	 *
    * Author: Gleb Zakharov                                              	 *
    * Email: <last name><first name>i@gmail.com                         	 *
    * Year: 2015                                                        	 *
    * See the LICENSE.txt file in the project root for more information.     *
    **************************************************************************
   */
    public partial class Form1 : Form
    {
        public static Int32 currentGame = 0;
        private Int32 currentIndex;
        private Int32 scrollStep;
        public Int32 numOfGames;
        
        //need for building tabs
        private List<Graphics> graphic;
        private List<Int32> previousScrollStep;
        List<Label> headerLab;
        List<PictureBox> fieldBox;
        List<TrackBar> historyBar;
        List<Label> winLab;
        List<Label> statLab;
        List<Label> nowTurn;
        List<Button> replayButton;
        TabControl.TabPageCollection gameTabs;
        Game game;
        List<Label> results = new List<Label>();
        List<GraphicField> previousField;
        public const int cellNums = 10;
        public const int centerOfNums = cellNums / 2;
        public const int cellSize = 18;
        public const int fieldSize = 220;
        public const int fullCellSize = fieldSize / cellNums;
        //...
        /// <summary>
        /// constructor of the form. It loads only the button and text label.
        /// For main constructor there is the event mainButton_Click()
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            LblStart2.Text = "Good morning!\nToday players:\n";
            for ( int i = 0; i < Program.players.Count; i++ ) {
                LblStart2.Text += "\n" + Program.players[i].Name;
            }
            LblStart2.Text += ".\n\nGood luck and have fun!";
        }
        //...
        /// <summary>
        /// An event that loads Tabs and starts the contest 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainButton_Click(Object sender, EventArgs e)
        {

            mainButton.Visible = false;
            LblStart2.Visible = false;
            var threadin = 300;// change this parameter to 0 for testing AIs
            labBegin.Visible = true;
            labBegin.Location = new Point(234, 133);
            labBegin.Text = "3...";
            labBegin.Refresh();
            Thread.Sleep(threadin);
            labBegin.Text = "2...";
            labBegin.Refresh();
            Thread.Sleep(threadin);
            labBegin.Text = "1...";
            labBegin.Refresh();
            Thread.Sleep(threadin);
            labBegin.Text = "4...";
            labBegin.Refresh();
            Thread.Sleep(threadin);
            labBegin.Text = "0...";
            labBegin.Refresh();
            Thread.Sleep(threadin);
            labBegin.Text = "Go!";
            labBegin.Refresh();
            Thread.Sleep(threadin);
            Controls.Remove(labBegin);
            if ( numOfGames >= 11 )
                Height += 18;
            if ( numOfGames >= 24 )
                Height += 18;
            mainTab.Location = new Point(3, 3);
            mainTab.Size = new Size(Width - 6, Height - 6);
            mainTab.Visible = true;
            makeForms();
            for ( int i = 0; i < numOfGames; i++ ) {
                doAGame(i);
            }
            List<IPlayer> winnersList = new List<IPlayer>();
            do {
                winnersList.Clear();
                int max = 0;
                for ( int i = 0; i < Program.players.Count; i++ )
                    if ( max < Program.players[i].NumberOfPoints )
                        max = Program.players[i].NumberOfPoints;
                for ( int i = 0; i < Program.players.Count; i++ ) {
                    if ( max == Program.players[i].NumberOfPoints )
                        winnersList.Add(Program.players[i]);
                }
                AddSomeGames(winnersList);
            } while ( winnersList.Count != 1 );
            Results();
        }

        /// <summary>
        /// in this method we play a game in a turn-based marnor (for each pair of players)
        /// </summary>
        /// <param name="i">an index of the game</param>
        void doAGame(int i)
        {
            currentGame = i;
            var threadWay = 0;
            game = Program.g[i];
            game.Player1.Symbol = 'X';
            game.Player2.Symbol = 'O';
            headerLab[i].Text = game.Player1.Name + "(X) VS. (O)" + game.Player2.Name;
            statLab[i].Text = "Moves' count: " + "\nMove: " + "\n";
            winLab[i].Text = "Loading...";
            winLab[i].AutoSize = true;
            historyBar[i].Maximum = 1;
            mainTab.SelectTab(i);
            statLab[i].AutoSize = true;



            while ( (!game.end) && (!game.AllDraw()) ) {
                game.PlayerTurn(game.Player1, game.Player2);
                Thread.Sleep(threadWay);
                DrawField(i, graphic[i]);
                historyBar[i].Maximum = (game.NumberOfTurn) * 2 - 1;
                scrollStep = game.NumberOfTurn;
                statLab[i].Text = "Moves' count: " + game.NumberOfTurn + "\n" + "The last movement: " +
                   game.Player1.Symbol + '\n';
                nowTurn[i].Text = "Current movement: " + scrollStep;
                RefreshItAll(i);
                Application.DoEvents();
                Thread.Sleep(100);

                if ( (!game.end) && (!game.AllDraw()) ) {
                    game.PlayerTurn(game.Player2, game.Player1);
                    Thread.Sleep(threadWay);
                    DrawField(i, graphic[i]);
                    historyBar[i].Maximum = game.NumberOfTurn * 2;
                    scrollStep = game.NumberOfTurn;
                    statLab[i].Text = "Moves' count: " + game.NumberOfTurn + "\n" + "The last movement: " +
                       game.Player2.Symbol + '\n';
                    nowTurn[i].Text = "Current movement: " + scrollStep;
                    RefreshItAll(i);
                    Application.DoEvents();
                    Thread.Sleep(100);
                }

            }


            if ( !game.AllDraw() ) {
                winLab[i].Text = "The winner: " + game.winPlayer.Name;
                if ( game.winPlayer == game.Player1 ) {
                    game.Player1.NumberOfWins++;
                    game.Player2.NumberOfLoses++;
                } else {
                    game.Player2.NumberOfWins++;
                    game.Player1.NumberOfLoses++;
                }
            } else {
                winLab[i].Text = "Draw! Aaaargh!!!";
                game.Player1.NumberOfDraws++;
                game.Player2.NumberOfDraws++;
            }
            RefreshItAll(i);
            var ListOfWays = Directory.EnumerateFiles(Program.Path + @"\" + (i + 1) + @"\" + "X");
            historyBar[i].Maximum = ListOfWays.Count();
            historyBar[i].Minimum = 1;
            previousScrollStep.Add(historyBar[i].Maximum);
            Application.DoEvents();
            Thread.Sleep(1000);
        }

        /// <summary>
        /// if tie resolving: add games if there are more games between potential winners (only winners)
        /// </summary>
        /// <param name="players">List of the potential winners</param>
        void AddSomeGames(List<IPlayer> players)
        {
            if ( players.Count != 1 ) {
                int numOfGames1 = numOfGames;
                for ( int i = 0; i < players.Count - 1; i++ ) {

                    for ( int j = i + 1; j < players.Count; j++ ) {
                        numOfGames++;
                        Program.g.Add(new Game(numOfGames, players[i], players[j], Program.TimeLimit,
                            new GraphicField()));
                        AddTab(numOfGames - 1);
                        if ( Directory.Exists(Program.Path + numOfGames) ) {
                            var directory = new DirectoryInfo(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame);
                            directory.Delete(true);
                        }
                        Directory.CreateDirectory(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame);
                        Directory.CreateDirectory(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame +
                            @"\" + "X");
                        Directory.CreateDirectory(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame +
                            @"\" + "O");
                        doAGame(numOfGames - 1);

                        numOfGames++;
                        Program.g.Add(new Game(numOfGames, players[j], players[i], Program.TimeLimit,
                            new GraphicField()));
                        AddTab(numOfGames - 1);
                        if ( Directory.Exists(Program.Path + numOfGames) ) {
                            var directory = new DirectoryInfo(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame);
                            directory.Delete(true);
                        }
                        Directory.CreateDirectory(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame);
                        Directory.CreateDirectory(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame +
                            @"\" + "X");
                        Directory.CreateDirectory(Program.Path + '\\' + Program.g[numOfGames - 1].NumberOfGame +
                            @"\" + "O");
                        doAGame(numOfGames - 1);
                    }
                }
                if ( numOfGames - numOfGames1 >= 6 )
                    Height += 18;
            }
        }

        /// <summary>
        /// make Tabs and add elements on them
        /// </summary>
        private void makeForms()
        {
            LblStart2.Visible = false;
            numOfGames = Program.NumOfGames;
            mainTab.TabPages.RemoveAt(0);
            mainTab.TabPages.RemoveAt(0);
            mainTab.Multiline = true;
            mainTab.Dock = DockStyle.Fill;
            headerLab = new List<Label>();
            fieldBox = new List<PictureBox>();
            historyBar = new List<TrackBar>();
            winLab = new List<Label>();
            statLab = new List<Label>();
            nowTurn = new List<Label>();
            replayButton = new List<Button>();
            gameTabs = new TabControl.TabPageCollection(mainTab);
            graphic = new List<Graphics>();
            previousField = new List<GraphicField>();
            previousScrollStep = new List<Int32>();

            for ( int i = 0; i < numOfGames; i++ ) {
                AddTab(i);
            }
        }

        /// <summary>
        /// add elements on the tab 
        /// </summary>
        /// <param name="i">an index of the current tab</param>
        void AddTab(int i)
        {
            headerLab.Add(new Label());
            headerLab[i].TextAlign = ContentAlignment.MiddleCenter;
            headerLab[i].Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
            headerLab[i].AutoSize = true;

            replayButton.Add(new Button());
            replayButton[i].Text = "Replay";
            replayButton[i].Location = new Point(104, 315);

            gameTabs.Add("Game " + (i + 1));

            winLab.Add(new Label());
            winLab[i].TextAlign = ContentAlignment.MiddleCenter;
            winLab[i].Font = headerLab[i].Font;
            winLab[i].AutoSize = true;
            winLab[i].Location = new Point(341, 275);

            statLab.Add(new Label());
            statLab[i].Font = new Font("Microsoft Sans Serif", 12);
            nowTurn.Add(new Label());
            nowTurn[i].Font = statLab[i].Font;
            statLab[i].Location = new Point(341, 60);
            nowTurn[i].Location = new Point(341, 170);
            nowTurn[i].AutoSize = true;

            fieldBox.Add(new PictureBox());
            fieldBox[i].Size = new Size(221, 221);
            fieldBox[i].Location = new Point(29, 44);
            fieldBox[i].BackColor = Color.White;
            fieldBox[i].Image = new Bitmap(fieldBox[i].Width, fieldBox[i].Height);
            graphic.Add(Graphics.FromImage(fieldBox[i].Image));
            paintNewField(fieldBox[i], graphic[i]);

            headerLab[i].Location = new Point(29, 13);
            headerLab[i].Show();

            historyBar.Add(new TrackBar());
            historyBar[i].Size = new Size(220, 45);
            historyBar[i].Location = new Point(29, 267);
            historyBar[i].Minimum = 1;

            gameTabs[i].Controls.Add(headerLab[i]);
            gameTabs[i].Controls.Add(winLab[i]);
            gameTabs[i].Controls.Add(statLab[i]);
            gameTabs[i].Controls.Add(nowTurn[i]);
            gameTabs[i].Controls.Add(fieldBox[i]);
            gameTabs[i].Controls.Add(historyBar[i]);
            gameTabs[i].Controls.Add(replayButton[i]);
            gameTabs[i].Show();

            //add events
            historyBar[i].Scroll += new EventHandler(historyBar_Scroll);
            replayButton[i].Click += new EventHandler(replayButton_Click);

            previousField.Add(new GraphicField());
        }


        /// <summary>
        /// draw an empty grid in the picture box
        /// </summary>
        /// <param name="fieldBox">where it needs to be drawn</param>
        /// <param name="graphic">where it needs to be drawn</param>
        private void paintNewField(PictureBox fieldBox, Graphics graphic)
        {
            Pen pen = new Pen(Color.Black);
            for ( int j = 0; j < cellNums; j++ )
                for ( int k = 0; k < cellNums; k++ ) {
                    graphic.DrawRectangle(pen, j * fullCellSize, k * fullCellSize,
                        fullCellSize, fullCellSize);
                }
            pen = new Pen(Color.Gray);
            graphic.DrawRectangle(pen, (centerOfNums - 1) * fullCellSize + 1, (cellNums - 1) * fullCellSize + 1,
                 fullCellSize - 2, fullCellSize - 2);
            graphic.DrawRectangle(pen, (centerOfNums) * fullCellSize + 1, (cellNums - 1) * fullCellSize + 1,
                fullCellSize - 2, fullCellSize - 2);
            fieldBox.Refresh();
        }
        
        //two methods are needed to draw game field in the game

        /// <summary>
        /// draw the current field
        /// </summary>
        /// <param name="numOfField">an index of the field</param>
        /// <param name="g">a graphic element of the field</param>
        void DrawField(int numOfField, Graphics g)
        {
            for(int i = 0; i < cellNums; i++ ) {
                for(int j = 0; j < cellNums; j++ ) {
                    switch ( game.Field[i, j] ) {
                        case '.':
                            g.DrawRectangle(new Pen(Color.White), j * fullCellSize + 2, 
                                (cellNums - 1 - i) * fullCellSize + 2, cellSize, cellSize);
                            break;
                        case 'X':
                            g.DrawImage(new Bitmap(new Bitmap(
                               Program.Path + @"\X.jpg"), cellSize, cellSize),
                                j * fullCellSize + 2, (cellNums - 1 - i) * fullCellSize + 2);
                            break;
                        case 'O':
                            g.DrawImage(new Bitmap(new Bitmap(
                                Program.Path + @"\O.jpg"), cellSize, cellSize),
                                j * fullCellSize + 2, (cellNums - 1 - i) * fullCellSize + 2);
                            break;
                        case '#':
                            g.FillRectangle(new SolidBrush(Color.Gray),
                                new Rectangle(j * fullCellSize + 1, (cellNums - 1 - i) * fullCellSize + 1,
                                cellSize + 2, cellSize + 2));
                            break;
                     }
                }
            }
            previousField[numOfField].Field = game.Field;
        }
        /// <summary>
        /// draw a specified field in the picture box
        /// </summary>
        /// <param name="numOfField">an index of the field</param>
        /// <param name="g">a graphic element of the field</param>
        /// <param name="field">a field that needs to draw</param>
        void DrawField(int numOfField, Graphics g, GraphicField field)
        {
            for ( int i = 0; i < cellNums; i++ ) {
                for ( int j = 0; j < cellNums; j++ ) {

                    if ( field.Field[i, j] != previousField[numOfField].Field[i, j] ) {
                        switch ( field.Field[i, j] ) {
                            case 'X':
                                g.DrawImage(new Bitmap(new Bitmap(
                                   Program.Path + @"\X.jpg"),
                                    cellSize, cellSize), j * fullCellSize + 2,
                                    (cellNums - 1 - i) * fullCellSize + 2);
                                break;
                            case 'O':
                                g.DrawImage(new Bitmap(new Bitmap(
                                   Program.Path + @"\O.jpg"), 
                                    cellSize, cellSize), j * fullCellSize + 2,
                                    (cellNums - 1 - i) * fullCellSize + 2);
                                break;
                            case '.':
                                g.FillRectangle(new SolidBrush(Color.White), j * fullCellSize + 2,
                                    (cellNums - 1 - i) * fullCellSize + 2, cellSize, cellSize);
                                break;
                        }
                    }
                }
            }
            previousField[numOfField].Field = field.Field;
            fieldBox[numOfField].Refresh();
        }
        //...
        /// <summary>
        /// a simple method to refresh all of the elements in the tab
        /// </summary>
        /// <param name="i">an index of the tab we need to refresh</param>
        private void RefreshItAll(int i)
        {
            headerLab[i].Refresh();
            statLab[i].Refresh();
            winLab[i].Refresh();
            fieldBox[i].Refresh();
            historyBar[i].Refresh();
            replayButton[i].Refresh();
            gameTabs[i].Refresh();
            mainTab.Refresh();
            nowTurn[i].Refresh();
        }

        /// <summary>
        /// An event to move forward and backward through the play history
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void historyBar_Scroll(Object sender, EventArgs e)
        {
            var ctr = (TrackBar)(Control) sender;
            currentIndex = historyBar.ToList().IndexOf(ctr);
            scrollStep = historyBar[currentIndex].Value;
            var scrollStep2 = 0;
            if ( historyBar[currentIndex].Maximum % 2 == 0 )
                scrollStep2 = scrollStep / 2;
            else
                scrollStep2 = scrollStep / 2 + 1;
            nowTurn[currentIndex].Text = "Current movement: " + scrollStep2;
            nowTurn[currentIndex].Refresh();
            previousScrollStep[currentIndex] = scrollStep;
            var field = new GraphicField(scrollStep, Program.g[currentIndex]);
            DrawField(currentIndex, graphic[currentIndex], field);
            
        }

        /// <summary>
        /// the event that scrolls the whole game from the start to the end
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replayButton_Click(Object sender, EventArgs e)
        {
            var ctr = (Button) (Control) sender;
            currentIndex = replayButton.ToList().IndexOf(ctr);
            var ListOfWays = Directory.EnumerateFiles(Program.Path + @"\" + (1 + currentIndex) + @"\" + "X");
            for ( int i = 1; i <= ListOfWays.Count(); i++ ) {
                var scrollStep2 = 0;
                if ( historyBar[currentIndex].Maximum % 2 == 0 )
                    scrollStep2 = i / 2;
                else
                    scrollStep2 = i / 2 + 1;
                historyBar[currentIndex].Value = i;
                nowTurn[currentIndex].Text = "Current movement: " + scrollStep2; 
                nowTurn[currentIndex].Refresh();
                previousScrollStep[currentIndex] = i;
                var field = new GraphicField(i, Program.g[currentIndex]);
                DrawField(currentIndex, graphic[currentIndex], field);
                Thread.Sleep(100);
            }
            historyBar[currentIndex].Value = historyBar[currentIndex].Maximum;
        }

        
        /// <summary>
        /// the tab that shows results of the competition
        /// </summary>
        void Results()
        {
            var ListOfResults = new List<int>();
            var rnd = new Random();
            gameTabs.Add("Scores");
            for ( int i = 0; i < Program.players.Count; i++ ) {
                ListOfResults.Add(Program.players[i].NumberOfPoints);
                results.Add(new Label());
                int currentWidth = Width / 2 - 80;
                int currentHeight = (gameTabs[numOfGames].Height - 20) / Program.players.Count * i + 40;
                gameTabs[numOfGames].Controls.Add(results[i]);
                results[i].Location = new Point(currentWidth, currentHeight);
                var colors = new int[] { rnd.Next(255), rnd.Next(255),
                        rnd.Next(256)};
                results[i].FlatStyle = FlatStyle.Flat;
                results[i].AutoSize = true;
                results[i].TextAlign = ContentAlignment.MiddleCenter;
                results[i].Font = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
                results[i].Text = Program.players[i].Name + ": " + Program.players[i].NumberOfPoints;
                results[i].BackColor = Color.FromArgb(120, colors[0], colors[1], colors[2]);
            }
            mainTab.SelectTab(numOfGames);
            gameTabs[numOfGames].Refresh();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < numOfGames; i++ ) {

            }
        }
        public static void doEvents()
        {
            Application.DoEvents();
        }
    }
}
