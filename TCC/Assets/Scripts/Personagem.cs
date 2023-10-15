using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Personagem : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animacao;

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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
    }

    public void TomarDano(float danoRecebido)
    {
        vida_=vida_-danoRecebido;
    }

    public void Virar()
    {

    }

    public virtual void Mover()
    {

    }

    public virtual void Ataque()
    {
        
    }

    public virtual void Morrer()
    {
        
    }

}
