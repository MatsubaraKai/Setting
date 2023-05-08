using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    //�z��̐錾
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
        //�ړ��悪�͈͊O�Ȃ�ړ��s��
        if (moveTo < 0 || moveTo >= map.Length)
        {
            return false;
        }
        //�ړ���ɂQ��������
        if (map[moveTo] == 2)
        {
            //�ǂ̕����ֈړ����邩���Z�o
            int velocity = moveTo - moveFrom;
            //�v���C���[�̈ړ��悩��A����ɐ�ւQ���ړ�������
            //���̈ړ������BMoveNumber���\�b�h����MoveNumber���\�b�h��
            //�ĂсA�������ċA���Ă���B�ړ��s��bool�ŋL�^
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //���������ړ����s������v���C���[�̈ړ������s
            if (!success) { return false; }
        }
        //�v���C���[�E���ւ�炸�̈ړ�����
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

        //�ǉ��B������̐錾�Ə�����

    }

    // Update is called once per frame
    void Update()
    {
        //������Ȃ��������ׂ̈�-1�ŏ�����
        int playerIndex = GetPlayerIndex();

        //�f�o�b�N���O�̏o��
        //�v�f����map.Length�Ŏ擾
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
            //�����Ɉړ�����������
            //playerIndex+1�̃C���f�b�N�X�̕��ƌ�������̂ŁA
            //playerIndex-1��肳��ɏ������C���f�b�N�X�̎�
            //�̂݌����������s��

            //if (playerIndex < map.Length - 1)
            //{
            //    map[playerIndex + 1] = 1;
            //    map[playerIndex] = 0;
            //    string debugText = "";
            //    for (int i = 0; i < map.Length; i++)
            //    {
            //        //�ύX�B������Ɍ������Ă���
            //        debugText += map[i].ToString() + ",";
            //    }

            //}
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //�����Ɉړ�����������
            //playerIndex+1�̃C���f�b�N�X�̕��ƌ�������̂ŁA
            //playerIndex-1��肳��ɏ������C���f�b�N�X�̎�
            //�̂݌����������s��
            //if (playerIndex > 0)
            //{
            //    map[playerIndex - 1] = 1;
            //    map[playerIndex] = 0;
            //    string debugText = "";
            //    for (int i = 0; i < map.Length; i++)
            //    {
            //        //�ύX�B������Ɍ������Ă���
            //        debugText += map[i].ToString() + ",";
            //    }


            //}
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();
        }
    }
}