using System.Collections;
using UnityEngine;

public class CubeTower : MonoBehaviour
{
    [SerializeField]
    GameObject _cube;

    public int _cubeSize = 1;

    [SerializeField]
    float _createDelay;

    private void Start()
    {
        StartCoroutine(Cre(_cubeSize));
    }

    public IEnumerator Cre(int size)
    {
        WaitForSeconds wait = new WaitForSeconds(_createDelay);
        int i = 0;
        if (size > 0)
        {
            while (i < size)
            {
                yield return wait;
                GameObject gO = Instantiate(_cube, new Vector3(transform.position.x, transform.position.y + i, transform.position.z), new Quaternion(transform.rotation.x + i, transform.rotation.y + i, transform.rotation.z + i, 1));
                gO.transform.parent = this.transform;
                size--;
            }
        }
    }
}
