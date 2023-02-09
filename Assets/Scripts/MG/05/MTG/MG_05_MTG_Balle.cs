using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_05_MTG_Balle : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1,0,0);

    public int speed = 3;
    void Update()
    {
        transform.position+=direction*speed*Time.deltaTime;
        if(transform.position.x <= -10 || transform.position.y >= 6){
            Destroy(gameObject);
        }
    }
}
