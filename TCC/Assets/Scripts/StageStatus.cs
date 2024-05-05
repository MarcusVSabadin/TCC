using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStatus : MonoBehaviour
{
    float[] identificador_;
    [SerializeField] float difcult_;
    [SerializeField] bool isUpgrade_;
    

    public float difcult
    {
        get{return difcult_;}
    }

    public bool isUpgrade
    {
        get{return isUpgrade_;}
    }

    public float[] identificador
    {
        set
        {   
            identificador_ = new float[value.Length];
            identificador_ = value;
        }
        get{return identificador_;}
    }
}