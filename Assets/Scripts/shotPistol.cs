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

    private void Shot()
    {
        bullet = poolManager.GetObject().transform;
        bullet.transform.position = startBullet.position;

        bullet.gameObject.SetActive(true);

        bullet.LookAt(GetHitPosition());

        bullet.SetParent(gameManag.transform);
    }



    private Vector3 GetHitPosition()
    {
        Vector3 hitPosition = Vector3.zero;
        RaycastHit rayHit;
        Camera mainCamera = Camera.main;


        if(Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out rayHit))
                hitPosition = rayHit.point;
        if (Input.touchCount > 0)
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.GetTouch(0).position), out rayHit))
                hitPosition = rayHit.point;

        return hitPosition;
    }
}
