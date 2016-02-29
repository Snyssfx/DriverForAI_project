# DriverForAI_project

Driver for AI ("Connect Five" game).

This program shoud be used for Connect Five Competition. Connect Five is the game like Connect Four; for more information http://www.math.spbu.ru/user/chernishev/connectfive/connectfive.html

Author: Gleb Zakharov.
For starting a competition, you have to add to a custom folder .exe file, X and O .jpg and Configs.txt

    Arguments that brains' writers receive for their AI:
    Session directory, symbol, timeLimit.
    For example:
    C:\Example\Game_5\O\ X 4,875

    Before the contest you need to write this in Config.txt:
    Player 1's folder, player 2's (absolute path to a player 2 folder) on a new line and so on.
    Players' names are names of the .exe file.
    On new lines timeLimits for all of the players.

    If you want to add a random AI, write Random\some_random_name
    as a new player.

    For example:

    C:\Example\Super_Hero
    C:\Example\Potential_Winner
    Random\Bot_David
    TimeLimit = 4,875
    TimeLimit = 5,0
    TimeLimit = 1000
