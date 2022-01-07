using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Cube cube = collision.collider.GetComponent<Cube>();
        if (cube != null)
            Destroy(gameObject);
    }
}
