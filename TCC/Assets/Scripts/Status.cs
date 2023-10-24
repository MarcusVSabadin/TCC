using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    
    //status
    float time,auxTimeIn, auxVelocidade;
    [SerializeField] float vida_, dano_, velocidade_,forcaDoPulo_,tempoInvu;
    bool boolDanoR;

    public float vida
    {
        set {vida_ = value;}
        get {return vida_;}
    }

    public float dano
    {
        set {dano_ = value;}
        get {return dano_;}
    }

    public float velocidade
    {
        set {velocidade_ = value;}
        get {return velocidade_;}
    }

    public float forcaDoPulo
    {
        set {forcaDoPulo_ = value;}
        get {return forcaDoPulo_;}
    }

    void Start()
    {
        auxVelocidade = velocidade;
    }

    void Update()
    {
        time = Time.time;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
        if(time>=auxTimeIn && boolDanoR)
        {
            velocidade = auxVelocidade;
            boolDanoR = false;
        }
    }
    
    public void TomarDano(float danoRecebido)
    {
        vida = vida - danoRecebido;
        velocidade = 0;
        auxTimeIn = time + tempoInvu;
        boolDanoR = true;
    }
}
