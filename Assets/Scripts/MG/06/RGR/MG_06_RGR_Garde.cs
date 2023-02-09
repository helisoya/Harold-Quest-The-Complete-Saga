using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_06_RGR_Garde : MonoBehaviour
{
    public float speed;
    public float sizeDisapear;
    public GameObject page;


    void Start()
    {
        if(Random.Range(0,100) <= 20){
            page.SetActive(true);
        }
    }

    void Update()
    {
        transform.localScale += new Vector3(1,1,0) * Time.deltaTime * speed;

        if(transform.localScale.x>= sizeDisapear){
            Destroy(gameObject);
            MG_06_RGR_Manager.instance.ResetTimer();
        }
    }


    void OnMouseDown(){
        Destroy(gameObject);
    }
}
