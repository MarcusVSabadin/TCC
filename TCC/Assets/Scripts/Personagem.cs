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
    Status status_;

    bool podePular,direcaoPersD = true;

    //pulo
    [SerializeField] Transform ObjDetectaChao;
    [SerializeField] LayerMask Chao;
    bool colisorChao;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        status_ = GetComponent<Status>();
    }

    public virtual void Update()
    {
        
        colisorChao = Physics2D.OverlapCircle(ObjDetectaChao.position, 0.05f,Chao); 
        
    }

    public Status status
    {
        get{return status_;}

    }

    public void TomarDano(float danoRecebido)
    {
        
    }

    public void Virar()
    {
        transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);
        direcaoPersD = !direcaoPersD;     
    }

    public void Mover(Vector2 direcao)
    {
        rb.velocity = new Vector2(direcao.x*status.velocidade,rb.velocity.y) ;
    }

    public void Pular()
    {
        if(colisorChao)
            rb.velocity = new Vector2(rb.velocity.x,status.forcaDoPulo);
    }

    public virtual void Ataque()
    {
        
    }

    public virtual void Morrer()
    {
        
    }

}
