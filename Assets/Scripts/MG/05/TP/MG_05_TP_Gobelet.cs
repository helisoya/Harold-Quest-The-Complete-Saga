using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_05_TP_Gobelet : MonoBehaviour
{
    public bool hasCoin;

    void OnMouseDown(){
        if(MG_05_TP_Manager.instance.canChoose){
            if(hasCoin){
                MG_Starter.instance.LoadNext();
            }else{
               MG_05_TP_Manager.instance.Reset();
            }
        }
    }
}
