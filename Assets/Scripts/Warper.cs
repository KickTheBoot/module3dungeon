using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warper : MonoBehaviour
{
    [SerializeField] WarpInfo WarpTarget;

    public void Warp()
    {
        GameManager.instance.Warp(WarpTarget);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
