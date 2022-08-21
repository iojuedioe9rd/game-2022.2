using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.All
{
    public class HealthSystem
    {
        private int health;
        public int maxHealth;
        public int GetAndSetHealth
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }

        public HealthSystem(int health)
        {
            this.health = health;
            maxHealth = health;
        }


        public float GetHealthPercent()
        {
            return (float)health / maxHealth;
        }

        public void Damage(int v)
        {
            GetAndSetHealth -= v;
            if(health < 0)
            {
                GetAndSetHealth = 0;
            }
        }

        public void Heal(int v)
        {
            GetAndSetHealth += v;
            if(health > maxHealth)
            {
                GetAndSetHealth = maxHealth;
            }
        }
    }
}
