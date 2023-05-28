using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody[] AllRigidBodys;
    void Awake()
    {
        ChangeIsKinematic(true);
    }

    public void ChangeIsKinematic(bool state)
    {
        foreach (Rigidbody rigidbody in AllRigidBodys)
            rigidbody.isKinematic = state;
    }
}
