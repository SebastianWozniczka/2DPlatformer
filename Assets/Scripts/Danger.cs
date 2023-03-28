using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    private GameObject eye;

     void Start()
    {
        eye = GameObject.FindWithTag("eye");
    }

     void OnTriggerEnter2D()
    {
        eye.GetComponent<Transform>().localScale = new Vector2(1.5f, 1.5f);
    }
  void OnTriggerExit2D()
    {
        eye.GetComponent<Transform>().localScale = new Vector2(1f, 1f);
    }



}
