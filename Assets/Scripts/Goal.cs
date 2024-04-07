using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Action<bool> callback;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        callback(true);
    }


}
