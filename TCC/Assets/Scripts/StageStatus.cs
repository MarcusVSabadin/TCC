using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStatus : MonoBehaviour
{
    int[] identificador_;
    [SerializeField] float difcult_;
    

    public float difcult
    {
        get{return difcult_;}
    }

    public int[] identificador
    {
        set
        {   
            identificador_ = new int[value.Length];
            identificador_ = value;
        }
        get{return identificador_;}
    }
}
