using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiologeManager : MonoBehaviour
{
    public Text diologeText;
    public Text nameText;

    public Animator boxAnim;
    public Animator speakAnim;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDiologe(Diologe diologe)
    {
        boxAnim.SetBool("boxOpen", true);
        speakAnim.SetBool("speakOpen", false);

        nameText.text = diologe.name;
        sentences.Clear();

        foreach(string sentence in diologe.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDiologe();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        diologeText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            diologeText.text += letter;
            yield return null;
        }
    }

    public void EndDiologe()
    {
        boxAnim.SetBool("boxOpen", false);
    }
}
