using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlobalInputController : MonoBehaviour
{
    [Header("Variable move player")]
    // static - позволяет обращаться к переменным в любом месте кода
    // default keys
    public static KeyCode forward = KeyCode.W;
    public static KeyCode right = KeyCode.D;
    public static KeyCode left = KeyCode.A;
    public static KeyCode back = KeyCode.S;
    public static KeyCode speedUp = KeyCode.LeftShift;
    public static KeyCode activePauseWindow = KeyCode.Escape;
     
    /*
    public static string forward = "W";
    public static string right = "d";
    public static string left = "a";
    public static string back = "s";
    public static string speedUp = "Left shift key";
    public static string activePauseWindow = "Escape";
    */
}
