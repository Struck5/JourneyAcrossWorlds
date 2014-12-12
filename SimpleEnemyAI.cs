using UnityEngine;
using System.Collections;

public class SimpleEnemyAI : MonoBehaviour
{

    public float Distance;
    public Transform Target;
    public float lookAtDistance = 10.0f;
    public float followRange = 5.0f;
    public float moveSpeed = 1.0f;
    public float Damping = 6.0f;


    void Update()
    {
        Distance = Vector3.Distance(Target.position, transform.position);

        if (Distance < lookAtDistance && Distance > followRange)
        {
            renderer.material.color = Color.yellow;
        }
        if (Distance > lookAtDistance)
        {
            renderer.material.color = Color.white;
            lookAt();
        }
        if (Distance < followRange)
        {
            renderer.material.color = Color.red;
            Chase();
        }

    }
    void lookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(Target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }
    void Chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
