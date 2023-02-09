using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_08_CCC_Balle : MonoBehaviour
{
    public int speed;
    public Vector3 move;

    void Update()
    {
        if(transform.position.x <= -10 || transform.position.x >= 10 || transform.position.y <= -10 || transform.position.y >= 10){
            Destroy(gameObject);
        }

        transform.position += move*speed*Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Player"){
            MG_08_CCC_Manager.instance.Reset();
            Destroy(gameObject);
        }
    }
}
