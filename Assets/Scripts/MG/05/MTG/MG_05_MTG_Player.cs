using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_05_MTG_Player : MonoBehaviour
{
    public int maxHP;
    int hp;

    public float maxTime;
    float time;

    public Text textHP;
    public Text textTime;

    void Start()
    {
        hp = maxHP;
        time = maxTime;
    }

    void TakeDamage(){
        hp--;
        if(hp == 0){
            hp = maxHP;
            time = maxTime;
        }
        textHP.text = "HP : "+hp.ToString();
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

        textTime.text = "Temps restant : "+((int)time + 1).ToString();

    }


    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Player"){
            Destroy(col.gameObject);
            TakeDamage();
        }
    }
}
