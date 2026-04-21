using UnityEngine;

public class charaShauna : MonoBehaviour
{
    private int trust = 0;
    private int annoyance = 0;


    private void OnEnable()
    {
        GameEvents.current.RelationshipEventsScr.onUpdateAnnoyanceSha += UpdateAnnoyanceSha;
        GameEvents.current.RelationshipEventsScr.onUpdateTrustSha += UpdateTrustSha;
    }

    private void OnDisable()
    {
        GameEvents.current.RelationshipEventsScr.onUpdateAnnoyanceSha -= UpdateAnnoyanceSha;
        GameEvents.current.RelationshipEventsScr.onUpdateTrustSha -= UpdateTrustSha;
    }

    void UpdateAnnoyanceSha(int annoyanceChange)
    {
        annoyance += annoyanceChange;
        UnityEngine.Debug.Log("Shauna annoyance: " + annoyance);
    }

    void UpdateTrustSha(int trustChange)
    {
        trust += trustChange;
        UnityEngine.Debug.Log("Shauna trust: " + trust);
    }
}
