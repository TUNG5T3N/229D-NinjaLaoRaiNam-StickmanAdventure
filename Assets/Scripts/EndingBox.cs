using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EndingBox : MonoBehaviour
{
    [SerializeField] GameObject CreditCanvas;
    [SerializeField] GameObject BrightCanvas;


    async Task BrightScene()
    {
        //Debug.Log(1);
        GameObject newBCanvas = Instantiate(BrightCanvas);
        GameObject BG = newBCanvas.transform.Find("BG").gameObject;
        Image sprite = BG.GetComponent<Image>();
        await sprite.DOBlendableColor(Color.white, 5f).AsyncWaitForCompletion();
        //Debug.Log(2);
        await sprite.DOBlendableColor(Color.black, 0.5f).AsyncWaitForCompletion();
        //Debug.Log(3);
        await Task.Delay(1000);
        //Debug.Log(4);
        Destroy(newBCanvas);
        GameObject newCanvas = Instantiate(CreditCanvas);
        CreditScript creditScript = newCanvas.GetComponent<CreditScript>();
        creditScript.GameResult(true);
    }

    async void OnTriggerEnter2D(Collider2D collision)
    {
        bool db = false;
        Player2DController player = collision.gameObject.GetComponent<Player2DController>();
        if (player != null && db == false)
        {
            db = true;
            Destroy(player);
            BrightScene();
        }
    }
}
