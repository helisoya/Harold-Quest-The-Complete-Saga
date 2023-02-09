using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterItems : MonoBehaviour
{
    public static MasterItems instance = null;

    public MASTERSAVE save;

    public GameObject pausePrefab;

    bool paused = false;

    public GameObject instancePause = null;

    void Awake(){
        
        if(MasterItems.instance != null){
            Destroy(gameObject);
            return;
        }

        instance = this;
        if(System.IO.File.Exists(FileManager.savPath + "userData/gameFiles/master.txt")){
            save = FileManager.LoadJSON<MASTERSAVE>(FileManager.savPath + "userData/gameFiles/master.txt");
        }else{
            save = new MASTERSAVE();
            SaveFile();
        }
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            paused = !paused;
            if(!paused){
                Time.timeScale = 1;
                Destroy(instancePause);
                instancePause = null;
            }else{
                Time.timeScale = 0;
                instancePause = Instantiate(pausePrefab,GameObject.Find("Canvas").transform);
            }
        }
    }

    public List<int> GetPages(){
        return save.pagesFound;
    }

    void SaveFile(){
        FileManager.SaveJSON(FileManager.savPath + "userData/gameFiles/master.txt",save);
    }


    public bool HasCompletedChapter(int chapter){
        return save.finishedChapters.Contains(chapter);
    }

    public bool HasAllPages(){
        return save.pagesFound.Count == 7;
    }

    public void AddFinishedChapter(int chapter){
        if(!save.finishedChapters.Contains(chapter)){
            save.finishedChapters.Add(chapter);
        }
        SaveFile();
    }

    public void AddPage(int page){
        if(!save.pagesFound.Contains(page)){
            save.pagesFound.Add(page);
        }
        SaveFile();
    }

    public string GetPlayerName(){
        return save.playerName;
    }

    public bool HasSelectedName(){
        return save.playerNameChoosed;
    }
    

    public void SetName(string newName){
        save.playerName = newName;
        save.playerNameChoosed = true;
        SaveFile();
    }
}
