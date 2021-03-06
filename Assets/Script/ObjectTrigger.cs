﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{

    bool[] items = new bool[8]; //인덱스 0~3까지 귀신 쪽지, 나머지는 일반 아이템들

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider col)
    {
        // 클릭했을 때 처리, 아이템일 경우와, 단순한 오브젝트일 경우

        GameObject go = col.gameObject;

        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼 클릭 했을 때
        {

            if (go.CompareTag("item")) // trigger가 일어난(충돌한) 오브젝트의 태그명이 item일 때
            {
                items[int.Parse(go.name)] = true; // 아이템의 이름을 인덱스로 설정해줘서 그 인덱스대로 아이템을 얻으면 true값을 넣어줌
                go.SetActive(false); // 아이템을 가지고 간 것처럼 보이기 위해 아이템 오브젝트를 화면상에서 그리지 않음
                UnityEngine.Debug.Log(items[int.Parse(go.name)]);
            }
            else if (go.CompareTag("useitem")) //아이템이 아니고 아이템과 상호작용을 하는 오브젝트(태그가 useitem)일 경우
            {

                if (items[go.GetComponent<State>().itemnum] == true) // 그 아이템을 소지하고 있다면.
                {
                    if (go.GetComponent<State>().use == false)
                    {
                        go.GetComponent<State>().use = true; // 아이템을 사용한 상태로 바꿔줌
                        UnityEngine.Debug.Log("아이템 사용완료");
                    }
                    else
                    {
                        UnityEngine.Debug.Log("이미 아이템을 사용했다.");
                    }
                }
                else
                {
                    UnityEngine.Debug.Log("해당 아이템이 없음.");
                }

            }
        }


    }
}
