using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class Basics : MonoBehaviour
{

    public GameObject cube;

    public void Start() {
        cube.SetActive(false);
    }
    
//     // метод при удалении объекта на который скрипт повешен
//     public void OnDestroy()
//     {
//        Debug.Log("OnDestroy");
//     }
    
}
