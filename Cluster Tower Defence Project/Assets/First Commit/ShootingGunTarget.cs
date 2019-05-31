using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGunTarget : MonoBehaviour
{
    [SerializeField] private float Health = 50.0f; 

    public void DamageTaken(float AmountOfDamageTaken)
    {
        Health -= AmountOfDamageTaken;
        if (Health <= 0)
        {
            HasDied();
        }
    }

    public void HasDied()
    {
        Destroy(gameObject);
    }
}

