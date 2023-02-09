using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Page : MonoBehaviour
{

    public int page;

    public GameObject body;


    // Start is called before the first frame update
    void Start()
    {
      if(MasterItems.instance.GetPages().Contains(page)){
          Destroy(body);
      }
    }

    public void AddPage(){
        MasterItems.instance.AddPage(page);
        Destroy(body);
    }

    void OnMouseDown(){
        MasterItems.instance.AddPage(page);
        Destroy(body);
    }
}
