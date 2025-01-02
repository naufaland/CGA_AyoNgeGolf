using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    Animator flagAnimator;

    private void OnTriggerUp(Collider other)
    {
        flagAnimator.SetBool("isFlagUp", true);
    }
    private void OnTriggerDown(Collider other)
    {
        flagAnimator.SetBool("isFlagUp", false);
    }
    void Awake()
    {
        flagAnimator = GetComponent<Animator>();
    }
}
