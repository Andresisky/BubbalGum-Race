using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunMachine : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce = 3500;
    public float shotRace = 0.1f;

    private float shotRaceTime = 0;

    public bool activeGun = false;

    public Text ContadorBalas;
    public Text recargaTimer;
    public int contBullet;
    private float rechargeTimer;
    private string TiempoPrefs = "tiempo";
    void Start()
    {
        ContadorBalas.text = "100";
        recargaTimer.text = "60";
        contBullet = 100;

        rechargeTimer = 60;
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
        if (contBullet == 0)
        {
            rechargeTimer -= Time.deltaTime;
            recargaTimer.text = rechargeTimer.ToString();
            //Debug.Log(rechargeTimer);
        }
        if (rechargeTimer <= 0)
        {
            rechargeTimer = 60;
            recargaTimer.text = rechargeTimer.ToString();
            contBullet = 100;
            ContadorBalas.text = contBullet.ToString();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            // rechargeTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (contBullet > 0)
        {
            if (Time.time > shotRaceTime)
            {

                GameObject nexBullet;
                nexBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                //Force Bullet
                nexBullet.GetComponent<Rigidbody>().AddForce(-spawnPoint.right * shotForce);
                shotRaceTime = Time.time + shotRace;
                contBullet -= 1;
                Destroy(nexBullet, 2);
            }
            ContadorBalas.text = contBullet.ToString();
        }
    }
}
