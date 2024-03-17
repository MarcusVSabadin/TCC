using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : Personagem
{
    float timeAposDano, auxVelocidade;
    GameObject player;
    float ultimaVelocidade,direcao;

    [SerializeField] Transform DetecBurraco,DetecWall;
    [SerializeField] LayerMask layerWall;
    [SerializeField] Vector2 sizeDetecB;
    bool mudarDirecao;
    
    public override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        auxVelocidade = this.status.velocidade;
        direcao = 1.0f;
    } 

    void FixedUpdate()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        mudarDirecao = (!Physics2D.OverlapBox(DetecBurraco.position,sizeDetecB,0f,base.layerChao) || Physics2D.OverlapBox(DetecWall.position,sizeDetecB,0f,layerWall));
        if(mudarDirecao && noChao)
        {
            virando();    
        }
        Mover(new Vector2 (direcao,0.0f));
    }

    void virando()
    {
        direcao *= -1f;
        Virar();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "DetecInimigos")
        {
            player.GetComponent<Status>().TomarDano(status.dano);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2 (direcao*3,player.GetComponent<Rigidbody2D>().velocity.y);
            status.hit();
            virando();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(DetecBurraco.position, sizeDetecB);
        Gizmos.DrawWireCube(DetecWall.position, sizeDetecB);
    }
}
