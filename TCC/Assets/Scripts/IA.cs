using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IA : MonoBehaviour
{
    GameObject[] Map;
    StageStatus[] stagesInfo;

    int[][] populacao;
    float[][][] table;
    int tamId, tamCrom;
    [SerializeField] int stageNumberMap;


    public GameObject[] createMap(GameObject[] stages)
    {
        stagesInfo = new StageStatus[stages.Length];
        stagesInfo = setIdToStages(stages);
        
        populacao = createPop(stages.Length);

        table = CalcFitness(stages);

        Map = ConvertMap(stages,populacao[0]);

    


        return Map;
    }

    StageStatus[] setIdToStages(GameObject[] SIS_stages)
    {
        string id;
        tamId = System.Convert.ToString(SIS_stages.Length, 2).Length;
        tamCrom = tamId*stageNumberMap;


        for (int s=0;s < SIS_stages.Length; s++){
            stagesInfo[s] = SIS_stages[s].transform.GetChild(0).gameObject.GetComponent<StageStatus>();
            id = System.Convert.ToString (s, 2);
            while (id.Length < tamId)
            {
                id = string.Concat("0", id);
            }
            float[] idV = new float[tamId];
            
            for(int i = 0; i < tamId ; i++)
            {
                idV[i] = (float)char.GetNumericValue(id[i]);
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
            pop[Chromosome] = new int[tamCrom];

            for(int gene = 0; gene < tamCrom; gene ++)
            {
                pop[Chromosome][gene] = Random.Range(0,2);
            }
        }

        //testes
        for (int Chromosome = 0; Chromosome < stageNumber; Chromosome++)
        {
            for(int gene = 0; gene < tamCrom; gene ++)
            {    
                Debug.Log(pop[Chromosome][gene]);
            }
            Debug.Log("-----------------------------------");
        }

        return pop;
    }

    //fitness
    float Fit(GameObject[] F_stages,float[] F_Chromosome)
    {
        float difcultMap = 0;
        float[] aux = new float[tamId];
        for(int gene = 0; gene <= tamId*(stageNumberMap-1) ; gene += tamId)
        {
            for (int i = 0; i < tamId; i++)
            {
                aux[i] = F_Chromosome[gene + i];
            }

            for (int s=0;s < F_stages.Length; s++)
            {
                if (aux.SequenceEqual(stagesInfo[s].identificador))
                {
                    difcultMap += stagesInfo[s].difcult;

                }
            }


        }

        return difcultMap/stageNumberMap;
    }

    float[][][] CalcFitness(GameObject[] CF_stages)
    {
        float[][][] L_table;
        L_table = new float[populacao.Length][][];
        for(int ind = 0;ind < L_table.Length; ind++)
        {
            L_table[ind] = new float[4][];
            L_table[ind][0] = new float[tamCrom];
            

            //setando array
            for(int t = 1;t < 4;t++)
            {
                L_table[ind][t] = new float[1];
            }

            //adicionando populacao a tabela
            for (int p = 0; p < tamCrom; p++)
            {
                L_table[ind][0][p] = populacao[ind][p];
            }

            L_table[ind][1][0] = Fit(CF_stages,L_table[ind][0]);
        }

        //teste debug
        for(int i = 0; i < L_table.Length; i++)
        {
            string aux = "";
            aux += "individuo: " + i;
            for(int j = 0; j < L_table[i].Length; j++)
            {
                aux += ", coluna: " + j + " = ";
                
                for(int k = 0; k < L_table[i][j].Length; k++)
                {
                    aux += L_table[i][j][k];
                }
            }
            Debug.Log(aux);
        }
        return L_table;
    }



    GameObject[] ConvertMap(GameObject[] L_stages,int[] L_Chromosome)
    { 
        GameObject[] L_Map = new GameObject[stageNumberMap];
        int nextStagePos = 0;
        float[] aux = new float[tamId];
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
                    L_Map[nextStagePos] = L_stages[s];
                    nextStagePos ++;
                }
            }
        }
        return L_Map;
    }


}
