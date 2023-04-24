using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    //配列の宣言
    int[] map;

    void PrintArray()
    {
        string debugText = "";
        for(int i=0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
        PrintArray();
        //Debug.Log("Hello World");
        //for(int i = 0; i < map.Length; i++)
        //{
        //    Debug.Log(map[i]+",");
        //}

        //追加。文字列の宣言と初期化
      
    }

    // Update is called once per frame
    void Update()
    {
        //見つからなかった時の為に-1で初期化
        int playerIndex = -1;
        
        //デバックログの出力
        //要素数はmap.Lengthで取得
        for (int i = 0; i < map.Length; ++i)
        {
            if (map[i] == 1)
            {
                playerIndex = i;
                break;
            }
        }
        //Update is called once per frame
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //ここに移動処理をかく
            //playerIndex+1のインデックスの物と交換するので、
            //playerIndex-1よりさらに小さいインデックスの時
            //のみ交換処理を行う
            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
                string debugText = "";
                for (int i = 0; i < map.Length; i++)
                {
                    //変更。文字列に結合していく
                    debugText += map[i].ToString() + ",";
                }
                Debug.Log(debugText);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //ここに移動処理をかく
            //playerIndex+1のインデックスの物と交換するので、
            //playerIndex-1よりさらに小さいインデックスの時
            //のみ交換処理を行う
            if (playerIndex > 0)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
                string debugText = "";
                for (int i = 0; i < map.Length; i++)
                {
                    //変更。文字列に結合していく
                    debugText += map[i].ToString() + ",";
                }
                Debug.Log(debugText);
            }
        }
    }
}
