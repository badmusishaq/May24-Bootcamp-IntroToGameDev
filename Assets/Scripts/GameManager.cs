using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private Pin[] pins;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNextThrow()
    {
        Invoke("NextThrow", 3.0f);    
    }

    void NextThrow()
    {
        if(scoreManager.currentFrame == 0)
        {
            Debug.Log($"Game over, your total is {scoreManager.CalculateTotalScore()}");
        }
        else
        {
            Debug.Log($"Frame = {scoreManager.currentFrame} and Throw = {scoreManager.currentThrow}");
            scoreManager.SetFrameScore(CalculateFallenPins());
            Debug.Log($"Current score : {scoreManager.CalculateTotalScore()}");
            Debug.Log($"Frame value - {scoreManager.currentFrame} , Throw value - {scoreManager.currentThrow}, current score - {scoreManager.CalculateTotalScore()} ");

            player.StartThrow();
        }
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
}
