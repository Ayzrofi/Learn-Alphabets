using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonAlphabets : MonoBehaviour {
    [SerializeField] 
    private Button Btn;
    [SerializeField] [Header("Image Component")]
    private Sprite ImageToAdd;
    [Header("Text Component")]
    public string ImageText;
    [SerializeField] [Header("Audio Component")]
    private AudioClip ImageSoundClip;

    public static bool isPlaying = false;

    private void Awake()
    {
        if (Btn == null)
            Btn = GetComponent<Button>();
    }

    private void Start()
    {
        Btn.onClick.AddListener(() => Play() );
    }

    public void Play()
    {
        //StopAllCoroutines();
        if (!isPlaying)
        {
            StartCoroutine(ButtonPlaying());
        } 
    }

    public IEnumerator ButtonPlaying()
    {
        isPlaying = true;
        LearnGameManajer.TheInstanceOfLearnGameManajer.imageTargetViewAnim.SetTrigger("PopUp");
        LearnGameManajer.TheInstanceOfLearnGameManajer.ChangeImage(ImageToAdd, ImageText);
        //if (LearnGameManajer.TheInstanceOfLearnGameManajer.AudioSrc.isPlaying)
        //    LearnGameManajer.TheInstanceOfLearnGameManajer.AudioSrc.Stop();
        LearnGameManajer.TheInstanceOfLearnGameManajer.PlayAudio(ImageSoundClip);
        yield return new WaitForSeconds(1.5f);
        isPlaying = false;
        //if (LearnGameManajer.TheInstanceOfLearnGameManajer.AudioSrc.isPlaying)
        //    LearnGameManajer.TheInstanceOfLearnGameManajer.AudioSrc.Stop();
        //LearnGameManajer.TheInstanceOfLearnGameManajer.PlayAudio(ImageSoundClip2);
    }
}
