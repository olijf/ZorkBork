using System;

public class Speler
{
    private int score;

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public Speler()
	{
        score = 0;
	}

    public void verhoogScore(int hoeveelheid)
    {
        score = score + hoeveelheid;
    }

    public void verlaagScore(int hoeveelheid)
    {
        int tempScore = score - hoeveelheid;
        if(tempScore >= 0)
        {
            score = tempScore;
        } else
        {
            score = 0;
        }
    }

    public void resetScore()
    {
        score = 0;
    }

}
