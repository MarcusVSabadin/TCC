using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    
    //status
    [SerializeField] float vida_, dano_, velocidade_,forcaDoPulo_;

    public float vida
    {
        set {vida_ = value;}
        get {return vida_;}
    }

    public float dano
    {
        set {dano_ = value;}
        get {return dano_;}
    }

    public float velocidade
    {
        set {velocidade_ = value;}
        get {return velocidade_;}
    }

    public float forcaDoPulo
    {
        set {forcaDoPulo_ = value;}
        get {return forcaDoPulo_;}
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
