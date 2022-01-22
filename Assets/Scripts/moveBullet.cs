using UnityEngine;

public class moveBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;


    private gameManag gameManag;

    private void Start()
    {
        gameManag = transform.parent.GetComponent<gameManag>();
    }

    void FixedUpdate()
    {
        if(gameObject.activeSelf)
            transform.position += transform.forward * Time.fixedDeltaTime * moveSpeed;
        
    }

    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.layer == 8 && gameObject.activeSelf)
        {
            Animator anim = myCollision.gameObject.transform.root.GetComponent<Animator>();
            anim.enabled = false;
            
            gameManag.killEnemy();
        }

        if (myCollision.gameObject.layer != 6)
        {
            gameObject.SetActive(false);
        }
    }
}

