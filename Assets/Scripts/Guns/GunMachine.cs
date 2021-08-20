using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunMachine : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] spawnPoint;

    public float shotForce = 3500;
    public float shotRace = 0.1f;

    private float shotRaceTime = 0;

    public bool activeGun = false;

    public Text bulletContTXT;
    public Text cooldownTimeTXT;
    public Text bulletTopTXT;
    public int bulletCont;
    public float cooldownTimer;
    //private string TiempoPrefs = "tiempo";

    private float auxTimer;
    private int auxBullets;

    void Start()
    {
        auxTimer = cooldownTimer;
        auxBullets = bulletCont;
        bulletTopTXT.text = auxBullets.ToString();
        bulletContTXT.text = bulletCont.ToString();
        //cooldownTimeTXT.text = cooldownTimer.ToString();
        cooldownTimeTXT.text = " ";
    }

    void Update()
    {
        //disparo mouse  
        if (Input.GetMouseButton(0))
        {
            activeGun = true;
            if (activeGun == true)
            {
                Shoot();
            }

        }
        //dejar de disparar deja de rotar arma
        if (Input.GetMouseButtonUp(0))
        {
            activeGun = false;
        }

        //Contador de Recarga
        if (bulletCont <= 0)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownTimeTXT.text = cooldownTimer.ToString();
            //Debug.Log("Reloading");
        }
        if (cooldownTimer <= 0)
        {
            cooldownTimer = auxTimer;
            bulletCont = auxBullets;
            cooldownTimeTXT.text = cooldownTimer.ToString();
            cooldownTimeTXT.text = " ";
            bulletContTXT.text = bulletCont.ToString();
            //Debug.Log("Reloaded");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            // rechargeTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (bulletCont > 0)
        {
            GameObject nextBullet;
            if (Time.time > shotRaceTime)
            {
                for (int i = 0; i < spawnPoint.Length; i++)
                {
                    nextBullet = Instantiate(bullet, spawnPoint[i].position, spawnPoint[i].rotation);

                    //Force Bullet
                    nextBullet.GetComponent<Rigidbody>().AddForce(spawnPoint[i].forward * shotForce);
                    shotRaceTime = Time.time + shotRace;
                    Destroy(nextBullet, 2);
                }
                bulletCont -= spawnPoint.Length;
            }
            bulletContTXT.text = bulletCont.ToString();
        }
    }
}
