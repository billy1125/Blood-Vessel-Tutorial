using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ch3_Animation : MonoBehaviour
{
    public GameObject SBPObject;
    public GameObject DBPObject;

    public void SBPHideObject()
    {
        SBPObject.SetActive(false);
    }

    public void SBPShowObject()
    {
        SBPObject.SetActive(true);
    }

    public void DBPHideObject()
    {
        DBPObject.SetActive(false);
    }

    public void DBPShowObject()
    {
        DBPObject.SetActive(true);
    }
}
