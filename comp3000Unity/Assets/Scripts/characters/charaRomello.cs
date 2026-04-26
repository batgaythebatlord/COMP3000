using UnityEngine;

public class charaRomello : MonoBehaviour
{
    private int trust = 0;
    private int annoyance = 0;


    private void OnEnable()
    {
        GameEvents.current.RelationshipEventsScr.onUpdateAnnoyanceRom += UpdateAnnoyanceRom;
        GameEvents.current.RelationshipEventsScr.onUpdateTrustRom += UpdateTrustRom;
    }

    private void OnDisable()
    {
        GameEvents.current.RelationshipEventsScr.onUpdateAnnoyanceRom -= UpdateAnnoyanceRom;
        GameEvents.current.RelationshipEventsScr.onUpdateTrustRom -= UpdateTrustRom;
    }

    void UpdateAnnoyanceRom(int annoyanceChange)
    {
        annoyance += annoyanceChange;
        UnityEngine.Debug.Log("Romello annoyance: " + annoyance);
    }

    void UpdateTrustRom(int trustChange)
    {
        trust += trustChange;
        UnityEngine.Debug.Log("Romello trust: " + trust);
    }

    public int returnState(string type)
    {
        if (type == "trust")
        {
            return trust;
        }

        if (type == "annoyance")
        {
            return annoyance;
        }

        return 0;
    }
}
