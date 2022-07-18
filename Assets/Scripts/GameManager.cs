using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;
    public bool startPlaying;
    public BeatScroller bs;

    public static GameManager instance;

    public SpriteRenderer character;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public TMPro.TextMeshProUGUI tmpro;
    public GameObject effect;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultScreen;
    public TMPro.TextMeshProUGUI normalText, goodText, perfectText, missText, finalScoreText;
    void Start()
    {
        instance = this;
        tmpro.text = "Score: 0";
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                bs.hasStarted = true;

                audioSource.Play();
            }
        }
        else
        {
            if(!audioSource.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);

                normalText.text = "Normal: " + normalHits;
                goodText.text = "Good: " + goodHits;
                perfectText.text = "Perfect: " + perfectHits;
                missText.text = "MIss: " + (totalNotes - normalHits - goodHits - perfectHits).ToString();
                finalScoreText.text = ((goodHits + perfectHits + normalHits) / totalNotes * 100.0f).ToString("F1") + "%";
            }
        }
    }

    public void NoteHit()
    {
        tmpro.text = "Score: " + currentScore.ToString();

    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("missed");
        missedHits++;
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(3);
    }

}
