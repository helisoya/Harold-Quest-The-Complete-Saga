using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_04_AB_Manager : MonoBehaviour
{
    public string correctCode;

    string code = "";

    public UnityEngine.UI.Text text;

    void Updatetext(){
        text.text = code;
    }

    public void checkCode(){
        if(code==correctCode){
            MG_Starter.instance.LoadNext();
        }else{
            code = "";
            Updatetext();
        }
    }

    public void AddNumber(string n){
        if(code.Length<4){
            code+=n;
        }
        Updatetext();
    }

    public void RemoveLastNumber(){
        if(code.Length != 0){
            code = code.Substring(0,code.Length-1);
        }
        Updatetext();
    }
}
