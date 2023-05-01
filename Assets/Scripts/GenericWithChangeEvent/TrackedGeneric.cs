using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedType<T>
{
    public TrackedType(T value)
    {
        m_value = value;
    }

    private T m_value;
    public T value
    {
        get
        {
            return m_value;
        }

        set
        {
            m_value = value;
            if(OnChange != null)OnChange.Invoke(value);
            Debug.Log($"Set value to {value}");
        }
    }
    public delegate void Change(T value);
    public event Change OnChange;
}
