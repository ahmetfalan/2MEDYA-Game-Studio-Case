using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.collider.GetComponent<Ball>();
        if (ball != null)
        {
            Destroy(gameObject);
            levelManager.brokenCube += 1;
        }

        Cube cube = collision.collider.GetComponent<Cube>();
        if (cube != null)
            return;
    }
}
