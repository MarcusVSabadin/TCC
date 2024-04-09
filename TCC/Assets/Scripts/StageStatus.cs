using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStatus : MonoBehaviour
{
    Vector3 identificador_;
    [SerializeField] float difcult_;
    

    public float difcult
    {
        get{return difcult_;}
    }

    public Vector3 identificador
    {
        set{identificador_ = value;}
        get{return identificador_;}
    }
}
