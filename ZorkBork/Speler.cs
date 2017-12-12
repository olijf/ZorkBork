using System;
using System.Drawing;

namespace ZorkBork
{
    public class Speler
    {

        private static Speler instance;
        public static Speler Instance
        {
            get
            {
                if (instance != null)
                {
                    instance = new Speler();
                }
                return instance;
            }
        }
        private Speler()
        {

            score = 0;
        }
        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
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