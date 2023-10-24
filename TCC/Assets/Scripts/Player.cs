using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personagem
{
    bool utiDirD = true;

    //time
    float timeAtk;

    //atk
    [SerializeField] Transform PosAtk;
    [SerializeField] float alcanceAtk, IntervaloAtk;
    [SerializeField] LayerMask LayerInimigos;

    public override void Update()
    {
        base.Update();
        if(status.velocidade != 0)
            Movimentacao(); 

        //ataque
        if(Input.GetKeyDown(KeyCode.Z))
            atk();
    }

    void Movimentacao()
    {
        Mover(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        animacao.SetFloat("velocidade",Mathf.Abs(rb.velocity.x));

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

    void atk()
    {
        if(timeMaster >= timeAtk)
        {
            timeAtk = timeMaster + IntervaloAtk;
            animacao.SetTrigger("atk");
            Collider2D[] Inimigos = Physics2D.OverlapCircleAll(PosAtk.position, alcanceAtk, LayerInimigos);
            foreach(Collider2D inimigo in Inimigos)
            {
                if(inimigo.gameObject.tag == "Inimigo")
                {
                    inimigo.gameObject.GetComponent<Status>().TomarDano(status.dano);
                    Debug.Log("hit");
                    break;
                }
            }

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(PosAtk.position, alcanceAtk);
    }
}
