﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{
public GameObject nextMaze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        nextMaze.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
