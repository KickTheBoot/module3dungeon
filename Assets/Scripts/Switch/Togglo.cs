using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togglo : MonoBehaviour
{
    public bool initialState;
    bool m_status;

    void Start()
    {
        status = initialState;
    }

    public bool status
    {
        get{
            return m_status;
        }

        set{
            m_status = value;
            if(OnSwitch != null)OnSwitch.Invoke(m_status);
        }
    }
    public delegate void SwitchHandler(bool value);
    public event SwitchHandler OnSwitch;
}
