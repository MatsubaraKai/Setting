using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    //�z��̐錾
    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        //�z��̎��Ԃ̍쐻�Ə�����
        map = new int[] {0,0,0,1,0,0,0,0,0,0};
        //�f�o�b�N���O�̏o��
        //Debug.Log("Hello World");
        //for(int i = 0; i < map.Length; i++)
        //{
        //    Debug.Log(map[i]+",");
        //}

        //�ǉ��B������̐錾�Ə�����
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            //�ύX�B������Ɍ������Ă���
            debugText += map[i].ToString() + ",";
        }
        //����������������o��
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        //������Ȃ��������ׂ̈�-1�ŏ�����
        int playerIndex = -1;
        //�v�f����map.Length�Ŏ擾
        for (int i = 0; i < map.Length; i++)
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
            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
                string debugText = "";
                for (int i = 0; i < map.Length; i++)
                {
                    //�ύX�B������Ɍ������Ă���
                    debugText += map[i].ToString() + ",";
                }
                Debug.Log(debugText);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //�����Ɉړ�����������
            //playerIndex+1�̃C���f�b�N�X�̕��ƌ�������̂ŁA
            //playerIndex-1��肳��ɏ������C���f�b�N�X�̎�
            //�̂݌����������s��
            if (playerIndex < map.Length + 1)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
                string debugText = "";
                for (int i = 0; i < map.Length; i++)
                {
                    //�ύX�B������Ɍ������Ă���
                    debugText += map[i].ToString() + ",";
                }
                Debug.Log(debugText);
            }
        }
    }
}
