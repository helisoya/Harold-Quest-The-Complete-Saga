using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_05_PDL_Target : MonoBehaviour
{
    public float minPos;
    public float maxPos;
    public int speed;
    Vector3 targetPos;

    void Start(){
        targetPos = transform.position;
    }

    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }
        if(transform.position != targetPos){
            transform.position = Vector3.Lerp(transform.position,targetPos,Time.deltaTime*speed);
        }else{
            targetPos.y = Random.Range(minPos,maxPos);
        }
    }
}
