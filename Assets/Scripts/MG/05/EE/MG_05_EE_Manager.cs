using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG_05_EE_Manager : MonoBehaviour
{
    public GameObject bulle;
    public Image victim;
    public Button button;
    public int speed;
    public Color targetCol;

    IEnumerator Bulle(){
        bulle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        bulle.SetActive(false);
    }

    IEnumerator AutoWin(){
        while(victim.color != targetCol){
            victim.color = Color.Lerp(victim.color,targetCol,Time.deltaTime*speed);
            yield return new WaitForEndOfFrame();
        }

        MG_Starter.instance.LoadNext();
        
    }

    public void Attack()
    {
        button.interactable = false;
        StartCoroutine(Bulle());
        StartCoroutine(AutoWin());
    }

}
