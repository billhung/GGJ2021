﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float C;
    public int countup1;
    public int countup2;

    private Text text;

    [SerializeField] public float TimerMax = 180;
    [SerializeField] public float CT;

    // Start is called before the first frame update
    void Start()
    {
        C = TimerMax;
        countup1 = (int)C % 60;
        countup2 = (int)C / 60;
        text = GetComponent<Text>();
        CT = 0;
}

    // Update is called once per frame
    void Update()
    {
        C -= Time.deltaTime;
        if(C >= 60)
        {
            countup1 = (int)C % 60;
            countup2 = (int)C / 60;
        }
        text.text = countup2.ToString("D2") + ":" + countup1.ToString("D2");
    }

    public void D()
    {
        Debug.Log(C.ToString() + "//"+ countup2.ToString()+ " : " + countup1.ToString());
    }
}