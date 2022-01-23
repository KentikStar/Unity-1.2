using UnityEngine;

public class shotPistol : MonoBehaviour
{
    //Пуля
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform startBullet;
    [SerializeField] private PoolManager poolManager;
    private Transform bullet;

    //Родитель
    [SerializeField] private GameObject gameManag;

    private bool isAim;

    private void Start()
    {
        poolManager.CreatePool(bulletPrefabs);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isAim)
        {
            Shot();
        }
    }

    public void setIsAim(bool set)
    {
        this.isAim = set;
    }

    private bool Shot()
    {
        Vector3 positionAim = GetHitPosition();

        if (positionAim == Vector3.zero)
            return false;

        bullet = poolManager.GetObject().transform;
        bullet.transform.position = startBullet.position;

        bullet.gameObject.SetActive(true);

        bullet.LookAt(positionAim);

        bullet.SetParent(gameManag.transform);

        return true;
    }



    private Vector3 GetHitPosition()
    {
        Vector3 hitPosition = Vector3.zero;
        RaycastHit rayHit;
        Camera mainCamera = Camera.main;

        if(Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit))
                hitPosition = rayHit.point;

        return hitPosition;
    }
}
