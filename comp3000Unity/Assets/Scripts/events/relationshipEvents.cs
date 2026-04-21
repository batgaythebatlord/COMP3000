using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class relationshipEvents
{
    public event Action<int> onUpdateAnnoyanceSha;

    public void UpdateAnnoyanceSha(int annoyanceChangeSha)
    {
        if (onUpdateAnnoyanceSha != null)
        {
            onUpdateAnnoyanceSha(annoyanceChangeSha);
        }
    }


    public event Action<int> onUpdateTrustSha;

    public void UpdateTrustSha(int trustChangeSha)
    {
        if (onUpdateTrustSha != null)
        {
            onUpdateTrustSha(trustChangeSha);
        }
    }


    public event Action<int> onUpdateAnnoyanceRom;

    public void UpdateAnnoyanceRom(int annoyanceChangeRom)
    {
        if (onUpdateAnnoyanceRom != null)
        {
            onUpdateAnnoyanceRom(annoyanceChangeRom);
        }
    }


    public event Action<int> onUpdateTrustRom;

    public void UpdateTrustRom(int trustChangeRom)
    {
        if (onUpdateTrustRom != null)
        {
            onUpdateTrustRom(trustChangeRom);
        }
    }
}
