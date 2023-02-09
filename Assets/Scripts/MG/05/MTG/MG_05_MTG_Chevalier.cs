using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_05_MTG_Chevalier : MonoBehaviour
{
    public GameObject prefabBalle;
    public float maxCooldown;
    float cooldown;

    void Start()
    {  
        cooldown = maxCooldown;
    }

    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }

        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }else{
            cooldown = maxCooldown;
            Instantiate(prefabBalle,transform.position,new Quaternion());
        }

    }
}
