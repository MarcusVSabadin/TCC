using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    StageStatus[] stagesInfo;
    string id;

    public GameObject[] createMap(GameObject[] stages)
    {
        stagesInfo = new StageStatus[stages.Length];
        stagesInfo = setIdToStages(stages);
        
        return stages;
    }

    StageStatus[] setIdToStages(GameObject[] L_stages)
    {
        for (int s=0;s < L_stages.Length; s++){
            stagesInfo[s] = L_stages[s].transform.GetChild(0).gameObject.GetComponent<StageStatus>();
            id = System.Convert.ToString (s, 2);
            while (id.Length <=2)
            {
                id = string.Concat("0", id);
            }

            stagesInfo[s].identificador =  new Vector3((float)char.GetNumericValue(id[0]),(float)char.GetNumericValue(id[1]),(float)char.GetNumericValue(id[2]));
            Debug.Log(stagesInfo[s].identificador);

        }
        
        return stagesInfo;
    }
}
