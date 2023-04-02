using MoonSharp.Interpreter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class MEF
{
    public enum STATE {
        XP,
        XN,
        YP,
        YN,
        ZP,
        ZN
    
    }

    

    public GameObject gameObject;
    private STATE state = STATE.YP;

    private float speed = 5f;
    private int tempo = 0;
    private float MAX = 2;

    private Color[] color = new Color[5];

    Script script = new Script();
    DynValue res;
    string lua = "";

    
    

    public MEF(Mesh mesh, Material material, int id)
    {
        gameObject = new GameObject("Bola" + id);
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        gameObject.tag = "Bola";
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.AddComponent<Objeto>();

        color[0] = Color.red;
        color[1] = Color.blue;
        color[2] = Color.green;
        color[3] = Color.gray;
        color[4] = Color.yellow;

        gameObject.GetComponent<MeshRenderer>().material.color = color[UnityEngine.Random.Range(0,5)];


        LoadLua();
        DeclaraFunc();

        

    }

    private void LoadLua()
    {
        lua = File.ReadAllText(@"D:\Documentos\Ifrj\Setimo periodo\IA\Maquina-de-Estados-Finita\Maquina de Estados finita\Assets\Script\Lua.lua");
        script.DoString(lua);
    }
    private void DeclaraFunc()
    {
        script.Globals["UpdateState"] = (Func<float, float>)UpdateState;

    }

    public void Update(float gameTime)
    {
        tempo++;
        //UpdateState(gameTime);
        if(tempo >= MAX)
        {
            tempo = 0;
            ChangeState();
        }
        


        LoadLua();
        res = script.Call(script.Globals.Get("Update"),gameTime);



    }

    public float UpdateState(float gameTime)
    {
        switch(state)
        {

            case STATE.XP:
                gameObject.transform.position += new Vector3(speed * gameTime, 0,0);
                break;
            case STATE.XN:
                gameObject.transform.position -= new Vector3(speed * gameTime, 0, 0);
                break;
            case STATE.YP:
                gameObject.transform.position += new Vector3(0, speed * gameTime, 0);
                break;
            case STATE.YN:
                gameObject.transform.position -= new Vector3(0, speed * gameTime, 0);
                break;
            case STATE.ZP:
                gameObject.transform.position += new Vector3(0, 0, speed * gameTime);
                break;
            case STATE.ZN:
                gameObject.transform.position -= new Vector3(0, 0, speed * gameTime);
                break;

        }

        return 0;
    }

    public void ChangeState()
    {
        int r = UnityEngine.Random.Range(0, 5);
        switch (state)
        {
            case STATE.XP:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;
            case STATE.XN:
                switch (r)
                {
                    case 0:
                        state = STATE.XP;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;
                }



                break;

            case STATE.YP:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.XP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;
            case STATE.YN:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.XP;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;

            case STATE.ZP:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.XP;
                        break;
                    case 4:
                        state = STATE.ZN;
                        break;


                }
                break;
            case STATE.ZN:
                switch (r)
                {
                    case 0:
                        state = STATE.XN;
                        break;
                    case 1:
                        state = STATE.YP;
                        break;
                    case 2:
                        state = STATE.YN;
                        break;
                    case 3:
                        state = STATE.ZP;
                        break;
                    case 4:
                        state = STATE.XP;
                        break;


                }
                break;


        }
    }

    public void OncollisionEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Bola")
        {
            collider.gameObject.SetActive(false);
        }

    }
    
    

}
