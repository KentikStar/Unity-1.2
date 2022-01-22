using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private List<Transform> wayPoint;
    private int indexPoint = 0;
    private Camera cameraMain;

    private Animator animator;

    //Пистолет
    [SerializeField] private shotPistol shotPistol;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        cameraMain = Camera.main;
    }

    void FixedUpdate()
    {        
        AnimControl();
    }

    private void AnimControl()
    {
        float distance;
        distance = agent.remainingDistance;

        if(distance > 0.15)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAim", false);
            shotPistol.setIsAim(false);
        }
        else
        {
            animator.SetBool("isAim", true);
            animator.SetBool("isRunning", false);

            if(indexPoint > 0)
                shotPistol.setIsAim(true);

            ForwardToObject();
        }
    }

    private Vector3 GetHitPosition()
    {
        Vector3 hitPosition = Vector3.zero;
        RaycastHit rayHit;

        if (Physics.Raycast(cameraMain.ScreenPointToRay(Input.mousePosition), out rayHit))
            hitPosition = rayHit.point;
        if(Input.touchCount > 0)
            if (Physics.Raycast(cameraMain.ScreenPointToRay(Input.GetTouch(0).position), out rayHit))
                hitPosition = rayHit.point;

        return hitPosition;
    }


    public void GoNextWayPoint()
    {
        agent.SetDestination(wayPoint[indexPoint++].position);
    }

    private void ForwardToObject()
    {
        Vector3 direction = (GetHitPosition() - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z - 0.8f));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

}
