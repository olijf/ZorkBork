using System;
using System.Drawing;

namespace ZorkBork
{
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

        public void VerhoogScore(int hoeveelheid)
        {
            score = score + hoeveelheid;
        }

        public void VerlaagScore(int hoeveelheid)
        {
            int tempScore = score - hoeveelheid;
            if (tempScore >= 0)
            {
                score = tempScore;
            }
            else
            {
                score = 0;
            }
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}