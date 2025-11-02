using System.Collections;
using TMPro;
using Unity.VisualScripting;
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
    [SerializeField] AudioSource soundtrackSource;
    private AudioClip defaultClip;
    [SerializeField] AudioClip tenseMusic;
    private bool clipSwaped = false;
    [SerializeField, Range(0f, 1f)] float tensePercentage = 0.25f;
    private Coroutine timerCourotine;

    private void Start()
    {
        defaultClip = soundtrackSource.clip;
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
            if (currentTime <= initialTime * tensePercentage && !clipSwaped)
            {
                soundtrackSource.Stop();
                soundtrackSource.clip = tenseMusic;
                soundtrackSource.Play();
                clipSwaped = true;
                GameObject.FindAnyObjectByType<PlayerMovement>().speed *= 1.1f;
            }
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
            soundtrackSource.clip = defaultClip;
        }
    }

    private void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().DisableMove();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractor>().enabled = false;
        GameObject.FindAnyObjectByType<ItemsManager>().EnableItemsUI(false);
        timeUI.SetActive(false);
        soundtrackSource.Pause();
        DialogueUI.Instance.HideDialogueBox();
        gameOverTimeline.Play();
    }
}