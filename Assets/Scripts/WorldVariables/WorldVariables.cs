using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldVariables : MonoBehaviour
{
    [SerializeField]
    int booleanCount;
    public TrackedType<bool>[] booleans;
    public List<int> pickedUpKeys;

    public void Initialize()
    {
        booleans = new TrackedType<bool>[booleanCount];
        for(int i = 0; i < booleans.Length; i++)
        {
            booleans[i] = new TrackedType<bool>(false);
        }
    }
}
