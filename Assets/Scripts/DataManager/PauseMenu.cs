using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Slider sliderBGM;
    public Slider sliderVOICE;
    public Slider sliderSFX;

    public void QuitGame(){
        Application.Quit();
    }

    void Start(){
        sliderBGM.value = AudioMixerManager.instance.save.valBGM;
        sliderVOICE.value = AudioMixerManager.instance.save.valVOICE;
        sliderSFX.value = AudioMixerManager.instance.save.valSFX;
    }

    public void SetBGM(){
        AudioMixerManager.instance.SetVolumeBGM(sliderBGM.value);
    }

    public void SetVoice(){
        AudioMixerManager.instance.SetVolumeVOICE(sliderVOICE.value);
    }

    public void SetSFX(){
        AudioMixerManager.instance.SetVolumeSFX(sliderSFX.value);
    }
}
