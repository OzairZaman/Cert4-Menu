using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;

public class GamePauseMenu : MonoBehaviour {


    public GameObject optionsPanel; //this is the panel to show / hide, has options UI

    //reference to the audio source that is 
    //attached to the empty game object MusicSource
    //drag and drop that into this field in the UI
    public AudioSource source; 

    //mixer - is not attached to any object
    //is in project and can be used in scripts and
    //by other components - pick it by the picker to the right of the field (circle)
    public AudioMixer mixer;
    float timeDelay = 4f; // fade time length for the music
    float cd, value, volume;
    bool turnDownVolume;

    // Use this for initialization
    void Start ()
    {
        optionsPanel.SetActive(false);
        cd = 0.0001f;
        turnDownVolume = false;
        volume = source.volume;

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Cancel"))
        {

            optionsPanel.SetActive(true);
            turnDownVolume = true;
            
            //if (GameManager.isPaused)
            //{
            //    Resume();
            //}
            //else
            //{
            //    Pause();
            //}

        }
        if (turnDownVolume)
        {
            if (timeDelay >= cd)
            {
                value = (timeDelay - cd) / timeDelay;
                mixer.SetFloat("musicVolume", Mathf.Log10(value) * 20f);
                cd += Time.deltaTime;
            }
            else
            {
                turnDownVolume = false;
                source.Pause();
                cd = 0.0001f;
                Debug.Log("Paused Music ");
            }
        }
        
    }

    public void ResumeGame()
    {
        optionsPanel.SetActive(false);
        mixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20f);
        Debug.Log(source.volume);
        source.Play();
        
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }
}
