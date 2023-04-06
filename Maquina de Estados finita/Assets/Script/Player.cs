using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    enum STATE
    {
        SEGUIR
    }

    STATE state = STATE.SEGUIR;
    GameObject gameObject;
    GameObject inimigo;
    float speed = 10;

    public Player(Mesh mesh, Material material, GameObject inimigo)
    {
        gameObject = new GameObject("Player");
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        this.inimigo = inimigo;

    }


    public void Update(float gameTime)
    {
        UpdateState(gameTime);
    }

    private void UpdateState(float gameTime)
    {

        switch(state)
        {
            case STATE.SEGUIR:
                float distancia = Vector3.Distance(gameObject.transform.position, inimigo.transform.position);
                

                if(gameObject.transform.position.x < inimigo.transform.position.x)
                {
                    inimigo.transform.position -= new Vector3(distancia * gameTime, 0, 0);
                }
                if (gameObject.transform.position.x > inimigo.transform.position.x)
                {
                    inimigo.transform.position += new Vector3(distancia * gameTime, 0, 0);
                }
                if (gameObject.transform.position.z < inimigo.transform.position.z)
                {
                    inimigo.transform.position -= new Vector3(0, 0, distancia * gameTime);
                }
                if (gameObject.transform.position.z > inimigo.transform.position.z)
                {
                    inimigo.transform.position += new Vector3(0, 0, distancia * gameTime);
                }

                break;
        }

    }

    public void AtualizaObjeto(GameObject inimigo)
    {
        this.inimigo = inimigo;
    }

}
