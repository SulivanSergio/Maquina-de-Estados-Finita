using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using System.IO;
using System.Text;
using System;

public class Main : MonoBehaviour
{
    private const int MAX = 10;

    public Mesh mesh;
    public Material material;
    MEF[] mef = new MEF[MAX];

    
    

    void Start()
    {
        
        for(int i = 0; i < mef.Length; i++)
        {
            mef[i] = new MEF(mesh,material,i);
        }

        
        //File.WriteAllText(@"D:\Documentos\Ifrj\Setimo periodo\IA\Maquina-de-Estados-Finita\Maquina de Estados finita\Assets\Script\Lua.lua", lua);
        
        

        
    }
    

    void Update()
    {
        for (int i = 0; i < mef.Length; i++)
        {
            mef[i].Update(Time.deltaTime);
        }
        

    }
    

}
