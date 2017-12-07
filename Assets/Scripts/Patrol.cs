using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathFollowing))]
public class Patrol : MonoBehaviour {

    private int currentPoint = 0;
    private PathFollowing pathFollowing;
    public List<Transform> patrolPoints;

    void Start() {

        pathFollowing = GetComponent<PathFollowing>();
    }

    // Update is called once per frame
    void Update() {

        //if there are patrol nodes
        if (patrolPoints.Count > 0) {

            //if the agent has reached the node
            if (pathFollowing.isAtTarget) {

                //set pathFollowing's currentNode to 0
                pathFollowing.currentNode = 0;
                currentPoint++;
            }

            int lastIndex = patrolPoints.Count - 1;

            //if the current point is set to, or somehow beyond the final node in the list
            if (currentPoint >= patrolPoints.Count) {

                //set to first node in list
                currentPoint = 0;
            }

            //point = current node in the list
            Transform point = patrolPoints[currentPoint];

            //set pathFollowings target to the node
            pathFollowing.target = point;
        }
    }
}
