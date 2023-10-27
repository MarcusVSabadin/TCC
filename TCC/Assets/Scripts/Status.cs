using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    GameMaster gm;

    //status
    float time,auxTimeIn, auxVelocidade;
    [SerializeField] float vida_, dano_, velocidade_,forcaDoPulo_,tempoInvu;
    bool podeMover;

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
        gm = GameObject.FindWithTag("GameController").GetComponent<GameMaster>();
        auxVelocidade = velocidade;
    }

    void Update()
    {
        time = Time.time;
        if(this.vida <= 0)
        {
            Destroy(gameObject);
        }
        if(time>=auxTimeIn && podeMover)
        {
            velocidade = auxVelocidade;
            podeMover = false;
        }

        
    }
    
    public void TomarDano(float danoRecebido)
    {
        this.vida -= danoRecebido;
        hit();
    }

    public void hit()
    {
        velocidade = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
        auxTimeIn = time + tempoInvu;
        podeMover = true;
    }

    public void UpgradeVida(float aumentoVida)
    {
        vida += aumentoVida;
    }

    public void UpgradeVelocida()
    {
        velocidade = gm.velocidade;
        auxVelocidade = velocidade;
    }

    public void UpgradeDano()
    {
        dano = gm.dano;
    }
}
