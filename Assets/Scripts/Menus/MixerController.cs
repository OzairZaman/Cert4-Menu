using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour {

    //added to the Slider object
    
    //Window > Audio > Audio Mixer
    //Make a new Mixer
    //Expose the member variables 
    //We need:
        //Audio Source - add this as a component to a GameObject
            //Audio Clip
            //And the Audio Mixer
    public AudioMixer mixer;

    //make sure to choose the dynamic version of this fuction
    //from the SliderScript's OnValueChange field
    public void SetVolume(float value)
    {
        //converting the value passed in to a log10 base
        //so the volue is not linear
        mixer.SetFloat("musicVolume", Mathf.Log10(value) * 20f);
    }
}
