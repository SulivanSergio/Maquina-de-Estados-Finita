using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private const int MAX = 1000;

    public Mesh mesh;
    public Material material;
    MEF[] mef = new MEF[MAX];
    

    void Start()
    {
        
        for(int i = 0; i < mef.Length; i++)
        {
            mef[i] = new MEF(mesh,material,i);
        }

    }

    
    void Update()
    {
        for (int i = 0; i < mef.Length; i++)
        {
            mef[i].Update(Time.deltaTime);
        }
    }
}
