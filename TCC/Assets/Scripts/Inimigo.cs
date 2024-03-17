using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : Personagem
{
    float timeAposDano, auxVelocidade;
    GameObject player;
    float ultimaVelocidade,direcao;

    
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
        if(player.transform.position.x < transform.position.x)
        {
            direcao = -1.0f;
            Mover(new Vector2 (direcao,0.0f));
        }
        else
        {
            direcao = 1.0f;
            Mover(new Vector2 (direcao,0.0f));
        }

        if(ultimaVelocidade != direcao && (rb.velocity.x >= 0.3f || rb.velocity.x <= -0.3f))
            Virar();

        ultimaVelocidade = direcao;
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "DetecInimigos")
        {
            player.GetComponent<Status>().TomarDano(status.dano);
            player.GetComponent<Rigidbody2D>().velocity = new Vector2 (direcao*3,player.GetComponent<Rigidbody2D>().velocity.y);
            status.hit();
        }
    }
}
