using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_06_TEC_Garde : MonoBehaviour
{
    public GameObject prefabTir;

    public float cooldown;

    float maxCooldown;

    public int speed;


    void Start()
    {
        maxCooldown = cooldown;
        StartCoroutine(Garde());
    }
    IEnumerator Garde(){
        if(!MG_Starter.instance.canStart){
            yield return new WaitForEndOfFrame();
        }

        while(true){
            while(cooldown>0){
                cooldown-=Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            cooldown = maxCooldown;

            while(transform.position.x >= 8.5f){
                transform.position-=new Vector3(1,0,0) * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(0.5f);

            MG_03_CC_Obstacle ob = Instantiate(prefabTir,transform.position,new Quaternion()).GetComponent<MG_03_CC_Obstacle>();
            ob.transform.eulerAngles = new Vector3(0,0,50);
            ob.dirX = -1;
            ob.dirY = -1;

            ob = Instantiate(prefabTir,transform.position,new Quaternion()).GetComponent<MG_03_CC_Obstacle>();
            ob.transform.eulerAngles = new Vector3(0,0,30);
            ob.dirX = -1;
            ob.dirY = -0.5f;

            ob = Instantiate(prefabTir,transform.position,new Quaternion()).GetComponent<MG_03_CC_Obstacle>();
            ob.transform.eulerAngles = new Vector3(0,0,15);
            ob.dirX = -1;
            ob.dirY = -0.2f;

            yield return new WaitForSeconds(0.5f);

            while(transform.position.x <= 11){
                transform.position+=new Vector3(1,0,0) * speed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            MG_03_CC_Manager.instance.AddTemps(2);
        }
    }
}
