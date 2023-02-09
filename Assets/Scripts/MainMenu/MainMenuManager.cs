using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Sprite defaultSprite;
    public List<MAINMENU_CHAPTERIMAGES> images = new List<MAINMENU_CHAPTERIMAGES>();

    private int currentChapter = 0;

    public ChapterNameText chapterName;

    public TransitionEfffect background;

    public Button button_left;
    public Button button_right;

    public Button button_playUp;
    public Button button_playMiddle;

    public Button button_continue;

    public GameObject preMenu;

    public Transform Pages;

    public GameObject PagesButton;

    void Start(){

        if(AudioManager.instance != null){
            AudioManager.instance.PlaySong(null);
        }

        UpdatePages();
    }
    public void ClickToShowMenu()
    {
        preMenu.SetActive(false);
        PagesButton.SetActive(true);
        button_right.gameObject.SetActive(true);
        button_left.gameObject.SetActive(true);
        LoadChapter(0);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void UpdatePages(){
        foreach(int elem in MasterItems.instance.GetPages()){
            Pages.GetChild(elem).gameObject.SetActive(true);
        }
    }

    public void LoadChapter(int x){
        currentChapter = x;
        chapterName.ChangeTex( (images[x].useBlackForCompleted || !MasterItems.instance.HasCompletedChapter(x)) ? images[x].titleBlack : images[x].titleWhite);
        background.TransitionToTex( MasterItems.instance.HasCompletedChapter(x) ?  images[x].background : defaultSprite);

        // Bouton Lancer le Jeu + Continuer

        if(System.IO.File.Exists(FileManager.savPath + "userData/gameFiles/"+x.ToString()+".txt")){
            button_playUp.gameObject.SetActive(true);
            button_playMiddle.gameObject.SetActive(false);
            button_continue.gameObject.SetActive(true);

            button_playUp.onClick.RemoveAllListeners();
            button_playUp.onClick.AddListener(()=>{
                GameItems.instance.ResetAllItems();
                LoadVisualNovel.instance.LoadChapter(images[x].Start,x,false);
            });

            button_continue.onClick.RemoveAllListeners();
            button_continue.onClick.AddListener(()=>{
                GameItems.instance.ResetAllItems();
                LoadVisualNovel.instance.LoadChapter(images[x].Start,x,true);
            });
        }else{
            button_playUp.gameObject.SetActive(false);
            button_playMiddle.gameObject.SetActive(true);
            button_continue.gameObject.SetActive(false);

            button_playMiddle.onClick.RemoveAllListeners();
            button_playMiddle.onClick.AddListener(()=>{
                GameItems.instance.ResetAllItems();
                LoadVisualNovel.instance.LoadChapter(images[x].Start,x,false);
            });
        }

        


        if(x>0){ // Bouton Gauche
            button_left.gameObject.SetActive(true);
            button_left.onClick.RemoveAllListeners();
            button_left.onClick.AddListener(()=>{
                LoadChapter(currentChapter-1);
            });
        }else{
            button_left.gameObject.SetActive(false);
        }


        if(x<7 && MasterItems.instance.HasCompletedChapter(x) && !(!MasterItems.instance.HasAllPages() && x==6)){ // Bouton Droite
            button_right.gameObject.SetActive(true);
            button_right.onClick.RemoveAllListeners();
            button_right.onClick.AddListener(()=>{
                LoadChapter(currentChapter+1);
            });
        }else{
            button_right.gameObject.SetActive(false);
        }
    }

}



[System.Serializable]
public class MAINMENU_CHAPTERIMAGES{

    public string Start;
    public Sprite background;
    public Sprite titleBlack;

    public Sprite titleWhite;

    public bool useBlackForCompleted = true;
}