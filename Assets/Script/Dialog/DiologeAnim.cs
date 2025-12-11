using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Animator speakAnim;
    public DiologeManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        speakAnim.SetBool("speakOpen", true);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        speakAnim.SetBool("speakOpen", false);
        dm.EndDiologe();
    }
}
