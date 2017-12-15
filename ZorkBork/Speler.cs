using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ZorkBork
{
    [XmlType]
    public class Speler
    {

        private int _score;

        [XmlElement]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        private int _health;

        [XmlElement]
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        
        private List<string> _sleutels;
        
        [XmlElement]
        public List<string> Sleutels
        {
            get { return _sleutels; }
            set { _sleutels = value; }
        }
        
        public Speler()
        {
            Health = 100;
            Score = 0;
            Sleutels = new List<string>();
        }

        public void VerhoogOfVerlaagScore(int hoeveelheid)
        {
            int nieuweScore = Score + hoeveelheid;
            if(nieuweScore < 0)
            {
                Score = 0;
            } else
            {
                Score = nieuweScore;
            }
        }

        public void VerhoogOfVerlaagHealth(int hoeveelheid)
        {
            int nieuweHealth = Health + hoeveelheid;
            if(nieuweHealth < 0)
            {
                Health = 0;
            } else if(nieuweHealth > 100)
            {
                Health = 100;
            } else
            {
                Health = nieuweHealth;
            }
        }

        public void VoegSleutelToe(string sleutel)
        {
            Sleutels.Add(sleutel);
        }

        public void ResetSpeler()
        {
            Score = 0;
            Health = 100;
            Sleutels.Clear();
        }

    }
}