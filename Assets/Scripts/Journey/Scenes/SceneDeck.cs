using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDeck : MonoBehaviour
{
    public GameObject screenTransition;
    public GameObject crewA;
    public GameObject crewAPanel;
    public GameObject crewB;
    public GameObject crewBPanel;
    public GameObject log;
    public GameObject logPanel;
    public GameObject back;
    public GameObject textbox;

    void Start()
    {
        StartCoroutine(EventStarter());
    }
    public void OpenLog()
    {
        print("Captain's Log Open");

        // Hide main screen elements
        crewA.SetActive(false);
        crewB.SetActive(false);
        log.SetActive(false);

        // Show log elements
        back.SetActive(true);
        logPanel.SetActive(true);
    }

    public void OpenCrewA()
    {
        print("Open Crew Member A Dialogue");

        // Hide main screen elements
        crewA.SetActive(false);
        crewB.SetActive(false);
        log.SetActive(false);

        // Show Crew B elements
        crewAPanel.SetActive(true);
        textbox.SetActive(true);
        back.SetActive(true);
    }
    public void OpenCrewB()
    {
        print("Open Crew Member B Dialogue");

        // Hide main screen elements
        crewA.SetActive(false);
        crewB.SetActive(false);
        log.SetActive(false);

        // Show Crew B elements
        crewBPanel.SetActive(true);
        textbox.SetActive(true);
        back.SetActive(true);
    }

    public void Back()
    {
        print("Back");

        // Hide current elements
        back.SetActive(false);
        crewAPanel.SetActive(false);
        crewBPanel.SetActive(false);
        textbox.SetActive(false);
        logPanel.SetActive(false);
        textbox.SetActive(false);

        // Show main screen elements
        crewA.SetActive(true);
        crewB.SetActive(true);
        log.SetActive(true);
    }


IEnumerator EventStarter()
    {
        // For collected crew members in future
        back.SetActive(false);
        crewA.SetActive(true);
        crewAPanel.SetActive(false);
        crewB.SetActive(true);
        crewBPanel.SetActive(false);
        log.SetActive(true);
        textbox.SetActive(false);

        // For screenTransition in future, replace 0 with seconds
        yield return new WaitForSeconds(0);
    }
}
