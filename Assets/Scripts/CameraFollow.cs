using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform followObject;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - followObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (followObject.position + offset);
    }
}
