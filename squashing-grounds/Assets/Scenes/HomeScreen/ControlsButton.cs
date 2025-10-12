using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsButton : MonoBehaviour
{
    public GameObject playButton;
    public GameObject controlButton;
    public GameObject title;
    public GameObject controlInfo;
    public AudioSource clickSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playButton.SetActive(true);
        controlButton.SetActive(true);
        title.SetActive(true);

        controlInfo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenControls()
    {
        playButton.SetActive(false);
        controlButton.SetActive(false);
        title.SetActive(false);

        controlInfo.SetActive(true);
        clickSound.Play();
    }

    public void CloseControls()
    {
        playButton.SetActive(true);
        controlButton.SetActive(true);
        title.SetActive(true);

        controlInfo.SetActive(false);
        clickSound.Play();
    }
}
