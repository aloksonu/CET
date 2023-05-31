using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] [Range(-2000, 2000)] private float RotationDirectionSpeed = -100;
    private Vector3 _rotationVector;
    void Start()
    {
        _rotationVector = new Vector3(0, 0, RotationDirectionSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(_rotationVector*Time.deltaTime);
    }
}
