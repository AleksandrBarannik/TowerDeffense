using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Отвечает за загрузку уровней,перезапуск текущего , запуск следующего 
//Загрузку главного меню
public class LoaderLevels : MonoBehaviour
{
    
    
    public void StartGame()
    {
       int IndexNextLevel=SceneManager.GetActiveScene().buildIndex+1;
       SceneManager.LoadScene(IndexNextLevel);
    }

   

    public void LoadMainMenu()//Загрузка главного меню
    {
         SceneManager.LoadScene(0);
         Time.timeScale=1f;
    }

    public void LoadNextLevel() //Загрузка следующего уровня
    {
        int IndexCurrentLevel=SceneManager.GetActiveScene().buildIndex;//Получаем индекс уровня
        int IndexNextLevel=SceneManager.GetActiveScene().buildIndex+1;
        
        if  (IndexNextLevel==SceneManager.sceneCountInBuildSettings)
        {
            IndexNextLevel=0;
        }
        SceneManager.LoadScene(IndexNextLevel);
    }

    public void RestartCurrentLevel()//Перезапуск уровня
    {
        int IndexCurrentLevel=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(IndexCurrentLevel);
        Time.timeScale=1f;
        
    }

    public void ExitGame()
    {
          Application.Quit();
    }
    

   

   
}
