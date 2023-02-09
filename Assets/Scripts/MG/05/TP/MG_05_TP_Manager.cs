using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_05_TP_Manager : MonoBehaviour
{
    public static MG_05_TP_Manager instance;
    public int speed;
    public int numberSwap;
    int maxSwap;
    public GameObject piece;
    public GameObject gobelet1;
    public GameObject gobelet2;
    public GameObject gobelet3;
    public GameObject text;
   
    bool done = false;

    public bool canChoose = false;
    void Start()
    {
        maxSwap = numberSwap;
        instance = this;
        StartCoroutine(StartGame());
    }

    public void Reset(){
        numberSwap = maxSwap;
        piece.transform.position = gobelet1.transform.position;
        text.SetActive(false);
        piece.SetActive(true);
        gobelet1.SetActive(false);
        gobelet2.SetActive(false);
        gobelet3.SetActive(false);
        StartCoroutine(StartGame());
    }
    IEnumerator MoveGobelet(Transform target, Transform gobelet,bool up){
        int signe = 1;
        if(!up){
            signe = -1;
        }
        Vector3[] pos = new Vector3[]{new Vector3(gobelet.position.x,3*signe,0),new Vector3(target.position.x,3*signe,0), target.position} ;
        foreach(Vector3 p in pos){
            while(gobelet.position != p){
                gobelet.position = Vector3.MoveTowards(gobelet.position,p,Time.deltaTime*speed);
                yield return new WaitForEndOfFrame();
            }
        }
        done = true;
    }

    IEnumerator StartGame(){
        while(!MG_Starter.instance.canStart){
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2);
        piece.SetActive(false);
        text.SetActive(false);
        gobelet1.SetActive(true);
        gobelet2.SetActive(true);
        gobelet3.SetActive(true);

        while(numberSwap!=0){
            done = false;
            int de = Random.Range(0,3);
            if(de==0){
                StartCoroutine(MoveGobelet(gobelet1.transform,gobelet2.transform,true));
                StartCoroutine(MoveGobelet(gobelet2.transform,gobelet1.transform,false));
            }else if(de==1){
                StartCoroutine(MoveGobelet(gobelet1.transform,gobelet3.transform,true));
                StartCoroutine(MoveGobelet(gobelet3.transform,gobelet1.transform,false));
            }else{
                StartCoroutine(MoveGobelet(gobelet3.transform,gobelet2.transform,true));
                StartCoroutine(MoveGobelet(gobelet2.transform,gobelet3.transform,false));
            }

            while(!done){
                yield return new WaitForEndOfFrame();
            }
            numberSwap--;
            yield return new WaitForSeconds(1);
        }
        text.SetActive(true);
        canChoose = true;
    }

}
