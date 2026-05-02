using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour
{
    [SerializeField] string SceneName = "";

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
