using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekSteering : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject target;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 orientation;

    [SerializeField] private float speed;
    [SerializeField] private float maxAcceleration;

    private void Start()
    {
        speed = .2f;
        maxAcceleration = .1f;
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

        direction = target.transform.position - character.transform.position;
        direction.Normalize();
        direction *= maxAcceleration;

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