using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_06_RGR_Manager : MonoBehaviour
{
    public float maxCooldown;
    float cooldown;

    public float maxTime;
    float time;

    public GameObject prefabGarde;
    public Text txt;


    public static MG_06_RGR_Manager instance;

    void Start()
    {
        instance = this;
        time = maxTime;
        cooldown = maxCooldown;
    }

    public void ResetTimer(){
        time = maxTime;
    }


    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }

        if(time>0){
            time-=Time.deltaTime;
        }else{
            MG_Starter.instance.LoadNext();
            return;
        }

        if(cooldown>0){
            cooldown-=Time.deltaTime;
        }else{
            cooldown = maxCooldown;

            GameObject ob = Instantiate(prefabGarde,transform);
            ob.transform.position = new Vector3(Random.Range(-6,6),Random.Range(-3,3),0);
        }

        txt.text = "Temps restant : "+((int)time + 1).ToString();
    }
}
