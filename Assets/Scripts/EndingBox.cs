using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class EndingBox : MonoBehaviour
{
    [SerializeField] GameObject CreditCanvas;
    [SerializeField] GameObject BrightCanvas;


    async Task BrightScene()
    {
        Camera camera = FindAnyObjectByType<Camera>();
        GameObject newBCanvas = Instantiate(BrightCanvas);
        Canvas canvas = newBCanvas.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = camera;
        canvas.planeDistance = 30f;


        GameObject BG = newBCanvas.transform.Find("BG").gameObject;
        SpriteRenderer sprite = BG.GetComponent<SpriteRenderer>();
        await sprite.DOBlendableColor(Color.white, 5f).AsyncWaitForCompletion();
        await sprite.DOBlendableColor(Color.black, 0.5f).AsyncWaitForCompletion();
        await Task.Delay(1000);
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
