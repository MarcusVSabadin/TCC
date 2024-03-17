using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Personagem : MonoBehaviour
{
    Rigidbody2D rb_;
    Animator animacao_;
    Transform transform;
    Status status_;
    GameMaster gm_;

    bool podePular,direcaoPersD = true;
    float timeMaster_;

    //pulo
    [SerializeField] Transform ObjDetectaChao;
    [SerializeField] LayerMask Chao;
    bool colisorChao;

    public Rigidbody2D rb
    {
        get{return rb_;}
    }

    public Animator animacao
    {
        get{return animacao_;}
    }

    public Status status
    {
        get{return status_;}

    }
    public GameMaster gm
    {
        get{return gm_;}
    }

    public float timeMaster
    {
        get{return timeMaster_;}
    }

    public LayerMask layerChao
    {
        get{return Chao;}
    }

    public bool noChao
    {
        get{return colisorChao;}
    }

    public virtual void Start()
    {
        rb_ = GetComponent<Rigidbody2D>();
        animacao_ = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        status_ = GetComponent<Status>();
        gm_ = GameObject.FindWithTag("GameController").GetComponent<GameMaster>();
    }

    public virtual void Update()
    {
        timeMaster_ = Time.time;
        colisorChao = Physics2D.OverlapCircle(ObjDetectaChao.position, 0.05f,Chao); 
        
    }

    public void Virar()
    {
        transform.localScale = new Vector2(transform.localScale.x*-1,transform.localScale.y);
        direcaoPersD = !direcaoPersD;     
    }

    public void Mover(Vector2 direcao)
    {
        rb_.velocity = new Vector2(direcao.x*status.velocidade,rb_.velocity.y) ;
    }

    public void Pular()
    {
        if(colisorChao)
            rb_.velocity = new Vector2(rb_.velocity.x,status.forcaDoPulo);
    }

    public virtual void Ataque()
    {
        
    }

    public virtual void Morrer()
    {
        
    }

}
