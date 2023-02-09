using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_05_MTG_Raquette : MonoBehaviour
{
    Vector3 move = new Vector3(1,1,0);

    List<MG_05_MTG_Balle> balles = new List<MG_05_MTG_Balle>();

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            foreach(MG_05_MTG_Balle balle in balles){
                balle.direction = move;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="Player"){
            balles.Add(col.GetComponent<MG_05_MTG_Balle>());
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.tag=="Player"){
            balles.Remove(col.GetComponent<MG_05_MTG_Balle>());
        }
    }

}
