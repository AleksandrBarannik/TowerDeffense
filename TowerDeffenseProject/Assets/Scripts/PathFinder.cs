using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Отвечает за поиск пути по которому пойдет враг
public class PathFinder : MonoBehaviour
{
   [Tooltip("Начальная и конечная точка пути")] [SerializeField] WayPoint startPoint,endPoint;
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int,WayPoint>();//Vector2-позиция блоков(ключи) ведут к значениям (нужному блоку WayPoint)
    Queue<WayPoint>queue=new Queue<WayPoint>();//queue-Очередь
    WayPoint searchPoint;//содержит текущую точку для алгоритма пути который иследуем
    bool isRunning=true;// указывает нашли ли мы конечную точку или нет
    List<WayPoint> path=new List<WayPoint>();//список для хранения пути
    
//Массив содержит еденичные вектора вверх(1,0) влево(0,1) вниз(-1,0) вправо(0,-1)
    Vector2Int [] directions={
                                Vector2Int.up,
                                Vector2Int.right,
                                Vector2Int.down,
                                Vector2Int.left
                             };
        
    public List<WayPoint>GetPath()//Метод передает путь нужному нам скрипту (в данном случае EnemyMovment)
    {
        if(path.Count==0)
        {
             LoadBloks();
             SetColorStartAndEnd();
             PathfindAlgoritm();
             CreatePath();
        }
        return path;
    }


     private void CreatePath()// Метод проходит обратно по пути и добавляет путь в список

    {
        AddPointToPass(endPoint);
        //prevPoint- содержит предыдущую хлебную крошку(точку) изначально
        WayPoint prefPoint=endPoint.exploredFrom;
        while (prefPoint!=startPoint)
        {
            AddPointToPass(prefPoint);
            prefPoint=prefPoint.exploredFrom;
        }
        AddPointToPass(startPoint);
        path.Reverse();
    }
    
    private void AddPointToPass(WayPoint waypoint)//Добавляем точку в путь и блокируем клетку для башни
    {
        path.Add(waypoint);
        waypoint.SetTopColor(Color.gray);//Выставляем цвет где нельзя ставить башни
        waypoint.isPlaceble=false;
        
    }
    private void PathfindAlgoritm()//Метод ищет путь вызывая методы проверки соседних точек и метод проверки конечной точки
    {
        queue.Enqueue(startPoint);
        while (queue.Count>0 && isRunning==true)
            {
                searchPoint=queue.Dequeue();
                searchPoint.IsExplored=true;
                CheckForEndPoint();
                ExploreNearPoints();
            }

    }
    private  void  CheckForEndPoint()//Проверяет является ли стартовая точка -конечной
    {
        if(searchPoint==endPoint)
        {
            isRunning=false;
        }
        
    }
    
     
    
    private void ExploreNearPoints()//Метод исследует ближайшие соседние  точки к текущей и вызывает метод добавления в очередь
    {
        if (!isRunning)
            {
                return;
            }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int nearPointCoordinates=searchPoint.GetGridPos()+direction;
            if(grid.ContainsKey(nearPointCoordinates))
                {
                    WayPoint nearPoint=grid[nearPointCoordinates];
                    AddPointToQueue(nearPoint);
                    //nearPoint [хранит соседние точки  для текущей ]
                }
            
            
        }
    }

    
    private void AddPointToQueue(WayPoint nearPoint)//метод добавляет соседние  точки в очередь
    {
        if (nearPoint.IsExplored||queue.Contains(nearPoint))
         {
             return;
         }
        else
        {
            queue.Enqueue(nearPoint);
            nearPoint.exploredFrom=searchPoint;
        }
    }
   
   
    private void LoadBloks()//Метод добавляет обьекты в Словарь
    {
        var  waypoints= FindObjectsOfType<WayPoint>();
        foreach(WayPoint waypoint in waypoints)
        {
            Vector2Int gridPos=waypoint.GetGridPos();
            
            //Проверка на повторы
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Повтор"+waypoint);
            }
            else
            {
                //Добавляем блок в Dictionary gridPos(Ключ- позиция блока),WayPoint(сам блок)
                grid.Add(gridPos,waypoint);
                
            }
           
        }
        
    }
    
    
    void SetColorStartAndEnd()//Метод устанавливает цвет стартовому обьекту и конечному обьекту
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
    }

   
}
