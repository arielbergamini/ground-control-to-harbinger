using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SceneDeck : MonoBehaviour
{
    public CrewStats stats;

    public GameObject screenTransition;
    public GameObject crewA;
    public GameObject crewAPanel;
    public GameObject crewB;
    public GameObject crewBPanel;
    public GameObject log;
    public GameObject logPanel;
    public GameObject back;
    public GameObject textbox;

    //public UnityEvent clearText;
    //bool crewApresent =false;
    //bool crewBpresent =false;


    void Start()
    {
        //Variables.Object(gameObject).
        //crewA(CrewStats.CrewMember)
        //Component crewName = GetComponent(CrewStats.CrewMember);
        //crewA.stats.crewName
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

    public void RationsMenu()
    {
        print("Rations");

        // Hide Log

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

        //clearText.Invoke();

        // Show main screen elements
        if (crewA) { crewA.SetActive(true); }
        if (crewB) { crewB.SetActive(true); }
        log.SetActive(true);
    }


IEnumerator EventStarter()
    {
        // For collected crew members in future
        back.SetActive(false);
        if (crewA) { crewA.SetActive(true); }
        crewAPanel.SetActive(false);
        if (crewB) { crewB.SetActive(true); }
        crewBPanel.SetActive(false);
        log.SetActive(true);
        textbox.SetActive(false);

        // For screenTransition in future, replace 0 with seconds
        yield return new WaitForSeconds(0);
    }
}
