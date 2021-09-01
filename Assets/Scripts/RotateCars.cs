using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCars : MonoBehaviour
{
    [SerializeField]
    float velocidadRot =5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * velocidadRot);
    }
}
