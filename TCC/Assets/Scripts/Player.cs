using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personagem
{

    Vector2 inputs_;
    
    public Vector2 inputs
    {
        set {inputs_ = value;}
        get {return inputs_;}
    }

    void Update()
    {
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
