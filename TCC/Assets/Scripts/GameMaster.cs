using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    Player player;
    IA IAmaps;


    [SerializeField] float[] vida_,velocidade_,dano_;

    int vidaNivel,velocidadeNivel,danoNivel;

    [SerializeField] GameObject[] stages;
    GameObject stageAtual;
    Transform StagePosition;
    GameObject[] Map;

    [SerializeField] string sceneGameOver;

    [SerializeField] GameObject telaUpgrades;

    void Awake()
    {
        StagePosition = this.transform;
        StagePosition.position = new Vector3 (0.0f,0.0f,0.0f);
        IAmaps = GetComponent<IA>();
        Map = IAmaps.createMap(stages);

        stageAtual = Instantiate(Map[0],StagePosition);
        
    }

    void Start()
    {
        vidaNivel = 0;
        velocidadeNivel = 0;
        danoNivel = 0;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player") == null)
        {
            Debug.Log("teset");
            SceneManager.LoadScene(sceneGameOver);
        }
    }

    public float vida
    {
        get{return vida_[vidaNivel];}
    }
    
    public float velocidade
    {
        get{return velocidade_[velocidadeNivel];}
    }

    public float dano
    {
        get{return dano_[danoNivel];}
    }

    public void UpgradeVida()
    {
        if(vidaNivel<vida_.Length-1)
        {
            vidaNivel += 1;
            float aumentoVida = vida_[vidaNivel] - vida_[vidaNivel-1];
            player.status.UpgradeVida(aumentoVida);
        }    
    }
    
    public void UpgradeVelocida()
    {
        if(velocidadeNivel<velocidade_.Length-1)
        {
            velocidadeNivel += 1;
            player.status.UpgradeVelocida();
        }
    }

    public void UpgradeDano()
    {
        if(danoNivel<dano_.Length-1)
        {
            danoNivel += 1;
            player.status.UpgradeDano();
        }
    }

    public void changeStage()
    {
        Destroy(stageAtual);
        stageAtual = Instantiate(stages[Random.Range(0,stages.Length)],StagePosition);
    }

    public GameObject UpgradeScene()
    {
        return telaUpgrades;
    }
}
