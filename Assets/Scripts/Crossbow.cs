using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public GameObject arrow;
    public Transform dest;

    public float rotZ;
    private float z;
    private float tr;
    private float timer;
   
    void Start()
    {   
        timer = 0;
    } 
    void Update()
    {
        timer += Time.deltaTime;
        rotZ = transform.localEulerAngles.z;
        tr = rotZ + 180;

        if (timer > 7)
        {
          GameObject ga = Instantiate(arrow, dest.position, Quaternion.Euler(0,0,tr));
          Rigidbody2D rb = ga.GetComponent<Rigidbody2D>();
          rb.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
           
          timer = 0;
        }

        if (rotZ > 240 || rotZ < 300)
            z = 0.1f;

        if (rotZ < 240 || rotZ > 300)
        {
            z = 0.1f;
        }
        rotZ += z;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
    }
}
