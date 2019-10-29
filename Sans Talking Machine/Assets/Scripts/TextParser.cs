using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextParser : MonoBehaviour
{
    public Text DialogueBox;
    public AudioSource AudioSource;
    public AudioClip SE;
    public float UpdateInterval;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string text)
    {
        DialogueBox.text = string.Empty;
        StartCoroutine("TextUpdateCoroutine", text);
    }

    private IEnumerator TextUpdateCoroutine(string text)
    {
        for(var i =0;i < text.Length; i++)
        {
            if (!text[i].Equals(' ')) AudioSource.PlayOneShot(SE);
            
            DialogueBox.text+=text[i];

            yield return new WaitForSeconds(UpdateInterval);
        }

    }
}
