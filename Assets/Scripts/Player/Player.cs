using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.PlayerControl;
using GamePlay.All;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour, IHealthSystem
{
    public HealthSystem healthSystem;

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    private void Awake()
    {
        healthSystem = new HealthSystem(10);
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
