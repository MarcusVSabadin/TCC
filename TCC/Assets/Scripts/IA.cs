using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IA : MonoBehaviour
{
    GameObject[] Map;
    StageStatus[] stagesInfo;

    int[][] populacao;
    int tamId;
    [SerializeField] int stageNumberMap;

    public GameObject[] createMap(GameObject[] stages)
    {
        stagesInfo = new StageStatus[stages.Length];
        stagesInfo = setIdToStages(stages);
        
        populacao = createPop(stages.Length);

        ConvertMap(stages,populacao[0]);

    


        return stages;
    }

    StageStatus[] setIdToStages(GameObject[] L_stages)
    {
        string id;
        tamId = System.Convert.ToString (L_stages.Length, 2).Length;


        for (int s=0;s < L_stages.Length; s++){
            stagesInfo[s] = L_stages[s].transform.GetChild(0).gameObject.GetComponent<StageStatus>();
            id = System.Convert.ToString (s, 2);
            while (id.Length < tamId)
            {
                id = string.Concat("0", id);
            }
            int[] idV = new int[tamId];
            
            for(int i = 0; i < tamId ; i++)
            {
                idV[i] = (int)char.GetNumericValue(id[i]);
            }
            stagesInfo[s].identificador = idV;

        }
        
        return stagesInfo;
    }

    int[][] createPop(int stageNumber)
    {
        int[][] pop;
        pop = new int[stageNumber][];
        for (int Chromosome = 0; Chromosome < stageNumber; Chromosome++)
        {
            pop[Chromosome] = new int[tamId*stageNumberMap];

            for(int gene = 0; gene < tamId*stageNumberMap; gene ++)
            {
                pop[Chromosome][gene] = Random.Range(0,2);
            }
        }

        //testes
        for (int Chromosome = 0; Chromosome < stageNumber; Chromosome++)
        {
            for(int gene = 0; gene < tamId*stageNumberMap; gene ++)
            {    
                Debug.Log(pop[Chromosome][gene]);
            }
            Debug.Log("-----------------------------------");
        }

        return pop;
    }

    GameObject[] ConvertMap(GameObject[] L_stages,int[] L_Chromosome)
    { 
        Map = new GameObject[stageNumberMap];
        int nextStagePos = 0;
        int[] aux = new int[tamId];
        for(int gene = 0; gene <= tamId*(stageNumberMap-1) ; gene += tamId)
        {
            for (int i = 0; i < tamId; i++)
            {
                aux[i] = L_Chromosome[gene + i];
            }


            for (int s=0;s < L_stages.Length; s++)
            {
                if (aux.SequenceEqual(stagesInfo[s].identificador))
                {
                    Map[nextStagePos] = L_stages[s];
                    nextStagePos ++;
                }
            }
        }
        return Map;
    }


}
