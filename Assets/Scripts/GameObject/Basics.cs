using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class Basics : MonoBehaviour
{

// массив игровых объектов
  public GameObject[] arCube = new GameObject[3];
  public Transform[] transforms = new Transform[3];
  public GameObject cube;
  public Transform transformCube;

  public Light _light; 

  public void Start() {
    // cube.SetActive(false);
    
    // обращение к компоненту объекта
    // cube.GetComponent<Transform>().position = new Vector3(10, 20, 30);
  }

  float x;
  
  async void Update () {
    x += Time.deltaTime * 10;
      
    for(int i = 0; i < transforms.Length; i++ ) {
      transforms[i].rotation = Quaternion.Euler(x,x*1.2f,0);
    }

    // cube.GetComponent<Transform>().rotation = Quaternion.Euler(x,0,0);

    transformCube.rotation = Quaternion.Euler(x,0,0);

    timeDay();
  }


  float intensity = 0;
  bool direction = true;
  public void timeDay() {
    // от 0 до 1
    if ( intensity <= 0 ) {
      direction = true;
    }

    // от 1 до 0
    if ( intensity >= 1 ) {
      direction = false;
    } 

    if ( direction ) {
      intensity += Time.deltaTime / 10;
    } else {
      intensity -= Time.deltaTime / 10;
    }

    _light.intensity = intensity;
  }
}
