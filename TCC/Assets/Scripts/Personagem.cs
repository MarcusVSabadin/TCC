using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Personagem : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animacao;
    Transform transform;

    //status
    float vida_, dano_, velocidade_;
    bool direcaoPersD = true;

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

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    public void TomarDano(float danoRecebido)
    {
        vida_=vida_-danoRecebido;
    }

    public void Virar()
    {
        transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);
        direcaoPersD = !direcaoPersD;     
    }

    public virtual void Mover(Vector2 direcao)
    {
        rb.velocity = new Vector2(direcao.x*velocidade,rb.velocity.y) ;
    }

    public virtual void Ataque()
    {
        
    }

    public virtual void Morrer()
    {
        
    }

}