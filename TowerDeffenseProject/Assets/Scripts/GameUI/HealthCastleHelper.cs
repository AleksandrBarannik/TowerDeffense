using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Управляет полоской жизни замка
public class HealthCastleHelper : MonoBehaviour
{
    private Slider slider;
    private Castle castle;

    void Awake()
    {
        slider=GetComponent<Slider>();
        castle=FindObjectOfType<Castle>();
        slider.maxValue=castle.Playerlive;
    }

    void Update()
    {
        slider.value=castle.Playerlive;
    }
        

}
