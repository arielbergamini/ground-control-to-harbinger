using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DialogueControl : MonoBehaviour
{

    public GameObject CrewA;
    public GameObject CrewB;
    public TextMeshProUGUI textbox;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearTextBox()
    {
        textbox.text = "";
    }

    public void ASanity()
    {
        var crewA = CrewA.GetComponent<CrewStats>();
        int sanity = crewA.sanity;

        if (sanity < 0)
        {
            // Say sanity is low
            textbox.text = "My sanity is low.";
        }
        else if (sanity > 0)
        {
            // Say sanity is high
            textbox.text = "My sanity is high.";
        }
        else
        {
            // Say sanity is average
            textbox.text = "My sanity is medium.";
        };


    }

    public void AHunger()
    {
        var crewA = CrewA.GetComponent<CrewStats>();
        int hunger = crewA.hunger;

        if (hunger < 0)
        {
            // Say sanity is low
            textbox.text = "My hunger is low.";
        }
        else if (hunger > 0)
        {
            // Say sanity is high
            textbox.text = "My hunger is high.";
        }
        else
        {
            // Say sanity is average
            textbox.text = "My hunger is medium.";
        };


    }

    public void AThirst()
    {
        var crewA = CrewA.GetComponent<CrewStats>();
        int thirst = crewA.thirst;

        if (thirst < 0)
        {
            // Say sanity is low
            textbox.text = "My thirst is low.";
        }
        else if (thirst > 0)
        {
            // Say sanity is high
            textbox.text = "My thirst is high.";
        }
        else
        {
            // Say sanity is average
            textbox.text = "My thirst is medium.";
        };


    }

    public void BSanity()
    {
        var crewB = CrewB.GetComponent<CrewStats>();
        int sanity = crewB.sanity;

        if (sanity < 0)
        {
            // Say sanity is low
            textbox.text = "My sanity is low.";
        }
        else if (sanity > 0)
        {
            // Say sanity is high
            textbox.text = "My sanity is high.";
        }
        else
        {
            // Say sanity is average
            textbox.text = "My sanity is medium.";
        };


    }

    public void BHunger()
    {
        var crewB = CrewB.GetComponent<CrewStats>();
        int hunger = crewB.hunger;

        if (hunger < 0)
        {
            // Say sanity is low
            textbox.text = "My hunger is low.";
        }
        else if (hunger > 0)
        {
            // Say sanity is high
            textbox.text = "My hunger is high.";
        }
        else
        {
            // Say sanity is average
            textbox.text = "My hunger is medium.";
        };


    }

    public void BThirst()
    {
        var crewB = CrewB.GetComponent<CrewStats>();
        int thirst = crewB.thirst;

        if (thirst < 0)
        {
            // Say sanity is low
            textbox.text = "My thirst is low.";
        }
        else if (thirst > 0)
        {
            // Say sanity is high
            textbox.text = "My thirst is high.";
        }
        else
        {
            // Say sanity is average
            textbox.text = "My thirst is medium.";
        };


    }
}
