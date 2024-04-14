using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    GameMaster gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        gm.UpgradeScene().SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpgradeVida()
    {
        gm.UpgradeVida();
        Time.timeScale = 1f;
        Debug.Log('1');
        gm.UpgradeScene().SetActive(false);
        Debug.Log('2');
        Destroy(GameObject.FindWithTag("Upgrade"));
    }

    public void UpgradeDano()
    {
        gm.UpgradeDano();
        Time.timeScale = 1f;
        gm.UpgradeScene().SetActive(false);
        Destroy(GameObject.FindWithTag("Upgrade"));
    }

    public void UpgradeVelocida()
    {
        gm.UpgradeVelocida();
        Time.timeScale = 1f;
        gm.UpgradeScene().SetActive(false);
        Destroy(GameObject.FindWithTag("Upgrade"));
    }
}
