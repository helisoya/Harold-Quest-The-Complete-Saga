using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_07_TSE_Manager : MonoBehaviour
{
    public string correct = "chocolat";

    public void CheckIfSolution(string solution){
        if(solution.ToLower()==correct.ToLower()){
            MG_Starter.instance.LoadNext();
        }
    }
}
