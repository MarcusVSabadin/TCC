using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class IA : MonoBehaviour
{
    GameObject[] Map;
    StageStatus[] stagesInfo;

    float[][][] populacao; //float[cromosomo][atributo desejado][posisao do atributo (usado para o cromosomo, demais permanecera 0)]
    int tamId, tamCrom;
    [SerializeField] int stageNumberMap, tamPop;


    public GameObject[] createMap(GameObject[] stages)
    {
        stagesInfo = new StageStatus[stages.Length];
        stagesInfo = setIdToStages(stages);
        
        populacao = createPop(tamPop);

        CalcFitness(stages);

        Map = ConvertMap(stages,populacao[0][0]);

    


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

    float[][][] createPop(int stageNumber)
    {

        float[][][] L_table;
        L_table = new float[stageNumber][][];
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
                L_table[ind][0][p] = Random.Range(0,2);
            }
        }


        return L_table;
    }

    //fitness
    float Fit(GameObject[] F_stages,float[] F_Chromosome)
    {
        int upgrades = 0;
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
                    if(!aux.Contains(1))
                    {
                        upgrades ++;
                    }
                    else
                    {
                        difcultMap += stagesInfo[s].difcult -(upgrades*10);
                    }
                }
            }


        }

        return difcultMap/(stageNumberMap-upgrades);
    }

    void CalcFitness(GameObject[] CF_stages)
    {
        for(int ind = 0;ind < populacao.Length; ind++)
        {
            populacao[ind][1][0] = Fit(CF_stages,populacao[ind][0]);
        }

        //teste debug
        for(int i = 0; i < populacao.Length; i++)
        {
            string aux = "";
            aux += "individuo: " + i;
            for(int j = 0; j < populacao[i].Length; j++)
            {
                aux += ", coluna: " + j + " = ";
                
                for(int k = 0; k < populacao[i][j].Length; k++)
                {
                    aux += populacao[i][j][k];
                }
            }
            Debug.Log(aux);
        }
    }



    GameObject[] ConvertMap(GameObject[] L_stages,float[] L_Chromosome)
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
