using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private static float timer = 0;
    private GameUIController uIController;

    public static float Timer { get => timer; set => timer = value; }

    private void Awake()
    {
        uIController = GameObject.FindObjectOfType<GameUIController>();
        timer = 0;
    }
    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
        uIController.KeyboardControl_UpdateTimer(String.Format("{0:0.0}", Timer));
    }

}
