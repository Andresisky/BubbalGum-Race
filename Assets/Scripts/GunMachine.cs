using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMachine : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce=1500;
    public float shotRace=0.5f;

    private float shotRaceTime = 0;

    public bool activeGun = false;
    void Start()
    {
        
    }

    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            activeGun = true;
            if (activeGun == true)
            {
                Shoot();
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeGun = false;
        }

    }

    public void Shoot()
    {
        if (Time.time > shotRaceTime)
        {
            GameObject nexBullet;
            nexBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            //Force Bullet
            nexBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            shotRaceTime = Time.time + shotRace;

            Destroy(nexBullet, 2);
        }
        //activeGun = false;
    }
}
