using System;
using System.Drawing;

namespace ZorkBork
{

    public class CustomException : Exception
    {
        public CustomException(string message)
           : base(message)
        {
        }
    }

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

        public bool UpdatePositie(int richting, int kaartbereik)
        {
            int nieuweWaarde;

            switch (richting)
            {
                case (int)Richting.Omhoog:
                    nieuweWaarde = Positie.Y + 1;
                    if (nieuweWaarde <= kaartbereik)
                    {
                        Positie = new Point(Positie.X, Positie.Y + 1);
                        return true;
                    }
                    else
                    {
                        throw new CustomException(string.Format("Out of bounds exceptie na omhoog navigeren!"));
                    }
                case (int)Richting.Omlaag:
                    nieuweWaarde = Positie.Y - 1;
                    if (nieuweWaarde >= 0)
                    {
                        Positie = new Point(Positie.X, Positie.Y - 1);
                        return true;
                    }
                    else
                    {
                        throw new CustomException(string.Format("Out of bounds exceptie na omloog navigeren!"));
                    }
                case (int)Richting.Rechts:
                    nieuweWaarde = Positie.X + 1;
                    if (nieuweWaarde <= kaartbereik)
                    {
                        Positie = new Point(Positie.X + 1, Positie.Y);
                        return true;
                    }
                    else
                    {
                        throw new CustomException(string.Format("Out of bounds exceptie na navigeren naar rechts!"));
                    }
                case (int)Richting.Links:
                    nieuweWaarde = Positie.X - 1;
                    if (nieuweWaarde >= 0)
                    {
                        Positie = new Point(Positie.X - 1, Positie.Y);
                        return true;
                    }
                    else
                    {
                        throw new CustomException(string.Format("Out of bounds exceptie na navigeren naar links!"));
                    }
                default:
                    throw new CustomException(string.Format("Onbekende navigatierichting tegengekomen in programmacode!"));
            }
        }

    }
}