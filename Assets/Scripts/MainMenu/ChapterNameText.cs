using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChapterNameText : MonoBehaviour
{
    Image image;

    public Sprite test;
    void Awake()
    {
        image = GetComponent<Image>();
    }


    public void ChangeTex(Sprite newTex){
        image.sprite = newTex;
    }

}
