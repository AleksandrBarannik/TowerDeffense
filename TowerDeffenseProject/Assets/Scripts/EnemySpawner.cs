using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Отвечает за постоянное появление врагов на сбазе врагов
public class EnemySpawner : MonoBehaviour
{
    //Tooltip-подсказки Range(интервал значений)
    [Tooltip("Время между появлениями врага ")][Range(1,10)][SerializeField] int  spawnInterval;
    [Tooltip("Содержит prefab врага ")][SerializeField] EnemyMovement enemyPrefab;
    [Tooltip("Количесво врагов ")][SerializeField] public int CountEnemy=10;
    
    [Tooltip("ссылка на мен. Victory")]public GameObject VictoryMenu;
    int count=0;
    Castle castle;
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(CreateEnemySpawner());//Вызов сопрограммы
    }

    
    IEnumerator CreateEnemySpawner()//Сопрограмма для спавна монстров
    {
        while ( count<=CountEnemy)
        {
             //Istatiate -создает обьект в сцене (какой обьект позиция и вращение какое)
            var newEnemy=Instantiate(enemyPrefab,transform.position,Quaternion.Euler(0,90,0));
            newEnemy.transform.parent=transform;//дочерние создаются в enemys
            count++;
            yield return new WaitForSeconds(spawnInterval);//Ждать время появления нового врага
            
        }
    }
    public void VictoryonLevel()//Активирует экран победы
    {
       
        VictoryMenu.SetActive(true);
        //Добавить звуки победы
    
    }
}
