using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSelected : MonoBehaviour
{
    [SerializeField]
    GameObject[] autos;

    [SerializeField]
    int cont =0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarAuto();
    }

    public void Siguiente()
    {
        if(cont<1)
        {
            cont += 1;
        }
        
    }

    public void Anterior()
    {
        if(cont>=-1)
        {
            cont -= 1;
        }
       
    }

    void CambiarAuto()
    {
        if(cont ==0)
        {
            autos[0].SetActive(true);
            autos[1].SetActive(false);
            autos[2].SetActive(false);
        }

        if (cont == 1)
        {
            autos[0].SetActive(false);
            autos[1].SetActive(true);
            autos[2].SetActive(false);
        }

        if (cont == -1)
        {
            autos[0].SetActive(false);
            autos[2].SetActive(true);
            autos[1].SetActive(false);
        }

    }
}
