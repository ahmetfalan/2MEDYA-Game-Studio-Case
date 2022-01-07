using UnityEngine;
using DG.Tweening;

public class Gun : MonoBehaviour
{
    public bool _isSooting = true;

    [SerializeField]
    GameObject _ball;

    [SerializeField]
    Transform _muzzle;

    [SerializeField]
    float shootForce = 500f;

    [SerializeField]
    float recoilForce = 1f;

    LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (!levelManager.isLevelDone || !levelManager.isGameOver)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                GameObject gO = Instantiate(_ball, _muzzle.transform.position, _muzzle.transform.rotation);
                gO.GetComponent<Rigidbody>().AddForce(_muzzle.transform.forward * shootForce);
                Destroy(gO, 3f);

                AddRecoil();
                _isSooting = false;
            }
            else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
            {
                RemoveRecoil();
                _isSooting = true;
            }
        }
    }

    public void AddRecoil()
    {
        this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y, -recoilForce), 1);
    }

    public void RemoveRecoil()
    {
        this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y, recoilForce), 1);
    }
}
