using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_05_PDL_Cursor : MonoBehaviour
{  
    public new Rigidbody2D rigidbody2D;

    public float minPos;
    public float maxPos;

    bool targetInside = false;  

    public int speed; 

    public float maxPoints;
    float point = 0;

    public Image imgFill;

    Vector2 move;

    void Start(){
        move = transform.position;
    }

    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }

        if(targetInside){
            point = Mathf.Clamp(point+Time.deltaTime,0,maxPoints);
        }else{
            point = Mathf.Clamp(point-Time.deltaTime,0,maxPoints);
        }
        imgFill.fillAmount = point/maxPoints;

        if(point>=maxPoints){
            MG_Starter.instance.LoadNext();
            return;
        }

       
        if(Input.GetMouseButton(0)){
            move.y = Mathf.Clamp(move.y + speed*Time.deltaTime,minPos,maxPos);
        }else{
            move.y = Mathf.Clamp(move.y - speed*Time.deltaTime,minPos,maxPos);
        }
        rigidbody2D.MovePosition(move);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Player"){
            targetInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.tag=="Player"){
            targetInside = false;
        }
    }
}
