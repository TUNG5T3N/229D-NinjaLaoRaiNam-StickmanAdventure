using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EndingBox : MonoBehaviour
{
    [SerializeField] GameObject CreditCanvas;
    [SerializeField] GameObject BrightCanvas;
    [SerializeField] AudioSource EndSFX;
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource EndMusic;

    async Task BrightScene()
    {
        GameObject newBCanvas = Instantiate(BrightCanvas);
        GameObject BG = newBCanvas.transform.Find("BG").gameObject;
        Image sprite = BG.GetComponent<Image>();
        EndSFX.Play();
        await sprite.DOBlendableColor(Color.white, 5f).AsyncWaitForCompletion();
        await sprite.DOBlendableColor(Color.black, 0.5f).AsyncWaitForCompletion();
        Destroy(newBCanvas);
        GameObject newCanvas = Instantiate(CreditCanvas);
        CreditScript creditScript = newCanvas.GetComponent<CreditScript>();
        creditScript.GameResult(true);
        EndMusic.Play();
    }

    async void OnTriggerEnter2D(Collider2D collision)
    {
        bool db = false;
        Player2DController player = collision.gameObject.GetComponent<Player2DController>();
        if (player != null && db == false)
        {
            db = true;
            Destroy(player);
            if (BGM != null)
            {
                BGM.Stop();
            }
            BrightScene();
        }
    }
}
