using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportor : MonoBehaviour
{
    [SerializeField] string SceneName = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player2DController player = collision.gameObject.GetComponent<Player2DController>();
        if (player != null && SceneName != "")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
