using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
// Скрипт возвращает позицию каждой клекти карты и шаг сетки 
//и устанавливает цвет клетке

public class WayPoint : MonoBehaviour
{
    
    public WayPoint exploredFrom;//означает из какого блока пришли к текущему
    const int gridSize=10;
    Vector2Int gridPos;
    public bool IsExplored = false;// Отвечает иследована клетка или нет
    public bool isPlaceble=true;//Можем ли мы ставить башню на блок
    

    
    public int GetGridSize() //Метод возвращает значения шага сетки
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()//Метод возвращает позицию каждой клетки карты (каждого кубика)
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
        );
        
    }

    public void SetTopColor(Color color)//Метод окрашивает верх обьектов в нужный цвет
    {
        MeshRenderer TopMeshRenderer=transform.Find("Top").GetComponent<MeshRenderer>();
        TopMeshRenderer.enabled=true;
        TopMeshRenderer.material.color=color;
    }

    void OnMouseOver()//Размещает бащню в нужном блоке (который не принадлежит пути)
    {
        if(Input.GetMouseButtonDown(0))
        {
           if(isPlaceble)  
           {
              FindObjectOfType<TowerFactory>().AddTower(this);
           }
           else
           {
                Debug.Log("Здесь нельзя строить");
           }
        }
    }
}
