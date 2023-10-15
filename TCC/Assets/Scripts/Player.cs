using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personagem
{
    bool utiDirD = true;
    public override void Start()
    {
        base.Start();
        velocidade = 5;

    }
    
    void Update()
    {
        Mover(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        if(Input.GetKeyDown(KeyCode.A) && utiDirD)
        {
            Virar();
            utiDirD = !utiDirD;
        }
        else if(Input.GetKeyDown(KeyCode.D) && !utiDirD)
        {
            Virar();
            utiDirD = !utiDirD;
        }
    }
}
