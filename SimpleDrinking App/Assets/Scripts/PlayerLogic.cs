using UnityEngine;

public class PlayerLogic
{
    private static Player[] players;
    public static int numberOfPlayers;
    private static int firstRand;
    private static int secondRand;
    private static int thirdRand;
    private static string lastPlayer;

    public static Player[] getPlayers()
    {
        return players;
    }

    public static Player getPlayerWithName(string name)
    {
        if (name != null)
        {
            for (var i = 0; i < players.Length; i++)
            {
                if (name.Equals(players[i].GetName()))
                {
                    return players[i];
                }
            }
        }
        return null;
    }

    public static string FirstPlayer()
    {
        firstRand = Random.Range(0, players.Length);
        string playerName = players[firstRand].GetName();
        lastPlayer = playerName;
        IncrementPlayerOccurrence(playerName); // Increment occurrence
        return playerName;
    }

    public static string SecondPlayer()
    {
        do
        {
            secondRand = Random.Range(0, players.Length);
        } while (secondRand == firstRand);

        string playerName = players[secondRand].GetName();
        lastPlayer = playerName;
        IncrementPlayerOccurrence(playerName); // Increment occurrence
        return playerName;
    }

    public static string ThirdPlayer()
    {
        if (numberOfPlayers > 2)
        {
            do
            {
                thirdRand = Random.Range(0, players.Length);
            } while (thirdRand == firstRand || thirdRand == secondRand);

            string playerName = players[thirdRand].GetName();
            lastPlayer = playerName;
            IncrementPlayerOccurrence(playerName); // Increment occurrence
            return playerName;
        }
        return "NULL";
    }

    public static string getLastPlayer()
    {
        return lastPlayer;
    }

    public static void InitiatePlayers(int number)
    {
        numberOfPlayers = number;
        players = new Player[number];
    }

    public static void AddPlayer(string name)
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null && i < numberOfPlayers)
            {
                players[i] = new Player(name, 0);
                return;
            }
        }
    }

    private static void IncrementPlayerOccurrence(string playerName)
    {
        Player player = getPlayerWithName(playerName);
        if (player != null)
        {
            player.IncrementOccurrenceCount();
            PrintPlayerOccurrences(); // Print occurrences after increment
        }
    }

    private static void PrintPlayerOccurrences()
    {
        foreach (var player in players)
        {
            if (player != null)
            {
                Debug.Log(player.GetName() + " has been selected " + player.GetOccurrenceCount() + " times.");
            }
        }
    }
}
