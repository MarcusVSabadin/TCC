using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personagem
{
    bool utiDirD = true;
    

    public override void Start()
    {
        base.Start();
        status.velocidade = 5;
        status.forcaDoPulo = 5;
    }
    
    public override void Update()
    {
        base.Update();
        Movimentacao(); 
    }

    void Movimentacao()
    {
        Mover(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        if(Input.GetKeyDown(KeyCode.LeftArrow) && utiDirD)
        {
            Virar();
            utiDirD = !utiDirD;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && !utiDirD)
        {
            Virar();
            utiDirD = !utiDirD;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
    }
}
