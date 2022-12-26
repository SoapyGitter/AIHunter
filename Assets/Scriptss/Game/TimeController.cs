using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus))
            SlowTime();
        if (Input.GetKeyDown(KeyCode.P))
            FasterTime();
    }
    public bool IsTimeSlowed() => Time.timeScale < 1f;
    public void SlowTime()
    {
        Time.timeScale = 0.001f;
    }

    public void FasterTime()
    {
        Time.timeScale = 1f;
    }
}
