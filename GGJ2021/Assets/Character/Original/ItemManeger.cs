﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManeger : MonoBehaviour
{
    /*
    private const int FaseNum = 3;
    [SerializeField] public GameObject[] F_1 = new GameObject[FaseNum];
    [SerializeField] public GameObject[] F_2 = new GameObject[FaseNum];
    [SerializeField] public GameObject[] F_3 = new GameObject[FaseNum];
    */
    [SerializeField] public GameObject[] F;
    [SerializeField] public int ItemNum;
    //private bool[] F_Num = new bool[FaseNum];
    private int F_Now;
    private bool F_Swiche;
    private int F_Count;
    private bool F_Clear;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //アイテムをすべて見えなくする
        for(int i = 0; i < F_1.Length; i++)
        {
            F_1[i].SetActive(false);
            F_2[i].SetActive(false);
            F_3[i].SetActive(false);
        }
        */
        //登録されている落とし物をすべて削除する
        Debug.Log(F.Length);
        for(int i = 0; i < F.Length; i++)
        {
            F[i].SetActive(false);
        }

        //現在のフェーズを管理する
        F_Now = 0;
        F_Swiche = true;
        //F_Count = FaseNum;
        F_Count = 0;//+で獲得量を管理
        F_Clear = false;


        for (int i = 0; i < ItemNum; i++)
        {
            int R = Random.Range(0, F.Length);
            Debug.Log(R);
            if(F[R].activeInHierarchy == false)
            {
                F[R].SetActive(true);
            }
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        /*
        //F_Swicheがtureならフェーズを次に進める
        if (F_Swiche)
        {
            F_1[F_Now].SetActive(true);
            F_2[F_Now].SetActive(true);
            F_3[F_Now].SetActive(true);
            F_Now++;
            F_Swiche = false;
        }
        
        //アイテムを3つとったときの対応
        if(F_Count == 0)
        {
            F_Swiche = true;
            F_Count = FaseNum;
            //3フェーズ以降進まないようにする
            if(F_Now >= FaseNum)
            {
                F_Swiche = false;
                F_Clear = true;
            }
        }
        */
    }

    //アイテムを獲得するごとに呼ぶ
    public void GetItem()
    {
        F_Count++;
        Debug.Log(F_Count);
    }

    public void GoRisult(bool gole)
    {
        /*
        if (gole)
        {
            //アイテムを全部取得している　かつ　第3フェーズである
            if(F_Count == 0 && F_Clear)
            {
                SceneManager.LoadScene("Usually");
            }
            else
            {
                SceneManager.LoadScene("Fool");
            }
        }
        else
        {//会社にたどり着けない
            SceneManager.LoadScene("04_End1_TimeOver");
        }
        */
        if (gole)
        {
            //アイテムを全部取得している　かつ　第3フェーズである
            if (F_Count >= ItemNum)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                SceneManager.LoadScene(4);
            }
        }
        else
        {//会社にたどり着けない
            SceneManager.LoadScene(3);
        }
    }
}
