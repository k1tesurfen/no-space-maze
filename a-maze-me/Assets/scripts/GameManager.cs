using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject laser;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        (Instantiate(laser) as GameObject).GetComponent<Laser>().StartLaser(new Vector3(-10, Random.Range(1f, 2f), 0), 20f, new Vector3(1, 0, 0), 0.4f);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            //this line will instanciate the prefab and then 
            //call the StartLaser-Method from the script that is attatched to the prefab
            (Instantiate(laser) as GameObject).GetComponent<Laser>().StartLaser(new Vector3(-10, Random.Range(1f, 2f), 0), 20f, new Vector3(1, 0, 0), 0.4f);
            timer = 0f;
        }
    }
}
