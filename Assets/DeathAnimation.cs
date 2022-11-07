using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathAnimation : MonoBehaviour
{
    public UnityEvent animFinished;

    private void Awake()
    {
        if (animFinished == null)
            animFinished = new UnityEvent();
    }
    public void OnAnimationEnded()
    {
        Destroy(gameObject);
    }
}
