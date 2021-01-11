using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private static float timer = 0;
    private Text textUI;

    public static float Timer { get => timer; set => timer = value; }

    private void Awake()
    {
        textUI = GetComponent<Text>();
        timer = 0;
    }
    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
        textUI.text = String.Format("{0:0.0}", Timer);
    }

}
