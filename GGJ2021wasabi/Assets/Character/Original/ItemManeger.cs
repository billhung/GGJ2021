using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManeger : MonoBehaviour
{
    private const int FaseNum = 3;
    [SerializeField] public GameObject[] F_1 = new GameObject[FaseNum];
    [SerializeField] public GameObject[] F_2 = new GameObject[FaseNum];
    [SerializeField] public GameObject[] F_3 = new GameObject[FaseNum];
    private bool[] F_Num = new bool[FaseNum];
    private int F_Now;
    private bool F_Swiche;
    private int F_Count;

    // Start is called before the first frame update
    void Start()
    {
        //アイテムをすべて見えなくする
        for(int i = 0; i < F_1.Length; i++)
        {
            F_1[i].SetActive(false);
            F_2[i].SetActive(false);
            F_3[i].SetActive(false);
        }

        //現在のフェーズを管理する
        F_Now = 0;
        F_Swiche = true;
        F_Count = FaseNum;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
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
                F_Count = -1;
            }
        }
    }

    //アイテムを獲得するごとに呼ぶ
    public void GetItem()
    {
        F_Count--;
    }
}
