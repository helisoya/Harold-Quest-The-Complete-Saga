using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_08_CCC_Player : MonoBehaviour
{

    public int speed;

    public Rigidbody2D rb;

    Vector2 movement;


    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position+movement*speed*Time.fixedDeltaTime);
    }

}
