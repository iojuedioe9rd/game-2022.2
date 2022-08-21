using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay.All;

namespace GamePlay.Zombie
{
    public abstract class ZombieBase : IHealthSystem
    {
        public abstract string Name { get; }

        public HealthSystem healthSystem;

        public HealthSystem GetHealthSystem()
        {
            return healthSystem;
        }

        public abstract int health { get;  }

        public abstract float speed { get;  }

        public abstract Color tintColor { get;  }

        public abstract void Setup(Zombie zombie, out int health, out float speed, out Color tintColor);

        
    }
}
