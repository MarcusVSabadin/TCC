using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameMaster Gm;
    GameObject player, inimigo;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Gm = GameObject.FindWithTag("GameController").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.tag);
        inimigo = GameObject.FindWithTag("Inimigo");
        if(collider.tag == player.tag && null == inimigo)
        {
            Debug.Log("teste");
            player.transform.position = new Vector3 ((player.transform.position.x-Mathf.Sign(player.transform.position.x)*0.5f)*-1,player.transform.position.y,player.transform.position.z);
            Gm.changeStage(); 
        }
    }
}
