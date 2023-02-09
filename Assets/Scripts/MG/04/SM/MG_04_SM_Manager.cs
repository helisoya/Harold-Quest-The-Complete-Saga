using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_04_SM_Manager : MonoBehaviour
{
    public float maxTime;

    float time;

    public float maxCooldown;
    float cooldown;

    int mock0Pos = 0;

    public GameObject screamerImg;

    public MG_04_SM_Pack[] sides;

    bool screamer = false;

    public UnityEngine.UI.Text text;

    public AudioClip screamerClip;

    public AudioClip ventClip;

    public AudioSource source;

    void Start()
    {
        time = maxTime;
        cooldown  = maxCooldown;
    }

    IEnumerator Screamer(){
        screamer = true;
        screamerImg.SetActive(true);
        source.clip = screamerClip;
        source.Play();
        yield return new WaitForSeconds(1);
        screamerImg.SetActive(false);
        screamer = false;
    }

    void MoveMock0(){
        if(!sides[mock0Pos].vent.activeInHierarchy){
            time = maxTime;
            StartCoroutine(Screamer());
        }else{
            source.clip = ventClip;
            source.Play();
        }
        sides[mock0Pos].mock0.SetActive(false);
        mock0Pos = Random.Range(0,3);
        sides[mock0Pos].mock0.SetActive(true);
    }

    public void CloseDoor(int side){
        if(sides[side].vent.activeInHierarchy){
            sides[side].vent.SetActive(false);
            return;
        }
        if(checkIfAllOpen()){
            sides[side].vent.SetActive(true);
        }
    }

    public void Light(int side){
        if(!sides[side].dark.activeInHierarchy){
            sides[side].dark.SetActive(true);
            return;
        }
        if(checkIfNoLight()){
            sides[side].dark.SetActive(false);
        }
    }

    bool checkIfAllOpen(){
        foreach(MG_04_SM_Pack pack in sides){
            if(pack.vent.activeInHierarchy){
                return false;
            }
        }
        return true;
    }

    
    bool checkIfNoLight(){
        foreach(MG_04_SM_Pack pack in sides){
            if(!pack.dark.activeInHierarchy){
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        if(!MG_Starter.instance.canStart || screamer){
            return;
        }
        if(time > 0 ){
            time-=Time.deltaTime;
        }else{
            MG_Starter.instance.LoadNext();
        }
        text.text = "Temps Restant : "+((int)time+1).ToString();

        if(cooldown > 0){
            cooldown-=Time.deltaTime;
        }else{
            cooldown = maxCooldown;
            MoveMock0();
        }
    }
}


[System.Serializable]
public class MG_04_SM_Pack{
    public GameObject mock0;
    public GameObject vent;
    public GameObject dark;
}