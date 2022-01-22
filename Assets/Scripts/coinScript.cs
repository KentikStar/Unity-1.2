using UnityEngine;
using UnityEngine.SceneManagement;

public class coinScript : MonoBehaviour
{
    void OnCollisionEnter(Collision myCollision)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
