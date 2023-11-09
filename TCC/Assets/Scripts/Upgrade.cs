using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] GameObject telaUpgrades, upgrade;
    GameMaster gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D Collider)
    {
        telaUpgrades.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpgradeVida(GameObject upgrade)
    {
        gm.UpgradeVida();
        Time.timeScale = 1f;
        telaUpgrades.SetActive(false);
        Destroy(upgrade);
    }

    public void UpgradeDano(GameObject upgrade)
    {
        gm.UpgradeDano();
        Time.timeScale = 1f;
        telaUpgrades.SetActive(false);
        Destroy(upgrade);
    }

    public void UpgradeVelocida(GameObject upgrade)
    {
        gm.UpgradeVelocida();
        Time.timeScale = 1f;
        telaUpgrades.SetActive(false);
        Destroy(upgrade);
    }
}
