using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{
    Vector3 _angle = new Vector3(0, 360, 0);
    public float _rotationSpeed = 0.5f;
    public float _addedRotationSpeed = 0.7f;

    Gun gun;
    private void Awake()
    {
        gun = FindObjectOfType<Gun>();
    }

    private void Update()
    {
        if (gun._isSooting)
            transform.Rotate(_angle * _rotationSpeed * Time.deltaTime);
        else
            transform.Rotate(_angle * _addedRotationSpeed * Time.deltaTime);
    }
}
