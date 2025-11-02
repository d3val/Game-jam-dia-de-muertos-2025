using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [SerializeField] int initialTime = 600;
    float currentTime = 0;
    [SerializeField] GameObject timeUI;
    private TextMeshProUGUI timerText;
    [SerializeField] UnityEvent onTimerEnd;
    [SerializeField] PlayableDirector gameOverTimeline;
    private Coroutine timerCourotine;

    private void Start()
    {
        currentTime = initialTime;
        timerText = timeUI.GetComponentInChildren<TextMeshProUGUI>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.SetText($"{minutes:00}:{seconds:00}");
    }

    public void StartTimer()
    {
        timerCourotine = StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        timeUI.SetActive(true);
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateUI();
            yield return null;
        }
        currentTime = 0;
        UpdateUI();
        onTimerEnd?.Invoke();
        GameOver();
    }

    public void StopTimer()
    {
        if (timerCourotine != null)
        {
            StopCoroutine(timerCourotine);
            timerCourotine = null;
        }
    }

    private void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().DisableMove();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractor>().enabled = false;
        GameObject.FindAnyObjectByType<ItemsManager>().EnableItemsUI(false);
        timeUI.SetActive(false);
        GameObject.FindAnyObjectByType<AudioSource>().Pause();
        DialogueUI.Instance.HideDialogueBox();
        gameOverTimeline.Play();
    }
}