using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    private Vector3[] intialposition;


    private void Awake()
    {
        //save the posions of enimies
        intialposition = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
                intialposition[i] = enemies[i].transform.position;
        }
    }
    public void activeroom(bool _status)
    {
        //activating and deactivatint the enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null)
            {
                enemies[i].SetActive(_status);
                enemies[i].transform.position = intialposition[i];
            }
        }
    }

}
