using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour
{

    [SerializeField] PlayerLife playerLife;
    void OnTriggerEnter2D()
    {
        playerLife.Die();
    }
}
