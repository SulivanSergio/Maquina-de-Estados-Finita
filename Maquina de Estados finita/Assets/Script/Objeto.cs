using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{

    

    void Start()
    {
        
    }

    
    void Update()
    {
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        for (int i = 0; i < Main.instance.mef.Length; i++)
        {
            if (other.gameObject == Main.instance.mef[i].gameObject)
                Main.instance.mef[i].OncollisionEnter(other);
        }
        
    }
    

}
