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
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }
    // Start is called before the first frame update

    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        //移動先が範囲外なら移動不可
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //移動先に２が居たら
        if (map[moveTo] == 2)
        {
            //どの方向へ移動するかを算出
            int velocity = moveTo - moveFrom;
            //プレイヤーの移動先から、さらに先へ２を移動させる
            //箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを
            //呼び、処理が再帰している。移動可不可をboolで記録
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //もし箱が移動失敗したらプレイヤーの移動も失敗
            if (!success) { return false; }
        }
        //プレイヤー・箱関わらずの移動処理
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    void Start()
    {
        map = new int[] { 0, 0, 2, 1, 0, 0, 2, 2, 0, 0 };

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
        int playerIndex = GetPlayerIndex();

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

            //if (playerIndex < map.Length - 1)
            //{
            //    map[playerIndex + 1] = 1;
            //    map[playerIndex] = 0;
            //    string debugText = "";
            //    for (int i = 0; i < map.Length; i++)
            //    {
            //        //変更。文字列に結合していく
            //        debugText += map[i].ToString() + ",";
            //    }

            //}
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //ここに移動処理をかく
            //playerIndex+1のインデックスの物と交換するので、
            //playerIndex-1よりさらに小さいインデックスの時
            //のみ交換処理を行う
            //if (playerIndex > 0)
            //{
            //    map[playerIndex - 1] = 1;
            //    map[playerIndex] = 0;
            //    string debugText = "";
            //    for (int i = 0; i < map.Length; i++)
            //    {
            //        //変更。文字列に結合していく
            //        debugText += map[i].ToString() + ",";
            //    }


            //}
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }
}