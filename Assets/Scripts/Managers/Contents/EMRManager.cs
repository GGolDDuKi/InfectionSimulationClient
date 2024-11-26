using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMRManager
{
    GameObject EMR;
    public bool CanClose = true;

    public bool DoingEMR => EMR != null;

    public void OpenEMRWrite()
    {
        EMR = Managers.UI.CreateUI("MpoxEMRWrite");
    }

    public void OpenEMRRead()
    {
        EMR = Managers.UI.CreateUI("MpoxEMRRead");
    }

    public void OpenForm()
    {
        EMR = Managers.UI.CreateUI("RequestForm");
    }

    public void CloseEMR()
    {
        if (EMR == null)
            return;

        if (CanClose == false)
            return;

        if(EMR.name == "MpoxEMRRead")
        {
            Managers.Scenario.MyAction = "EMRRead";
        }

        if(EMR.name == "RequestForm")
        {
            Managers.Scenario.MyAction = "SCRFWrite";
        }

        Managers.UI.DestroyUI(EMR);
        EMR = null;
    }
}
