using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhoRival : MonoBehaviour
{
    [SerializeField] public Transform[] allwayPoints;
    [SerializeField] public float rotationSpeed = 0.5f;
    [SerializeField] public float acceleration = 0.1f;
    [SerializeField] public float maxSpeed = 1f;
    [SerializeField] public int currentTarget;

    private float movementSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotate();
        ChangeTarget();
    }

    void Movement()
    {
        if (movementSpeed < maxSpeed)
        {
            movementSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            movementSpeed = maxSpeed;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            allwayPoints[currentTarget].position,
            movementSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(allwayPoints[currentTarget].position - transform.position),
            rotationSpeed * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (transform.position == allwayPoints[currentTarget].position)
        {
            currentTarget++;
            currentTarget = currentTarget % allwayPoints.Length;
        }
    }
}
