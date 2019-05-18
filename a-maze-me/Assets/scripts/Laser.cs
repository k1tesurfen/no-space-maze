using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //position where the laser will start.
    public Vector3 startPosition;

    //Distance, the laser will travel before destruction
    public float travelDistance;

    //Direction in which the laser should move ( (1,0,0) or (0,0,1) is recommended)
    public Vector3 movingDirection;

    //The speed in which the laser will move
    public float movingSpeed;

    //Startpoint of the laserbeam
    private Vector3 laserStart;

    //Endpoint of the laserbeam
    private Vector3 laserEnd;
    LineRenderer lr;
    bool laserCreated = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLaser();
    }

    public void UpdateLaser()
    {
        if (laserCreated)
        {
            //we decrease the traveldistance every frame and destroy the laser if it is below 0
            if (travelDistance < 0)
            {
                DestroyLaser();
            }

            //set new position of the gameobject which holds the laser
            gameObject.transform.position = transform.position + movingSpeed * movingDirection;

            //set new start and endpositions for the laserbeam
            laserStart = laserStart + movingSpeed * movingDirection;
            laserEnd = laserEnd + movingSpeed * movingDirection;
            lr.SetPosition(0, laserStart);
            lr.SetPosition(1, laserEnd);

            //decrease distance, which the laser is allowed to travel
            travelDistance -= movingSpeed;
        }
    }
    public void StartLaser(Vector3 start, float distance, Vector3 direction, float speed)
    {
        //set the global variables of this gameobject
        this.startPosition = start;
        this.movingDirection = direction;
        this.movingSpeed = speed;
        this.travelDistance = distance;

        //get the line renderer component of this gameobject
        lr = gameObject.GetComponent<LineRenderer>();

        //set the startposition and the laser beam start and endpoints
        gameObject.transform.position = startPosition;
        laserStart = start + (500 * (Quaternion.AngleAxis(90, Vector3.up) * direction));
        laserEnd = start + (-500 * (Quaternion.AngleAxis(90, Vector3.up) * direction));

        //enable the linerenderer to make it visible
        lr.enabled = true;
        laserCreated = true;
    }

    public void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
