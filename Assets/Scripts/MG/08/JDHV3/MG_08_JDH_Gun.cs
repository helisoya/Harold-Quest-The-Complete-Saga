using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_08_JDH_Gun : MonoBehaviour
{
    public int score;
    public GameObject gun;
    Coroutine gunAppeared = null;

    void Start()
    {
        gunAppeared = StartCoroutine(GunOnScreen());
    }


    public void ClickOnGun(){
        gun.SetActive(false);
        StopCoroutine(gunAppeared);
        MG_01_JDH_Harold.instance.AddScore(-score);
        gunAppeared = StartCoroutine(GunOnScreen());
    }

    IEnumerator GunOnScreen(){
        while(!MG_Starter.instance.canStart){
            yield return new WaitForEndOfFrame();
        }

        gun.SetActive(false);
        yield return new WaitForSeconds(5);

        gun.SetActive(true);
        yield return new WaitForSeconds(2);

        gun.SetActive(false);
        MG_01_CEF_Manage.instance.AddScore(-score);

        gunAppeared = StartCoroutine(GunOnScreen());


    }
}
