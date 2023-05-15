using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
  
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    //配列の宣言
    int[,] map;
    GameObject[,] field;

    void PrintArray()
    {
        //string debugText = "";
        //for (int i = 0; i < map.Length; i++)
        //{
        //    debugText += map[i].ToString() + ",";
        //}
        //Debug.Log(debugText);
    }
    // Start is called before the first frame update

    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player") { return new Vector2Int(x, y); }
            }
        }
        return new Vector2Int(-1, -1);
    }

    bool MoveNumber(string tag, Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }

        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveNumber(tag, moveTo, moveTo + velocity);
            if (!success) { return false; }
        }
        field[moveFrom.y, moveFrom.x].transform.position =
            new Vector3(moveTo.x, field.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        return true;
    }

    void Start()
    {
        ////Objectを中央にやるためのプログラム
        //GameObject instance = Instantiate(
        //    playerPrefab,
        //    new Vector3(0, 0, 0),
        //    Quaternion.identity
        //    );

        map = new int[,] {
            { 0,0,0,0,0},
            { 0,0,1,0,0},
            { 0,0,2,0,0},
            { 0,2,0,2,0},
            { 0,0,0,0,0},
        };
        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }

            }
        }
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 2)
                {
                    field[y, x] = Instantiate(
                        boxPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0),
                        Quaternion.identity
                        );
                }

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの位置の取得
        Vector2Int playerMoveFrom = GetPlayerIndex();
        Vector2Int playerMoveTo = playerMoveFrom + new Vector2Int(0, 0);

        ////クリアしてないとき移動できる
        //if (IsCleard() != true)
        //{
        //右キーを押したとき
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerMoveTo = playerMoveFrom + new Vector2Int(1, 0);
            //プレイヤーの移動
            MoveNumber("Player", playerMoveFrom, playerMoveTo);
        }
        //左キーを押したとき
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerMoveTo = playerMoveFrom + new Vector2Int(-1, 0);
            //プレイヤーの移動
            MoveNumber("Player", playerMoveFrom, playerMoveTo);
        }
        //上キーを押したとき
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerMoveTo = playerMoveFrom + new Vector2Int(0, -1);
            //プレイヤーの移動
            MoveNumber("Player", playerMoveFrom, playerMoveTo);
        }
        //下キーを押したとき
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerMoveTo = playerMoveFrom + new Vector2Int(0, 1);
            //プレイヤーの移動
            MoveNumber("Player", playerMoveFrom, playerMoveTo);
        }
        //その他
        else { }
        //}
        ////クリアした時
        //else if (IsCleard())
        //{
        //    //ゲームオブジェクトのSetActiveメソッドを使い有効化
        //    clearText.SetActive(true);
        //}
    }
}
   