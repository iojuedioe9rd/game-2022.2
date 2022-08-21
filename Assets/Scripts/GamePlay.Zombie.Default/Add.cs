using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Zombie.Default
{
    public class Add : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ZombieAPIHelpers.instance.AddZombie(1, "NormalZombie", new NormalZombie());
        }

        
    }
}
