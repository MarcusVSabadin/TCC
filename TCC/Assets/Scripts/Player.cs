using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Personagem
{
    bool utiDirD = true;

    [SerializeField] Image barraDeVida;

    //time
    float timeAtk;

    //atk
    [SerializeField] Transform PosAtk;
    [SerializeField] float alcanceAtk, IntervaloAtk;
    [SerializeField] LayerMask LayerInimigos;

    public override void Start()
    {
        base.Start();
        status.vida = gm.vida;
    }

    public override void Update()
    {
        base.Update();
        if(status.velocidade != 0)
            Movimentacao(); 

        //ataque
        if(Input.GetKeyDown(KeyCode.Z))
            atk();

        barraDeVida.rectTransform.localScale = new Vector3(status.vida/gm.vida,barraDeVida.rectTransform.localScale.y,barraDeVida.rectTransform.localScale.z);
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

        if(Input.GetKeyDown(KeyCode.E))
            gm.UpgradeDano();
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
