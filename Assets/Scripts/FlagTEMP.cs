using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTEMP : MonoBehaviour
{
    public event Action TriggerEndLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var triggerEndLevel = collision.GetComponent<KidMovement>();

        if (triggerEndLevel != null)
        {
            Debug.Log("You have completed this level!!!");

            TriggerEndLevel?.Invoke();
        }
    }
}
