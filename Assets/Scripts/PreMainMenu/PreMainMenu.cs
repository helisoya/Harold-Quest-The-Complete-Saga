using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreMainMenu : MonoBehaviour
{

    public GameObject SelectNamePanel;

    public InputField nameField;

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


    void Start(){
        if(MasterItems.instance.HasSelectedName()){
            GoToMainMenu();
        }else{
            SelectNamePanel.SetActive(true);
        }
    }

    public void AcceptName(){
        if(nameField.text!="" && nameField.text != null){
            MasterItems.instance.SetName(nameField.text);
        }else{
            MasterItems.instance.SetName("Ramos");
        }
        
        GoToMainMenu();
    }
}
