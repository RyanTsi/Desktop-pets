using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Action : MonoBehaviour
{
    public Button touchButton;

    public Button feedButton;

    public static int index;

    private int value;
    private DateTime lastTime;
    // Start is called before the first frame update
    void Start()
    {
        touchButton.onClick.AddListener(touchAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void touchAction()
    {
        var random = new Random();
    }
}
