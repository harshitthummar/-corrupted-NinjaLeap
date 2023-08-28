using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    //roomcamera
    [SerializeField] private float speed;
    private float currentposx;
    private Vector3 velocity = Vector3.zero;

    //follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheaddistance;
    [SerializeField] private float camspeed;
    private float lookahead;

    private void Update()
    {
        //room camera movement
        //transform.position = Vector3.SmoothDamp(transform.position,new Vector3(currentposx,transform.position.y,transform.position.z),ref velocity,speed * Time.deltaTime);

        transform.position = new Vector3(player.position.x + lookahead,transform.position.y,transform.position.z);
        Mathf.Lerp(lookahead, (aheaddistance * player.localScale.x),Time.deltaTime * camspeed);
    }
    public void movetonewroom(Transform _newroom)
    {
        currentposx = _newroom.position.x;
    }
}
