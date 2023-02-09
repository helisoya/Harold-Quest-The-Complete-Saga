using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_08_CCC_Manager : MonoBehaviour
{
    public static MG_08_CCC_Manager instance;
    
    public float maxTime;
    float time;

    public Text text;

    public GameObject prefabBalle;

    public float maxCooldown;

    float cooldown;

    public Rigidbody2D player;

    void Start()
    {
        time = maxTime;
        instance = this; 
        cooldown = maxCooldown;   
    }

    public void Reset(){
        time = maxTime;
    }

    void Update()
    {
        if(!MG_Starter.instance.canStart){
            return;
        }

        if(cooldown > 0){
            cooldown-=Time.deltaTime;
        }else{
            cooldown = maxCooldown;
            MG_08_CCC_Balle ob = Instantiate(prefabBalle,transform).GetComponent<MG_08_CCC_Balle>();
            int de = Random.Range(0,4);
            Vector3 pos = Vector3.zero;
            if(de == 0){
                pos = new Vector3(-10,Random.Range(-8,8),0);
            }else if(de == 1){
                pos = new Vector3(10,Random.Range(-8,8),0);
            }else if(de == 2){
                pos = new Vector3(Random.Range(-10,10),8,0);
            }else{
                pos = new Vector3(Random.Range(-10,10),-8,0);
            }
            
            ob.transform.position = pos;

            float dist = Mathf.Sqrt(Mathf.Pow(player.transform.position.x-pos.x,2)+Mathf.Pow(player.transform.position.y-pos.y,2));
            ob.move = new Vector3((player.transform.position.x - pos.x)/dist,(player.transform.position.y - pos.y)/dist,0) ;
        }

        if(time<=0){
            MG_Starter.instance.LoadNext();
        }else{
            time-=Time.deltaTime;
        }

        text.text = "Temps restant : "+(((int)time) + 1).ToString();
    }
}
