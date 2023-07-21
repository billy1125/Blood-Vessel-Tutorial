using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TextContents
{
    public string title;
    public string textContent;
    public AudioClip textContentAudioclips;
    public GameObject Model;
    public GameObject Caption;
    public Animator ModelAnimator;
    public int ModelAnimatorPara;
}

public class GameManager : MonoBehaviour
{
    public GameObject IntroUI;
    public GameObject ClassUI;
    public GameObject PageChangeButtonUI;
    public GameObject PlayButtonUI;
    public GameObject PlayButton;
    public GameObject PauseButton;
    public GameObject HomeButtonUI;
    public Text TitleTextBox;
    public Text SubtileTextBox;
    public GameObject CreditsTextBox;
    public GameObject CopyrightsTextBox;

    public List<TextContents> textContents = new List<TextContents>();

    AudioSource AS;

    public int Pages;
    public GameObject DemoModel;
    public GameObject DemoCaption;

    // Start is called before the first frame update
    void Start()
    {
        Pages = 0;
        IntroUI.SetActive(true);
        HomeButtonUI.SetActive(false);
        AS = GetComponent<AudioSource>();
        TitleTextBox.text = "";
        SubtileTextBox.text = "";

        //print(textContents.Count);
    }

    void PlayTutor(int _i)
    {
        if (_i == textContents.Count)
            SceneManager.LoadScene("Heart");

        PlayButton.SetActive(false);
        PauseButton.SetActive(false);

        if (textContents[_i].ModelAnimatorPara != -1)
        {
            PlayButton.SetActive(true);
        }
        
        DemoModel.SetActive(false);
        DemoCaption.SetActive(false);

        if (_i < textContents.Count)
        {          
            TitleTextBox.text = textContents[_i].title;
            SubtileTextBox.text = textContents[_i].textContent;

            if (textContents[_i].textContentAudioclips != null)
            {
                AS.clip = textContents[_i].textContentAudioclips;
                AS.Play();
            }
                     
            if (textContents[_i].ModelAnimator != null)
                textContents[_i].ModelAnimator.SetInteger("Kind", 0);

            if (textContents[_i].Model != null)
            {
                DemoModel = textContents[_i].Model;
                DemoModel.SetActive(true);
            }

            if (textContents[_i].Caption != null)
            {
                DemoCaption = textContents[_i].Caption;
                DemoCaption.SetActive(true);
            }
        }
        else
        {
            Pages = textContents.Count - 1;
        }

        
    }

    void PlayAnimation(int _i)
    {
        if (textContents[_i].ModelAnimator != null)
        {
            textContents[_i].ModelAnimator.enabled = true;
            textContents[_i].ModelAnimator.SetInteger("Kind", textContents[_i].ModelAnimatorPara);
        }
        PlayButton.SetActive(false);
        PauseButton.SetActive(true);
    }

    void PauseAnimation(int _i)
    {
        if (textContents[_i].ModelAnimator != null)
            textContents[_i].ModelAnimator.enabled = false;
        PlayButton.SetActive(true);
        PauseButton.SetActive(false);
    }


    public void StartTutorButton()
    {
        IntroUI.SetActive(false);
        ClassUI.SetActive(true);
        HomeButtonUI.SetActive(true);
        PageChangeButtonUI.SetActive(true);
        PlayButtonUI.SetActive(true);
        PlayTutor(Pages);
    }

    public void ShowCredits()
    {
        CreditsTextBox.SetActive(true);
        CopyrightsTextBox.SetActive(false);
    }

    public void ShowCopyrights()
    {
        CreditsTextBox.SetActive(false);
        CopyrightsTextBox.SetActive(true);
    }

    public void PlayContent()
    {
        PlayAnimation(Pages);
    }

    public void PauseContent()
    {
        PauseAnimation(Pages);
    }

    public void NextPage()
    {
        Pages += 1;
        
        PlayTutor(Pages);
    }

    public void LastPage()
    {
        Pages -= 1;

        PlayTutor(Pages);
    }

    public void HomeButton()
    {
        IntroUI.SetActive(true);
        ClassUI.SetActive(false);
        PlayButton.SetActive(false);
        PageChangeButtonUI.SetActive(false);
        HomeButtonUI.SetActive(false);

        AS.Stop();

    }
}
    