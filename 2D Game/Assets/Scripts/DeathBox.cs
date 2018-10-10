﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathBox : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.name == "pc")
        {
            Debug.Log("Player Enters Death Zone");
            Destroy(other);
        }

    }
}
