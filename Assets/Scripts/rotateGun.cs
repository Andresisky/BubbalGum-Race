using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{
    [SerializeField]
    private GameObject gearX;

    [SerializeField]
    private float angle;

    public GunMachine Gun;
     void FixedUpdate()
    {
       
       
    }
    void Update()
    {
        if (Gun.activeGun == true)
        {
            gearX.transform.Rotate(angle * Vector3.forward, Space.Self);
        }
    }
}
