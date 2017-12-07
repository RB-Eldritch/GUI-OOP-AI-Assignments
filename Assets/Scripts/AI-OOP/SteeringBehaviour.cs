using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AIAgent))]
public class SteeringBehaviour : MonoBehaviour {

    public float weighting = 7.5f;

    [HideInInspector]
    public AIAgent owner;

    //get the AIAgent component (overrideable... oooh look, polymorphism)
    protected virtual void Awake() {

        owner = GetComponent<AIAgent>();
    }

    //set force to zero (overrideable... and yet more polymorphism)
    public virtual Vector3 GetForce() {

        return Vector3.zero;
    }
}