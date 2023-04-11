using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public DistanceJoint2D distanceJoint1, distanceJoint2;
    public Transform[] tr;
    public LineRenderer currentLineRenderer;
    public GameObject brush;
    public Camera mCamera;
    public LayerMask layerMask;

    public float maxLength = 5;
    public int reflections = 1;

    private Ray2D ray;
    private RaycastHit2D hit;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        if (!Input.GetKey(KeyCode.S))
        {
            distanceJoint1.connectedBody = null;
            distanceJoint2.connectedBody = null;
        }

        if (Input.GetKey(KeyCode.S))
        {
            currentLineRenderer.positionCount = 1;
            currentLineRenderer.SetPosition(0, transform.position);
            float remainingLength = maxLength;


            for (int i = 0; i < reflections; i++)
            {


                hit = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, layerMask);

                foreach (var t in tr)
                {
                    float distance = Vector2.Distance(transform.position, t.position);
                    if (distance < 5)
                    {
                        

                        float dist1 = Vector2.Distance(transform.position, tr[0].position);
                        float dist2 = Vector2.Distance(transform.position, tr[1].position);


                        if (dist1 < dist2)
                        {
                         
                           distanceJoint1.breakForce = dist1*2;
                            distanceJoint1.connectedBody = rigidbody2D;
                            rigidbody2D.AddForce(new Vector2(5,0));


                        }
                        if (dist2 < dist1)
                        {

                            distanceJoint2.breakForce = dist2*2;
                            distanceJoint2.connectedBody = rigidbody2D;
                            rigidbody2D.AddForce(new Vector2(5, 0));

                        }


                        ray = new Ray2D(t.position, transform.up);


                        if (hit)
                        {
                            Vector2 updatedDirection = Vector2.Reflect(ray.direction, hit.normal);

                          

                            ray = new Ray2D(hit.point + updatedDirection * 0.01f, updatedDirection);

                            currentLineRenderer.positionCount += 1;
                            currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, hit.point);
                            remainingLength -= Vector2.Distance(ray.origin, hit.point);
                            ray = new Ray2D(hit.point, Vector2.Reflect(ray.direction, hit.normal));
                            if (hit.collider.tag != "Reflect")
                                break;
                        }
                        else
                        {
                            currentLineRenderer.positionCount += 1;
                            currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);

                            
                        }
                    }
                }

            }
           
        }
       
    }
     
}
