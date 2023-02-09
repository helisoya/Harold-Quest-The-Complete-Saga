using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MASTERSAVE
{
    public List<int> finishedChapters = new List<int>();
    public List<int> pagesFound = new List<int>();

    public string playerName = "Ramos";

    public bool playerNameChoosed = false;

    public MASTERSAVE(){
        finishedChapters = new List<int>();
        pagesFound = new List<int>();
        playerName = "Ramos";
        playerNameChoosed = false;
    }
}
