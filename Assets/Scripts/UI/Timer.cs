using System.ComponentModel;
using System.Globalization;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//Timer that counts down from 60s at beginning of scav section
//
//

public class Timer : MonoBehaviour
{

    public float startTime;
    private float timeLeft;

    public CameraController PlayerCam;
    public PlayerMovement Player;
    private bool gameRunning = false;

    public string JourneyScene;
    public float endDelay;
    public TMP_Text timerText;
    public Button startButton;

    IEnumerator SceneEnd()
    {
        // ** later TODO -- trigger animation/transition to journey scene
        yield return new WaitForSeconds(endDelay);
        SceneManager.LoadScene(JourneyScene);
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            //timer ticks down
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("0.00");        
        }
        else if (gameRunning)
        {
            //timer's done!
            gameRunning = false;
            startButton.gameObject.SetActive(true);
            timerText.gameObject.SetActive(false);

            PlayerCam.setLookEnabled(false);
            Player.canMove = false;

            StartCoroutine(SceneEnd());

            // ** NOTE -- can add game over/retry/scav summary screen here
        }
    }

    public void StartClicked()
    {
        gameRunning = true;
        timeLeft = startTime;
        startButton.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);

        PlayerCam.setLookEnabled(true);
        Player.canMove = true;
    }
}
