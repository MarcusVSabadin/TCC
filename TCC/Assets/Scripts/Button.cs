using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public void changeCene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
