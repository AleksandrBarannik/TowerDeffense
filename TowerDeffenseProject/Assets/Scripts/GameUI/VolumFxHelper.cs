using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//передает значиние громкости из настроек в параметр Volume У AudioSourse
//Для Fx эффектов
public class VolumFxHelper : MonoBehaviour
{
    private AudioSource sourceFx;
    // Start is called before the first frame update
    void Start()
    {
        sourceFx=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sourceFx.volume=UISettings.fxLevel;

    }
}

