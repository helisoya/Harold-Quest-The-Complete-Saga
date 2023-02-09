using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{

    public static AudioMixerManager instance;
    public AudioMixer bgm;

    public AudioMixer voice;

    public AudioMixer sfx;

    public AudioMixerGroup gbgm;

    public AudioMixerGroup gvoice;

    public AudioMixerGroup gsfx;


    public AUDIOSAVE save;

    void Start(){
        instance = this;

        if(System.IO.File.Exists(FileManager.savPath + "userData/gameFiles/audio.txt")){
            save = FileManager.LoadJSON<AUDIOSAVE>(FileManager.savPath + "userData/gameFiles/audio.txt");
        }else{
            save = new AUDIOSAVE();
            SaveFile();
        }
        bgm.SetFloat("Volume",Mathf.Log10(save.valBGM) * 20);
        voice.SetFloat("Volume",Mathf.Log10(save.valVOICE) * 20);
        sfx.SetFloat("Volume",Mathf.Log10(save.valSFX) * 20);
    }

    void SaveFile(){
        FileManager.SaveJSON(FileManager.savPath + "userData/gameFiles/audio.txt",save);
    }

    public void SetVolumeBGM(float sliderValue){
        save.valBGM = sliderValue;
        SaveFile();
        bgm.SetFloat("Volume",Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeVOICE(float sliderValue){
        save.valVOICE = sliderValue;
        SaveFile();
        voice.SetFloat("Volume",Mathf.Log10(sliderValue) * 20);
    }

    public void SetVolumeSFX(float sliderValue){
        save.valSFX = sliderValue;
        SaveFile();
        sfx.SetFloat("Volume",Mathf.Log10(sliderValue) * 20);
    }
}
