using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new WarpInfo", menuName = "Bootlegger/WarpInfo")]
public class WarpInfo : ScriptableObject
{
    public string SceneName;
    public AudioClip RoomMusic;
    public Vector2 Position;

}
