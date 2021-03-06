﻿using UnityEngine;
using System.Collections;

//Enhairatense... 
//feel a little cheap using the nav stuff for inheritance ande poly, but why make more work
public class Wander : SteeringBehaviour {

    public float offset = 1f;
    public float radius = 1f;
    public float jitter = .2f;

    public Vector3 targetDir;
    public Vector3 randomDir;

    //overrides inherited function 
    //(next i play my Polymerisation card, and i use it to fuse 2 of my scripts to create... an override function)
    public override Vector3 GetForce() {

        Vector3 force = Vector3.zero;

        float randX = Random.Range(0, 0xfff) - (0xfff * .5f);
        float randZ = Random.Range(0, 0xfff) - (0xfff * .5f);

        #region Calculate Random Dir

        // Create the random direction vector
        randomDir = new Vector3(randX, 0, randZ);

        // Normalize the random direction
        randomDir = randomDir.normalized;

        // Multiply jitter to randomDir
        randomDir *= jitter;

        #endregion

        #region Calculate Target Dir

        // Append target dir with randomDir
        targetDir += randomDir;

        // Normalize the target dir
        targetDir = targetDir.normalized;

        // Amplify it by the radiuss
        targetDir *= radius;

        #endregion
        //calculate seek position using targetDir
        Vector3 seekPos = transform.position + targetDir;
        seekPos += transform.forward.normalized * offset;

        #region Wander

        // Calculate direction
        Vector3 direction = seekPos - transform.position;

        // Is direction valid? (not zero)
        if (direction.magnitude > 0) {

            //Calculate force
            Vector3 desiredForce = direction.normalized * weighting;
            force = desiredForce - owner.velocity;
        }

        #endregion

        return force;
    }
}