using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    [SerializeField] private GameObject character;

    [SerializeField] private Vector3 velocity;

    [SerializeField] private float speed;
    [SerializeField] private Vector3 orientation;
    [SerializeField] private Vector3 target;
    [SerializeField] private float maxRotation;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
        maxRotation = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = speed * new Vector3(-Mathf.Sin(Mathf.Deg2Rad * orientation.z), Mathf.Cos(Mathf.Deg2Rad * orientation.z), 0);

        character.transform.position += velocity * Time.deltaTime;

        orientation.z += RandomBinomial();
        character.transform.eulerAngles = orientation;

        StayInBounds();
    }

    public void StayInBounds()
    {
        if ( character.transform.position.x > 8 || character.transform.position.x < -8)
        {
            orientation.z = -orientation.z;
        }
        if( character.transform.position.y > 4 || character.transform.position.y < -4)
        {
            orientation.z += 45.0f;
        }
    }
    public float RandomBinomial()
    {
        return (Random.Range(0.0f, 1.0f) - Random.Range(0.0f, 1.0f)) * maxRotation;
    }
}
