using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : Personagem
{
    GameObject player;
    float ultimaVelocidade;
    
    public override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
    } 

    public override void Update()
    {
        base.Update();

        if(player.transform.position.x < transform.position.x)
            Mover(new Vector2 (-1.0f,0.0f));
        else
            Mover(new Vector2 (1.0f,0.0f));

        if(ultimaVelocidade != rb.velocity.x && ultimaVelocidade != 0.0f)
            Virar();

        ultimaVelocidade = rb.velocity.x;
    }
}
