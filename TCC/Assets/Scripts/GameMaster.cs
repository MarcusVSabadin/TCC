using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] float[] vida_,velocidade_,dano_;

    int vidaNivel,velocidadeNivel,danoNivel;

    void Start()
    {
        vidaNivel = 0;
        velocidadeNivel = 0;
        danoNivel = 0;
    }

    public float vida
    {
        get{return vida_[vidaNivel];}
    }
    
    public float velocidade
    {
        get{return velocidade_[velocidadeNivel];}
    }

    public float dano
    {
        get{return dano_[danoNivel];}
    }

    public void UpgradeVida()
    {
        vidaNivel += 1;
    }
    
    public void UpgradeVelocida()
    {
        velocidadeNivel += 1;
    }

    public void UpgradeDano()
    {
        danoNivel += 1;
    }
}
