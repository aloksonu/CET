using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    [SerializeField] private GameObject Obstacal;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] [Range(.01f, 10)] private float MovingSpeed = 2;
    [SerializeField] [Range(-1000, 1000)] private float RotationDirectionSpeed = -100;
    private int current = 0;
    private float WPradius;
    private float _deltaTime = .01f;
    private Vector3 _rotationVector;

    void Start()
    {
        _rotationVector = new Vector3(0, 0, RotationDirectionSpeed);
        WPradius = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    internal void Move()
    {
#if UNITY_EDITOR
        _rotationVector = new Vector3(0, 0, RotationDirectionSpeed);
#endif
        _deltaTime = Time.deltaTime;
        if (Vector3.Distance(waypoints[current].transform.localPosition, Obstacal.transform.localPosition) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        Obstacal.transform.position = Vector3.MoveTowards(Obstacal.transform.localPosition, waypoints[current].transform.localPosition, _deltaTime * MovingSpeed);
        Obstacal.transform.Rotate(_rotationVector* _deltaTime);
    }
}
