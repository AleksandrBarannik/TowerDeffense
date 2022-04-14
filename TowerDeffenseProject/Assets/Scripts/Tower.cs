using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]//выделяет обьект на котором висит скрипт

//Class овечает за  поворот башни в торону противника ,дитанцию стрельбы
//Сравнивает какой враг ближе к башне и назначает ближайшего врага
public class Tower : MonoBehaviour
{
    [Tooltip("Хранит башню,атакующую врага")][SerializeField] Transform BodyBaseRotation;
    
    [Tooltip("Хранит самого врага ")][SerializeField] Transform targetEnemy;
    [Tooltip("Дальность стрельбы ")] [SerializeField] float shootRange;
    [Tooltip("Эффект стрельбы")][SerializeField] ParticleSystem bulletParticles;
    public WayPoint baseWaypoint;
    
    
    
    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        
        //Если враг есть стреляем
        if (targetEnemy)
        {
            //Look At отвечает за слежение башни за врагом
            BodyBaseRotation.LookAt(targetEnemy);
            Fire();
        }
        else 
        {
            Shoot(false);
        }

    }

    private void SetTargetEnemy()//Сравниает всех врагов
    {
        var sceneEnemies=FindObjectsOfType<EnemyDamage>();//Получить всех врагов
        
        if (sceneEnemies.Length==0)
        {return;}
        
        Transform closestEnemy=sceneEnemies[0].transform;//Самый первый ближайший
        
        foreach(EnemyDamage test in sceneEnemies)//Сравнить всех врагов и указать ближайшего
        {
            closestEnemy=GetClossestEnemy(closestEnemy.transform,test.transform);            
        }
    targetEnemy=closestEnemy;//Текущий враг будет равняться ближайшему врагу

    }

    
    private Transform GetClossestEnemy(Transform EnemyA, Transform EnemyB)//Сравнивает позиции двух врагов к башне и выбирает ближайшего из них

    {
        var distToA=Vector3.Distance(EnemyA.position,transform.position);
        var distToB=Vector3.Distance(EnemyB.position,transform.position);
        if (distToA<distToB)
        {
            return EnemyA;
        }
        return EnemyB;
    }

    


    private void Fire()
    {
        //Содержит дистанцию до врага (включает стрельбу при достижении дитанции)
        float distanseToEnemy=Vector3.Distance(targetEnemy.position,transform.position);
        if (distanseToEnemy<=shootRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

     
    private void Shoot(bool isActive)//Отвечает за включение и выключение эффекта стрельбы
    {
        var Emission =bulletParticles.emission;
        Emission.enabled=isActive;
    }
}
