using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour
{
    public ArcadeCar carControl;
   [ SerializeField]
   float constDeAumentoVelocidad;

    public ParticleSystem turbo;
    //public ParticleSystem laser;
    public  GameObject laser;

    public Transform pivot;

    [SerializeField]
    float timeCont =0.0f;

    [SerializeField]
    float timeContLaser = 0.0f;


    bool activo;
    bool laserActivo;

    AnimationCurve aux;
    public float turboLimit;

    void Start()
    {
        aux = carControl.accelerationCurve;
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SoundSystem.instance.PlayTurbo();
            turbo.Play();
            activo = true;
            carControl.accelerationCurve = AnimationCurve.Linear(0.0f, 0.0f, 0.09f, turboLimit);
            //carControl.accelerationCurve = aux;
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
            //carControl.accelerationCurve = AnimationCurve.Linear(0.0f, 0.0f, 5.0f, 100.0f);
        }

        if(timeCont > 0.2f)
        {
            activo = false;
            turbo.Stop();
            timeCont = 0.0f;
            //carControl.accelerationCurve = AnimationCurve.Linear(0.0f, 0.0f, 5.0f, 100.0f);
            carControl.accelerationCurve = aux;
        }
        
    }

    public void Shooting()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    laser.Play();
        //    laserActivo = true;
        //}

        //if(laserActivo)
        //{
        //    timeContLaser += 0.1f * Time.deltaTime;
        //}

        //if(timeContLaser > 0.5f)
        //{
        //    laserActivo = false;
        //    laser.Stop();
        //    timeContLaser = 0.0f;
        //}


        if(Input.GetMouseButtonDown(1))
        {
            SoundSystem.instance.PlayCanon();
            Instantiate(laser, pivot.position, transform.rotation);
            
        }

        
    }
}
