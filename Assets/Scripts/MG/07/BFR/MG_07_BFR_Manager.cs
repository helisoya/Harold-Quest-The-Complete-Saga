using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_07_BFR_Manager : MonoBehaviour
{
    public float forcePlayer;
    public float forceRamos;

    public float max;
    float current = 0;
    public Transform hands;


    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            current = Mathf.Clamp(current-Time.deltaTime*forcePlayer,-max,max);
        }
        current = Mathf.Clamp(current+Time.deltaTime * forceRamos,-max,max);


        if(current <= -max+0.25){
            MG_Starter.instance.LoadNext();
        }

        hands.position = new Vector3(0,current,0);
    }
}
