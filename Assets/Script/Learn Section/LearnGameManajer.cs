using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LearnGameManajer : MonoBehaviour {
    private static LearnGameManajer gameManajer;
    public static LearnGameManajer TheInstanceOfLearnGameManajer
    {
        get
        {
            if (gameManajer == null)
            {
                gameManajer = FindObjectOfType<LearnGameManajer>();
            }

            return gameManajer;
        }
    }


    public AudioSource AudioSrc;

    public Image imageTargetToView;
    public Text ImageTargetText;
    public Animator imageTargetViewAnim;

    private void Awake()
    {
        if (AudioSrc == null)
            AudioSrc = GetComponent<AudioSource>();

        if (imageTargetToView == null)
            imageTargetToView = GameObject.FindGameObjectWithTag("Target View").GetComponent<Image>();
    }

    public void ChangeImage(Sprite Sprite,string Text)
    {
        imageTargetToView.sprite = Sprite;
        ImageTargetText.text = Text;
    }

    public void PlayAudio(AudioClip clip)
    {
        AudioSrc.PlayOneShot(clip);
    }



}// end class
