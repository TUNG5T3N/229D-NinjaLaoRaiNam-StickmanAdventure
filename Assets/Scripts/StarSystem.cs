using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class StarSystem : MonoBehaviour
{
    Image Star1;
    Image Star2;
    Image Star3;
    int EnemyCount = 0;
    int Dead = 0;
    public float progress = 0;
    private void Start()
    {
        Star1 = transform.Find("Star1").GetComponent<Image>();
        Star2 = transform.Find("Star2").GetComponent<Image>();
        Star3 = transform.Find("Star3").GetComponent<Image>();
        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyCount++;
        }
    }

    public void EnemyDiedAssign()
    {
        Dead++;
        progress = Dead / EnemyCount;
        //Debug.Log($"{progress}, {Dead}, {EnemyCount}");
        // Star1
        if (progress >= 0.33f)
        {
            Star1.color = Color.yellow;
        }
        if (progress >= 0.66f)
        {
            Star2.color = Color.yellow;
        }
        if (progress >= 0.99f)
        {
            Star3.color = Color.yellow;
        }
    }
}
