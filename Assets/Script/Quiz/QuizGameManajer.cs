using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class QuizGameManajer : MonoBehaviour {
    public AudioSource As;
    [Header("Question")]
    public Image Pertanyaan;
    [Header("Answer")]
    public Button Jawaban_1;
    public Button Jawaban_2;
    public Button Jawaban_3;
    public Image icon_1, icon_2, icon_3;
    [Header("All Question Sprite")]
    public List<Sprite> QuestionsSprite = new List<Sprite>();
    [Header("All Answer Sprite")]
    public List<Sprite> AnswerSprite = new List<Sprite>();
    [Header("All Sound")]
    public List<AudioClip> LevelAudioClip = new List<AudioClip>();
    public AudioClip WrongAnswerClip;

    int Rand, rand1, rand2, rand3,AnswerBefore;
   

    private void Awake()
    {
        if (As == null)
            As = GetComponent<AudioSource>();
    }

    public void Start()
    {
        //icon_1 = Jawaban_1.gameObject.GetComponent<Image>();
        //icon_2 = Jawaban_2.gameObject.GetComponent<Image>();
        //icon_3 = Jawaban_3.gameObject.GetComponent<Image>();

        CreateNewLevel();
    }


    public void CreateNewLevel()
    {
        if (QuestionsSprite.Count > 0)
        {
            while(Rand == AnswerBefore)
            {
                Rand = Random.Range(0, QuestionsSprite.Count);
            }
            
            Pertanyaan.sprite = QuestionsSprite[Rand];
            AnswerBefore = Rand;
            //QuestionsSprite.RemoveAt(Rand);

            int RandomPos = Random.Range(1, 4);
            /// Jawaban_1
            if (RandomPos == 1)
            {
                icon_1.sprite = AnswerSprite[Rand];
                Jawaban_1.onClick.RemoveAllListeners();
                Jawaban_1.onClick.AddListener(() => PlaySound(LevelAudioClip[Rand]));
                Jawaban_1.onClick.AddListener(() => WinGame());

            }
            else
            {
                while (rand1 == Rand || rand1 == rand2 || rand1 == rand3)
                {
                    rand1 = Random.Range(0, AnswerSprite.Count);
                }
                icon_1.sprite = AnswerSprite[rand1];
                Jawaban_1.onClick.RemoveAllListeners();
                Jawaban_1.onClick.AddListener(() => PlaySound(WrongAnswerClip));
                Jawaban_1.onClick.AddListener(() => LoseGame());
            }
            /// Jawaban_2
            if (RandomPos == 2)
            {
                icon_2.sprite = AnswerSprite[Rand];
                Jawaban_2.onClick.RemoveAllListeners();
                Jawaban_2.onClick.AddListener(() => PlaySound(LevelAudioClip[Rand]));
                Jawaban_2.onClick.AddListener(() => WinGame());
            }
            else
            {
                while (rand2 == Rand || rand2 == rand1 || rand2 == rand3)
                {
                    rand2 = Random.Range(0, AnswerSprite.Count);
                }
                icon_2.sprite = AnswerSprite[rand2];
                Jawaban_2.onClick.RemoveAllListeners();
                Jawaban_2.onClick.AddListener(() => PlaySound(WrongAnswerClip));
                Jawaban_2.onClick.AddListener(() => LoseGame());
            }
            /// Jawaban_3
            if (RandomPos == 3)
            {
                icon_3.sprite = AnswerSprite[Rand];
                Jawaban_3.onClick.RemoveAllListeners();
                Jawaban_3.onClick.AddListener(() => PlaySound(LevelAudioClip[Rand]));
                Jawaban_3.onClick.AddListener(() => WinGame());
            }
            else
            {
                while (rand3 == Rand || rand3 == rand2 || rand3 == rand1)
                {
                    rand3 = Random.Range(0, AnswerSprite.Count);
                }
                icon_3.sprite = AnswerSprite[rand3];
                Jawaban_3.onClick.RemoveAllListeners();
                Jawaban_3.onClick.AddListener(() => PlaySound(WrongAnswerClip));
                Jawaban_3.onClick.AddListener(() => LoseGame());
            }
        }
        else
        {
            Debug.Log("Game Clear");
        }
    }

    public void WinGame()
    {
        Debug.Log("Loe Menang Gan");
        CreateNewLevel();
    }

    public void LoseGame()
    {
        Debug.Log("Loe Kalah Suuu");
    }

    public void PlaySound(AudioClip clip)
    {
        As.PlayOneShot(clip);
    }
}









