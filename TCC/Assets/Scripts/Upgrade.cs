using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] Image telaUpgrades;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        telaUpgrades.setActive(true);
    }
}
