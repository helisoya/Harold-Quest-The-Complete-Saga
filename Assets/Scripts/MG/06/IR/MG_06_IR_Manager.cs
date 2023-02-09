using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_06_IR_Manager : MonoBehaviour
{
    public int howManyTimes;

    public GameObject[] gardes;

    int current;

    void Start(){
        NewChoice();
    }

    void NewChoice(){
        current = Random.Range(0,3);
        for(int i = 0;i<gardes.Length;i++){
            if(i==current){
                gardes[i].SetActive(false);
            }else{
                gardes[i].SetActive(true);
            }
        } 
    }

    public void Choice(int val){
        if(val==current){
            howManyTimes--;
            if(howManyTimes==0){
                MG_Starter.instance.LoadNext();
                return;
            }
            NewChoice();
        }
    }
}
