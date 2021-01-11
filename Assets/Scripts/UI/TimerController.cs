using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    private float timer = 0;
    private Text textUI;

    public float Timer { get => timer; set => timer = value; }

    private void Awake()
    {
        textUI = GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
        textUI.text = Timer.ToString() ;
    }

}
