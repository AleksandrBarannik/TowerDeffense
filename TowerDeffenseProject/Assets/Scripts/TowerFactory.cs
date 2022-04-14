using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Создает башни и перемещает  по методу кольцевого буфера если количество 
//башен выше лимита(который записан в переменной)
public class TowerFactory : MonoBehaviour
{
    [Tooltip("Содержит prefab башни ")][SerializeField] Tower towerPrefab;
    [Tooltip("Лимит башен ")][SerializeField] int towerLimit=4;

    Queue<Tower>towerQueue=new Queue<Tower>();//Очередь из башен

    int towersCount=0;

    public void AddTower(WayPoint baseWaypoint) //вызывает функцию создания башни до лимита и функцию перемещения если выше лимита
    {
         int towersCount=towerQueue.Count;//считать количество башен из очереди
        
        if (towersCount<towerLimit)
        {
           InstatiateNewTower(baseWaypoint);
        }
        
        else
        {
           MoveTowerNewPosition(baseWaypoint);
        }
        
    }

    

    private void  InstatiateNewTower(WayPoint baseWaypoint)//Создаем башню в сцене
    {
        var newTower=Instantiate(towerPrefab,baseWaypoint.transform.position,Quaternion.identity);
        
        newTower.transform.parent=transform;//Все дочерние обьекты будут появляться в Towers(пустой род.обьект)
        
        baseWaypoint.isPlaceble=false;//не даст создать несколько башен на одной клетке 
        
        newTower.baseWaypoint=baseWaypoint;//указываем где находится башня
        
        towerQueue.Enqueue(newTower);//Добавляем новую башню в очередь
    }

    private void MoveTowerNewPosition(WayPoint newBaseWaypoint)//Передвигает башню на новую позицию
    {
        //Убрать из очереди первую башню
        Tower oldTower=towerQueue.Dequeue();
        //Поменять позицию башни
            oldTower.transform.position=newBaseWaypoint.transform.position;
        //Указать правильно Isplaebul
            oldTower.baseWaypoint.isPlaceble=true;
            newBaseWaypoint.isPlaceble=false;
        //Указываем новое место расположения бащни (байсвайпоинт)
            oldTower.baseWaypoint=newBaseWaypoint;
        //Добавить в конец очереди
        towerQueue.Enqueue(oldTower);
    }
    
}
