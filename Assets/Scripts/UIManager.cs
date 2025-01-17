using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform frameHolder;
    [SerializeField] private GameObject messageUIStrike, messageUISpare, gameOverUI, mobileCanvas;
    [SerializeField] private TMP_Text scoreText;

    private FrameUI[] frames;


    // Start is called before the first frame update
    void Start()
    {
        ResetFrameUIs();

        messageUISpare.SetActive(false);
        messageUIStrike.SetActive(false);
        gameOverUI.SetActive(false);
        mobileCanvas.SetActive(false);

#if UNITY_ANDROID || UNITY_IOS
        mobileCanvas.SetActive(true);
#endif
        
    }

    public void ResetFrameUIs()
    {
        frames = new FrameUI[frameHolder.childCount];
        for(int i = 0; i < frameHolder.childCount; i++)
        {
            frames[i] = frameHolder.GetChild(i).GetComponent<FrameUI>();
            frames[i].SetFrame(i + 1);
        }
    }

    public void SetFrameValue(int frame, int throwNumber, int score)
    {
        frames[frame - 1].UpdateScore(throwNumber, score);
    }

    public void SetFrameTotal(int frame, int score)
    {
        frames[frame].UpdateTotal(score);
    }

    public void ShowStrike()
    {
        messageUIStrike.SetActive(true);
        //Disable the strike after 2 seconds
        Invoke("HideStrike", 2.0f);
    }

    public void HideStrike()
    {
        messageUIStrike.SetActive(false);
    }

    public void ShowSpare()
    {
        messageUISpare.SetActive(true);
        Invoke(nameof(HideSpare), 2.0f);
    }

    public void HideSpare()
    {
        messageUISpare.SetActive(false);
    }

    public void ShowGameOver(int total)
    {
        gameOverUI.SetActive(true);
        scoreText.text = total.ToString();
    }
}
