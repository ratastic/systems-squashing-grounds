using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public int maxHearts = 5;
    public int currentHearts;

    public GameObject[] heartImgs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHearts = maxHearts;
        UpdateHeartBarUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHeart(int damage)
    {
        currentHearts -= damage; // decrease current amount of hearts by 1 each time

        if (currentHearts < 0)
            currentHearts = 0; // clamps value to zero when value enters the negatives

        UpdateHeartBarUI(); // call everytime currentHearts value changes

        if (currentHearts == 0)
        {
            Debug.Log("game over!!"); // game over logic
        }
    }

    void UpdateHeartBarUI()
    {
        for (int i = 0; i < heartImgs.Length; i++)
        {
            heartImgs[i].SetActive(i < currentHearts); // removes heart icons one by one by cycling through array
        }
    }
}
