using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

//Inherits of of SteeringBehaviour (oh wow, Inheritance... i love that book series)
public class PathFollowing : SteeringBehaviour {

    //the target we are seeking
    public Transform target;

    //how big the node is
    public float nodeRadius = .1f;

    //the size of the final node in the path
    public float targetRadius = 3f;

    //the... current node
    public int currentNode = 0;

    //has the agent reached the destination
    public bool isAtTarget = false;

    private NavMeshAgent nav;

    //stores the path that the nav generates
    private NavMeshPath path;

    private void Start() {

        nav = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    Vector3 Seek(Vector3 target) {

        Vector3 force = Vector3.zero;

        //how far away is the target
        Vector3 desiredForce = target - transform.position;

        //get distance
        float distance = isAtTarget ? targetRadius : nodeRadius;

        if (desiredForce.magnitude > distance) {

            //modify force using weighting
            desiredForce = desiredForce.normalized * weighting;

            //replace agents velocity with our calculated velocity
            force = desiredForce - owner.velocity;
        }

        //return of the jed-... force
        return force;
    }

    //override inherited function (polymorphism: part deux)
    public override Vector3 GetForce() {

        Vector3 force = Vector3.zero;

        //return force if there is no target
        if (target == null)
            return force;

        //if the nav agent calculated a path
        if (nav.CalculatePath(target.position, path)) {

            //if the path is finished
            if (path.status == NavMeshPathStatus.PathComplete) {

                //does the path have corners... seems like an odd question out of context
                Vector3[] corners = path.corners;

                //if there are corners
                if (corners.Length > 0) {

                    int lastIndex = corners.Length - 1;

                    //if we at the end of the array
                    if (currentNode >= corners.Length) {

                        //cap currentnode to the end of the array
                        currentNode = lastIndex;
                    }

                    //get the position of the current corner node
                    Vector3 currentPos = corners[currentNode];

                    //get distance to the currentNode
                    float distance = Vector3.Distance(transform.position, currentPos);

                    //if the distance is within the radius of the node
                    if (distance <= nodeRadius) {

                        //next node
                        currentNode++;
                    }

                    // Is the agent at the target?
                    float distanceToTarget = Vector3.Distance(transform.position, target.position);
                    isAtTarget = distanceToTarget <= targetRadius;

                    // Seek towards current node
                    force = Seek(currentPos);
                }
            }
        }

        return force;
    }
}