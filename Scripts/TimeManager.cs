using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private bool TimeStop = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (TimeStop)
            {
                Time.timeScale = 1;
                TimeStop = false;
            }
            else
            {
                Time.timeScale = 0;
                TimeStop = true;
            }
        }
    }
}
