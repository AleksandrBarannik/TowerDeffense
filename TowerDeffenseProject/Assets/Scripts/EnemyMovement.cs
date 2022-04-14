using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cкрипт отвечает за перемещение врага
public class EnemyMovement : MonoBehaviour
{
    
    
   [Tooltip("Скорость движения врагов по полю")] [SerializeField] float speedMovemant;
   [Tooltip("Скорость перемещения между двумя позициями ")] [SerializeField] float MoveStep;
    PathFinder pathFinder;
    Animator EnemyAttackAnimator;//Для воспроизведения анимации атаки
    

    Castle castle;//ДЛяя обращения к методу Custle.Damage()
    Vector3 targetPossition;
    // Start is called before the first frame update
    void Start()
    {
        castle=FindObjectOfType<Castle>();
        pathFinder=FindObjectOfType<PathFinder>();
        var path=pathFinder.GetPath();
        //Запуск сопрограммы
        StartCoroutine(MoveEnemy(path));
    }

    // Update is called once per frame
    void Update()
    {
       if (castle.Playerlive>0)
       {
        //ДЛя плавного перемещения врагов по карте
        transform.position=Vector3.Lerp(transform.position,targetPossition,Time.deltaTime*MoveStep);
       }   
    }
    IEnumerator MoveEnemy(List<WayPoint>path)//Сопрограмма отвечает за просмотр врага в сторону куда он идет и его перемещение
    {
       if (castle.Playerlive>0)
       {
       
       foreach(WayPoint waypoint in path)
       {
         
                    
          transform.LookAt(waypoint.transform);
          targetPossition=waypoint.transform.position;
          yield return new WaitForSeconds(speedMovemant);
          
          
          
       }
        
        PlayAttackAnimation();
        castle.Damage();
        
       }
       else
       {
           //Здесь нужно вызвать экран проигрыша!!!
           castle.DeadPlayer();
       }
    }
    public void PlayAttackAnimation()//Воспроизводит аннимацию атаки
    {
        if (castle.Playerlive>0)
       {
        EnemyAttackAnimator=GetComponent<Animator>();//Получаем доступ к аниматору
        EnemyAttackAnimator.SetTrigger("attack");//Тригер attack
       }
    }

    
}
