using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector3 targetVelocity;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 orientation;
    [SerializeField] private Vector3 linear;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxAcceleration;

    private float targetRadius;
    private float slowRadius;

    private float timeToTarget;
    private float distance;

    private void Start()
    {
        speed = .2f;
        maxSpeed = 1f;
        maxAcceleration = .1f;
        targetRadius = 3.0f;
        slowRadius = 15.0f;
        timeToTarget = 3.0f;
    }
    private void Update()
    {
        velocity += direction * Time.deltaTime;

        if (velocity.magnitude > speed)
        {
            velocity.Normalize();
            velocity *= speed;
        }

        //Update position and velocity
        character.transform.position += velocity;

        //Get the direction to the target
        direction = target.transform.position - character.transform.position;
        distance = direction.magnitude;

        if(distance > slowRadius)
        {
            speed = maxSpeed;
        }
        else
        {
            speed = maxSpeed * distance / slowRadius;
        }

        targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= speed;

        linear = targetVelocity - velocity;
        linear /= timeToTarget;

        if(linear.magnitude > maxAcceleration)
        {
            linear.Normalize();
            linear *= maxAcceleration;
        }

        NewOrientation(velocity);
        character.transform.eulerAngles = orientation;
    }

    public void NewOrientation(Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            orientation.z = Mathf.Atan2(-velocity.x, velocity.y) * Mathf.Rad2Deg;
        }
    }
}