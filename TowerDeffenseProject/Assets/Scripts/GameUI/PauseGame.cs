using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale=0.0F;
    }

    public void Resume()
    {
        Time.timeScale=1F;
    }
}
