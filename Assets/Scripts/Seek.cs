using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private List<Vector3> targets;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector3 orientation;

    [SerializeField] private float speed;

    [SerializeField] private int current;

    private void Start()
    {
        targets = new List<Vector3>();
        current = 0;
        speed = 3.0f;

        targets.Add(new Vector3(7.0f, -4.0f, 0.0f));
        targets.Add(new Vector3(7.0f, 4.0f, 0.0f));
        targets.Add(new Vector3(-7.0f, 4.0f, 0.0f));
        targets.Add(new Vector3(-7.0f, -4.0f, 0.0f));
    }
    private void Update()
    {
        velocity = targets[current] - character.transform.position;
        velocity.Normalize();
        velocity *= speed;

        character.transform.position += velocity * Time.deltaTime;

        NewOrientation(velocity);
        character.transform.eulerAngles = orientation;

      
        if (Mathf.Round(targets[current].x * 10.0f) == Mathf.Round(character.transform.position.x * 10.0f)
            && Mathf.Round(targets[current].y * 10.0f) == Mathf.Round(character.transform.position.y * 10.0f))
        {
            current++;
            if(current > 3)
            {
                current = 0;
            }
        }
    }

    public void NewOrientation(Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            orientation.z = Mathf.Atan2(-velocity.x, velocity.y) * Mathf.Rad2Deg;
        }
    }
}
