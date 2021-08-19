using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour
{
    [SerializeField]
    float velocidad = 15f;

    public ParticleSystem turbo;
    public ParticleSystem laser;
    public  GameObject laserM;

    public Transform pivot;

    [SerializeField]
    float timeCont =0.0f;

    [SerializeField]
    float timeContLaser = 0.0f;


    bool activo;
    bool laserActivo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
        ActiveTurbo();
        Shooting();
    }


    public void Movimiento()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward* velocidad * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            turbo.Play();
            activo = true;
            velocidad += 10f;

        }
    }

    public void ActiveTurbo()
    {
        if(activo)
        {
           
            timeCont += 0.1f * Time.deltaTime;
           
        }
        else
        {
            velocidad = 5f;
        }

        if(timeCont > 1f)
        {
            activo = false;
            turbo.Stop();
            timeCont = 0.0f;
        }
        
    }

    public void Shooting()
    {
        if(Input.GetMouseButtonDown(0))
        {
            laser.Play();
            laserActivo = true;
        }

        if(laserActivo)
        {
            timeContLaser += 0.1f * Time.deltaTime;
        }

        if(timeContLaser > 0.5f)
        {
            laserActivo = false;
            laser.Stop();
            timeContLaser = 0.0f;
        }


        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(laserM, pivot.position, transform.rotation);
            
        }

        
    }
}
