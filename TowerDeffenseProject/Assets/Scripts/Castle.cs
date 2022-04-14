using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Содержит жизни замка и  скрипт получения урона замка
public class Castle : MonoBehaviour
{
    [Tooltip("Жизни замка")][SerializeField] public int Playerlive=10;
    [Tooltip("Кооличество урона за 1 удар")][SerializeField] int DamageCount=2;
    
   [Tooltip("ссылка на мен. GameOver")]public GameObject GameOverMenu;
    

    public void Damage()//Отнимает урон у здоровья замка
    {
        if(Playerlive>=1)
        {
        Playerlive=Playerlive-DamageCount;
       
        }
    }
    public void DeadPlayer()//Game over
    {
        if(Playerlive<=0)
        {
            //Добавить эффект взрыва
            
                        
            //Активируем меню смерти
            GameOverMenu.SetActive(true);
        }   

    }

    
}
