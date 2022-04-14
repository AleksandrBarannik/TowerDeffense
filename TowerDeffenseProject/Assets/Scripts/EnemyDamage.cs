using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SelectionBase]

//Отвечает за отнимание жизней у врага  и смерть врага
public class EnemyDamage : MonoBehaviour
{
   [Tooltip("Жизни врага ")][SerializeField] public int livePoints=10;
   Text scoreText;
   //int currentDeadScore;
   int EnemyWariorCount=0;//Будет  содержать число врагов
   
   EnemySpawner EnemyAll;//Для получения доступа к переменной CountEnemy;
   Animator EnemyDeathAnimator;//Для обращения к анимации смерти по тригеру
  
    
   void Start()
   {
       //Находим в сцене компонент
        scoreText=GameObject.Find("Score").GetComponent<Text>();
        EnemyAll=GameObject.Find("Enemys").GetComponent<EnemySpawner>();
        
        if(scoreText.text=="")//Чтобы 1 раз подставить значение Переменной врагов в самом начале
        {
            scoreText.text=(EnemyAll.CountEnemy+1).ToString();
        }
       
       
   }
  
   void OnParticleCollision(GameObject other)
   {
       HitProcess();
       if (livePoints<=0)
       {
           DeadEnemy();
           
       }
   }
   
   
    private void HitProcess()//Процесс уменьшения жизней врога
    {
       livePoints= livePoints-1;
    }
  
    private void PlayDeathAnimation()//Воспроизводит анимацию смерти 
    {
        EnemyDeathAnimator=GetComponent<Animator>();//Получаем доступ к аниматору
        EnemyDeathAnimator.SetTrigger("death");//Тригер death
        
             
    }
   
    private void DeadEnemy()//Удаляет убитого врага из сцены и воспроизводит анимаию
    {
                
        PlayDeathAnimation();
        Destroy(gameObject);
        AddScore();
    }

    private void AddScore()//Добавляет очки за уничтожение врагов
    {  
        EnemyWariorCount=int.Parse(scoreText.text);;
        EnemyWariorCount--;
        scoreText.text=EnemyWariorCount.ToString();

        if (EnemyWariorCount<=0)
       {
          EnemyAll.VictoryonLevel();
           
       }
        
    }

 

    
}
