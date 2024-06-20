using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private int totalScore;

    private int[] frames = new int[10];

    public int currentFrame { get; private set; }
    public int currentThrow { get; private set; }

    private bool isSpare = false;
    private bool isStrike = false;


    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFrameScore(int score)
    {
        //Ball 1
        if(currentThrow == 1)
        {
            frames[currentFrame - 1] += score;

            //in parallel, we can check for a spare
            if(isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }
            //.........................................

            if(score == 10)
            {
                if(currentFrame == 10)
                {
                    currentThrow++;
                }
                else
                {
                    isStrike = true;
                    currentFrame++;
                }

                //Reset pins
                gameManager.ResetAllPins();
            }
            else
            {
                currentThrow++;
            }

            return;
        }

        //Ball 2
        if(currentThrow == 2)
        {
            frames[currentFrame - 1] += score;

            //Parallel strike check
            if(isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1];
                isStrike = false;
            }
            //.....................

            if(frames[currentFrame - 1] == 10)
            {
                if(currentFrame == 10)
                {
                    currentThrow++;
                }
                else
                {
                    isSpare = true;
                    currentFrame++;
                    currentThrow = 1;
                }
            }
            else
            {
                if(currentFrame == 10)
                {
                    //End all throws
                    currentThrow = 0;
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1;
                }
            }

            gameManager.ResetAllPins();

            return;
        }

        //Ball 3 only on frame 10
        if(currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;

            //end all throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }
    }

    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach(var item in frames)
        {
            totalScore += item;
        }

        return totalScore;
    }

    private void ResetScore()
    {
        totalScore = 0;
        currentFrame = 1;
        currentThrow = 1;
        frames = new int[10];
    }
}
