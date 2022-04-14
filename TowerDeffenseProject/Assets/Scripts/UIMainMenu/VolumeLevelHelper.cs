using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//передает значиние громкости из настроек в параметр Volume У AudioSourse
public class VolumeLevelHelper : MonoBehaviour
{
    private AudioSource sourceMusic;
    // Start is called before the first frame update
    void Start()
    {
        sourceMusic=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sourceMusic.volume=UISettings.soundLevel;

    }
}
