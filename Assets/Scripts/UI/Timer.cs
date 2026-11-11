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
    public DropZone dropZone;
    public GameObject titleScreen;

    private bool gameRunning = false;

    public string JourneyScene;
    public float endDelay;
    public TMP_Text timerText;
    public Button startButton;

    //vars specifically for transition into journey scene - success state
    public CanvasGroup transitionPanel;
    public TMP_Text transitionText;
    public float fadeDuration = 1f;
    public float holdTime = 1.5f;


    //TODO - make condition for scene transition in fail state; if fail, transition back to game start
    //make fade-out for other end
    IEnumerator SceneEnd()
    {
        yield return new WaitForSeconds(endDelay);
        //transition to journey scene

        string scavSummary = PersistentInventory.Instance != null ? PersistentInventory.Instance.GetScavSummary() : "nothing";

        transitionText.text = $"You managed to escape with {scavSummary}.";
        transitionPanel.blocksRaycasts = true; //cover the screen

        //fade in to the scene
        float timeElapsed = 0;
        while (timeElapsed < fadeDuration) {
            timeElapsed += Time.deltaTime;
            transitionPanel.alpha = Mathf.Clamp01(timeElapsed / fadeDuration);
            yield return null;
        }

        yield return new WaitForSeconds(holdTime);
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

            //win/fail state
            if (dropZone.PlayerIn)
            {
                dropZone.Deposit(); 
                StartCoroutine(SceneEnd());
            }
            else
            {
                PersistentInventory.Instance.Clear();//you lost; inv clears
                //show game over/retry
            }
        }
    }

    public void StartClicked()
    {
        titleScreen.SetActive(false);

        gameRunning = true;
        timeLeft = startTime;
        startButton.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);

        PlayerCam.setLookEnabled(true);
        Player.canMove = true;
    }
}
