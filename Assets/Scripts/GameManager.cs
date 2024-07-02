using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] UIManager uiManager;

    [SerializeField] private Pin[] pins;

    public SoundManager soundManager;

    [SerializeField] private Camera mainCam, closeupCam;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        player.StartThrow();

        mainCam.enabled = true;
        closeupCam.enabled = false;
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);    
    }

    void NextThrow()
    {
        int fallenPins = CalculateFallenPins();
        scoreManager.SetFrameScore(fallenPins);


        if(scoreManager.currentFrame == 0)
        {
            uiManager.ShowGameOver(scoreManager.CalculateTotalScore());
            return;
        }

        int frameTotal = 0;
        for(int i = 0; i < scoreManager.currentFrame - 1; i++)
        {
            frameTotal += scoreManager.GetFrameScores()[i];
            uiManager.SetFrameTotal(i, frameTotal);
        }

        //SwitchCam();
        SwitchCameras(false);
        player.StartThrow();
        
    }

    public void ResetAllPins()
    {
        foreach(Pin pin in pins)
        {
            pin.ResetPin();
        }
    }

    public int CalculateFallenPins()
    {
        int count = 0;

        foreach(Pin p in pins)
        {
            if (p.isFallen && p.gameObject.activeSelf)
            {
                count++;
                p.gameObject.SetActive(false);
            }
        }

        Debug.Log($"Total fallen pins = {count}");
        //Debug.Log("Total fallen pins = " + count);
        return count;
    }

    public void SwitchCam()
    {
        mainCam.enabled = !mainCam.enabled;
        closeupCam.enabled = !closeupCam.enabled;
    }

    public void SwitchCameras(bool isOn)
    {
        mainCam.enabled = !isOn;
        closeupCam.enabled = isOn;
    }
}
