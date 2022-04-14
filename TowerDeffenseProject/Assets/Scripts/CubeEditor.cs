using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(WayPoint))]
//Отвечает за перемещение обьекта по сетке на нужное расстояние 
//Нужен только для построения карты (потом можно отключить)
public class CubeEditor : MonoBehaviour
{
    
       // Update is called once per frame
    
    
   
    WayPoint waypoint;
    

    void Awake()
    {
        waypoint=GetComponent<WayPoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }
  

    private void SnapToGrid()
    {
        int gridSize=waypoint.GetGridSize();
        transform.position = new Vector3(waypoint.GetGridPos().x*gridSize,0f,waypoint.GetGridPos().y*gridSize);
    }

     private void UpdateLabel()
    {
        TextMesh label;
        label = GetComponentInChildren<TextMesh>();//для отображения координат обьекта
        string labelName = waypoint.GetGridPos().x  + "," + waypoint.GetGridPos().y;
        label.text = labelName;
        gameObject.name = labelName;
    }
}
