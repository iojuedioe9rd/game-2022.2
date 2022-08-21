using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Zombie.Default
{
    public class NormalZombie : ZombieBase
    {
        public override string Name { get { return ""; } }
        public override int health { get  { return 5; }  }
        public override float speed { get => 1f; }
        public override Color tintColor { get => Color.white; }

        public override void Setup(Zombie zombie,
            out int health,
            out float speed, 
            out Color tintColor)
        {
            health = this.health;
            speed = this.speed;
            tintColor = this.tintColor;

            zombie.GetComponent<SpriteRenderer>().color = tintColor;
        }





        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
