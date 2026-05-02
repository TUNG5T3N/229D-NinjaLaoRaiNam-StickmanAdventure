using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour
{
    [SerializeField] string SceneName = "";
    StarSystem StarSys;
    Image Star1;
    Image Star2;
    Image Star3;
    private void Start()
    {
        Star1 = transform.Find("Star1").GetComponent<Image>();
        Star2 = transform.Find("Star2").GetComponent<Image>();
        Star3 = transform.Find("Star3").GetComponent<Image>();
        StarSys = GameObject.FindAnyObjectByType<StarSystem>();
        float progress = StarSys.progress;
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

    public void GameResult (bool isWin)
    {
        TMP_Text TextLabel = transform.Find("ResultText").GetComponent<TMP_Text>();
        string Text = isWin ? "Stage Completed" : "Game Over";
        TextLabel.text = Text;
    }

    public void OnClickedBackToMainMenu()
    {
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName);
    }
}
