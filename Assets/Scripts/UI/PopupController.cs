using System.Collections;
using System.Collections.Concurrent;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public static PopupController Instance { get; private set; }

    [Header("References")]
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text msgText;

    [SerializeField] float defaultDuration = 3f; //can tweak
    Coroutine curr;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("PopupController instance already exists");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        //popups start off hidden
        panel.SetActive(false);
    }

    public void Show(string msg, float duration = -1f)
    {

        if (duration < 0)
        {
            duration = defaultDuration;
        }

        if (curr != null)
        {
            StopCoroutine(curr);
        }

        curr = StartCoroutine(ShowRoutine(msg, duration));
    }

    IEnumerator ShowRoutine(string msg, float duration)
    {
        msgText.text = msg;
        panel.SetActive(true);
        yield return new WaitForSeconds(duration);
        panel.SetActive(false);
        curr = null; //no popup
    }
}
