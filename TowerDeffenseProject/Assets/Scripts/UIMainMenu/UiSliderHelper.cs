using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Записывает текущее значение звука и Fx звука
// из слайдеров в поля soundLevel и fxLevel класса UISettings
public class UiSliderHelper : MonoBehaviour
{
    private Slider soundSlider;
    private Slider fxSlider;
   void Awake()
   {
       soundSlider=GameObject.Find("SoundSlider").GetComponent<Slider>();
       fxSlider=GameObject.Find("FxSlider").GetComponent<Slider>();
   }
   
   void  Start()
   {
       soundSlider.value= UISettings.soundLevel;
       fxSlider.value=UISettings.fxLevel;
   }
    void Update()
    {
        UISettings.soundLevel=soundSlider.value;
        UISettings.fxLevel=fxSlider.value;
        
    }
}
