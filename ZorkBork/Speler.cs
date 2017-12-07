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

        private Point positie;

        public Point Positie
        {
            get { return positie; }
            set { positie = value; }
        }


        public Speler()
        {
            score = 0;
            positie = new Point(0, 0);
        }

        public void verhoogScore(int hoeveelheid)
        {
            score = score + hoeveelheid;
        }

        public void verlaagScore(int hoeveelheid)
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

        public void resetScore()
        {
            score = 0;
        }

        public void UpdatePositie(int richting)
        {
            switch (richting)
            {
                case 0:
                    Positie = new Point(Positie.X, Positie.Y + 1);
                    break;
                case 1:
                    Positie = new Point(Positie.X, Positie.Y - 1);
                    break;
                case 2:
                    Positie = new Point(Positie.X + 1, Positie.Y);
                    break;
                case 3:
                    Positie = new Point(Positie.X - 1, Positie.Y);
                    break;
                default:
                    break;
            }
        }

    }
}