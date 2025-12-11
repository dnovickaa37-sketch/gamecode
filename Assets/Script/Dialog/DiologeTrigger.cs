using UnityEngine;

public class DiologeTrigger : MonoBehaviour
{
    public Diologe diologe;

    [System.Obsolete]
    public void TriggerDiologe()
    {
        FindObjectOfType<DiologeManager>().StartDiologe(diologe);   
    }
}
