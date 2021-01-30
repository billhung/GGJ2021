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

    // Start is called before the first frame update
    void Start()
    {
        C = 0f;
        countup1 = 0;
        countup2 = 0;
        text = GetComponent<Text>();
}

    // Update is called once per frame
    void Update()
    {
        C += Time.deltaTime;
        if(C >= 60)
        {
            C = 0f;
            countup2++;
        }
        countup1 = (int)C;
        text.text = countup2.ToString("D2") + ":" + countup1.ToString("D2");
    }

    public void D()
    {
        Debug.Log(C.ToString() + "//"+ countup2.ToString()+ " : " + countup1.ToString());
    }
}
