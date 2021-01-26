using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFlee : MonoBehaviour
{
    public Transform target;
    public float maxSpeed = 7f;

    void Update()
    {
        KinematicSteeringOutput Steering = getSteering();
        transform.position += Steering.velocity * Time.deltaTime;
    }

    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = this.transform.position - target.position;

        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        float orientationAngle = newOrientation(transform.eulerAngles.y, result.velocity);
        this.transform.eulerAngles = new Vector3(0, orientationAngle * (180 / Mathf.PI), 0);

        result.rotation = 0;
        return result;
    }

    public float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
            return Mathf.Atan2(velocity.x, velocity.z);
        else
            return current;
    }
}
