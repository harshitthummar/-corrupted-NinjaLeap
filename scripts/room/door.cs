using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : room
{
    [SerializeField] Transform previousroom;
    [SerializeField] Transform nextroom;
    [SerializeField] cameracontroller cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<cameracontroller>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cam.movetonewroom(nextroom);
             //  nextroom.GetComponent<room>().activeroom(true);
              // previousroom.GetComponent<room>().activeroom(false);
            }
            else
            {
                cam.movetonewroom(previousroom);
              // previousroom.GetComponent<room>().activeroom(true);
              // nextroom.GetComponent<room>().activeroom(false);
              
            }
                 
        }
    }
}
