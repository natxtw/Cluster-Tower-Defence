using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGun : MonoBehaviour
{
    [SerializeField] private float Damage = 10.0f;
    [SerializeField] private float Range = 200.0f;

    public Camera RaycastChecker;
    //public ParticleSystem Flash;

    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire() 
    {
        //Flash.Play(); 

        RaycastHit HitInfo;

        if (Physics.Raycast(RaycastChecker.transform.position, RaycastChecker.transform.forward, out HitInfo, Range))
        // Var 1 - Shoots out a Ray at the position of the camera. Var 2 - Finds the direction you are facing. 
        // Var 3 - Gathers the info and places it into the hitinfo variable. Var 4 - Inputs the range to prevent endless hitting.
        {
            ShootingGunTarget target = HitInfo.transform.GetComponent<ShootingGunTarget>();
            if (target != null)
            {
                target.DamageTaken(Damage);
            }
            Debug.Log(HitInfo.transform.name); // Displays the object it hits in the console.
        }
    }
}
