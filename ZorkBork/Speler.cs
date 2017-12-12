using System.Collections.Generic;

namespace ZorkBork
{
    public class Speler
    {

        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private int _health;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        private List<string> _sleutels;

        public List<string> Sleutels
        {
            get { return _sleutels; }
            set { _sleutels = value; }
        }
        
        public Speler()
        {
            _health = 100;
            _score = 0;
            _sleutels = new List<string>();
        }

        public void VerhoogOfVerlaagScore(int hoeveelheid)
        {
            int nieuweScore = _score + hoeveelheid;
            if(nieuweScore < 0)
            {
                _score = 0;
            } else
            {
                _score = nieuweScore;
            }
        }

        public void VerhoogOfVerlaagHealth(int hoeveelheid)
        {
            int nieuweHealth = _health + hoeveelheid;
            if(nieuweHealth < 0)
            {
                _health = 0;
            } else if(nieuweHealth > 100)
            {
                _health = 100;
            } else
            {
                _health = nieuweHealth;
            }
        }

        public void VoegSleutelToe(string sleutel)
        {
            _sleutels.Add(sleutel);
        }

        public void ResetSpeler()
        {
            _score = 0;
            _health = 100;
            _sleutels.Clear();
        }

    }
}