using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] Transform previousroom;
    [SerializeField] Transform nextroom;
    [SerializeField] cameracontroller cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.movetonewroom(nextroom);
                new Vector3(0,transform.position.y,transform.position.z);
            }
            else
                cam.movetonewroom(previousroom); 
        }
    }
}
