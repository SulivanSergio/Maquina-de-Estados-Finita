using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoonSharp.Interpreter;
using System.IO;
using System.Text;

public class Main : MonoBehaviour
{
    private const int MAX = 10;

    public Mesh mesh;
    public Material material;
    MEF[] mef = new MEF[MAX];

    Script script = new Script();

    void Start()
    {
        
        for(int i = 0; i < mef.Length; i++)
        {
            mef[i] = new MEF(mesh,material,i);
        }

        //string lua = "";
        //File.WriteAllText(@"D:\Documentos\Ifrj\Setimo periodo\IA\Maquina-de-Estados-Finita\Maquina de Estados finita\Assets\Script\Lua.lua", lua);
        //lua = File.ReadAllText(@"D:\Documentos\Ifrj\Setimo periodo\IA\Maquina-de-Estados-Finita\Maquina de Estados finita\Assets\Script\Lua.lua");
        //Debug.Log(lua);

        //string []dirs =  lua.Split("\n");
        //for(int i = 0; i<dirs.Length; i++)
        //{
        //    Debug.Log(dirs[i]);
        //}

        //script.;
        //DynValue result = script.Call("Start");

    }

    
    void Update()
    {
        for (int i = 0; i < mef.Length; i++)
        {
            mef[i].Update(Time.deltaTime);
        }
    }
}
