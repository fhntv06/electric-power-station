using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GlobalInputController : MonoBehaviour
{
    [Header("Variable move player")]
    public static KeyCode forward = KeyCode.W;
    public static KeyCode right = KeyCode.D;
    public static KeyCode left = KeyCode.A;
    public static KeyCode back = KeyCode.S;
    public static KeyCode speedUp = KeyCode.LeftShift;
    public static KeyCode activePauseWindow = KeyCode.Escape;
}
