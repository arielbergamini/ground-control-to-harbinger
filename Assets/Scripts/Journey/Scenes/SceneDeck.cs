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
        crewA.SetActive(false);
        crewB.SetActive(false);
        log.SetActive(false);
        back.SetActive(true);
        logPanel.SetActive(true);
        print("Captain's Log Open");
    }

    public void OpenCrewA()
    {
        crewA.SetActive(false);
        crewAPanel.SetActive(true);
        crewB.SetActive(false);
        log.SetActive(false);
        back.SetActive(true);
        textbox.SetActive(true);
        print("Open Crew Member A Dialogue");
    }
    public void OpenCrewB()
    {
        crewA.SetActive(false);
        crewB.SetActive(false);
        crewBPanel.SetActive(true);
        log.SetActive(false);
        back.SetActive(true);
        textbox.SetActive(true);
        print("Open Crew Member B Dialogue");
    }

    public void Back()
    {
        print("Back");
        back.SetActive(false);
        crewA.SetActive(true);
        crewAPanel.SetActive(false);
        crewB.SetActive(true);
        crewBPanel.SetActive(false);
        textbox.SetActive(false);
        log.SetActive(true);
        logPanel.SetActive(false);
        textbox.SetActive(false);
    }


IEnumerator EventStarter()
    {
        // For collected crew member objects in future
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
