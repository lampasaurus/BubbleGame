using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollider : MonoBehaviour {
    BallData ballData;
    MoveToCenter mover;

    CircleCollider2D cCollider;
    GameObject center;

    public float diagonalDistance;
    public float straightDistance;
    

	void Start () {
        ballData = GetComponent<BallData>();
        mover = GetComponent<MoveToCenter>();
        center = GameObject.FindGameObjectWithTag("Player");
        cCollider = GetComponent<CircleCollider2D>();
        diagonalDistance = 1.2f;
        straightDistance = 1.2f;
	}

    private void Update()
    {

        if (mover.speed == 0 && ballData.type != -1)    //Only still balls, and not center
        {
            Collider2D[] chainColliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 1.1f);
            foreach (Collider2D collision in chainColliders)
            {
                GameObject colObject = collision.gameObject;
                if (colObject == gameObject) break; //Don't collide with yourself
                BallData colData = colObject.GetComponent<BallData>();
                if (colData != null)
                {
                    if (colData.type == ballData.type)
                    {

                        if (colData.type == ballData.type)
                        {
                            ballData.MergeChain(colData.chain);
                        }
                    }
                }
            }
        }
    }

    //Handles balls colliding
    //Stops ball, makes ball a trigger, and calls SnapToAdjacent to ajust the ball's position
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("enter Trigger");
        if (mover.speed < 0)
        {
            mover.speed = 0;
            if (other.tag == "Player")
            {
                //do stuff for hitting middle
                cCollider.isTrigger = true;
            }
            if (other.GetComponent<BallData>() != null)
            {
                //Do stuff for hitting other attached balls
                //BallData otherData = other.GetComponent<BallData>();
                cCollider.isTrigger = true;
            }
            //Stuff that always happens on collisions
            SnapToAdjacent(other);

            this.transform.parent = center.transform;
            //ballData.DebugChain();
        }
    }

    //Snaps the colliding ball to a visually correct distance from the ball it collided with
    private void SnapToAdjacent(Collider2D other)
    {
        float distanceMod = 1.1f;
        Vector3 mypos = this.transform.position;
        Vector3 opos = other.transform.position;
        Vector3 dirpos = mypos - opos;
        dirpos = dirpos.normalized;
        this.transform.position = other.transform.position + (dirpos * distanceMod);
        /*
        //right
        if (dirpos.x >= 0.8)  
        {
            this.transform.position = new Vector3(opos.x +  straightDistance, opos.y, opos.z);
        }
        //left
        else if (dirpos.x <= -0.8)
        {
            this.transform.position = new Vector3(opos.x -  straightDistance, opos.y, opos.z);
        }
        //up
        else if (dirpos.y >= 0.8)
        {
            this.transform.position = new Vector3(opos.x, opos.y +  straightDistance, opos.z);
        }
        //down
        else if (dirpos.y <= -0.8)
        {
            this.transform.position = new Vector3(opos.x, opos.y -  straightDistance, opos.z);
        }
        //up right
        else if ((dirpos.x < 0.8) && (dirpos.y < 0.8) && (dirpos.x > 0) && (dirpos.y > 0))
        {
            this.transform.position = new Vector3(opos.x +  diagonalDistance, opos.y +  diagonalDistance, opos.z);
        }
        //up left
        else if ((dirpos.x > -0.8) && (dirpos.y < 0.8) && (dirpos.x < 0) && (dirpos.y > 0))
        {
            this.transform.position = new Vector3(opos.x -  diagonalDistance, opos.y +  diagonalDistance, opos.z);
        }
        //down right
        else if ((dirpos.x < 0.8) && (dirpos.y > -0.8) && (dirpos.x > 0) && (dirpos.y < 0))
        {
            this.transform.position = new Vector3(opos.x + 1.0f, opos.y - 1.0f, opos.z);
        }
        //down left
        else if ((dirpos.x > -0.8) && (dirpos.y > -0.8) && (dirpos.x < 0) && (dirpos.y < 0))
        {
            this.transform.position = new Vector3(opos.x -  diagonalDistance, opos.y -  diagonalDistance, opos.z);
        }
        */
    }

}
