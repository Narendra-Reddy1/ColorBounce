
using BenStudios.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace BenStudios
{
    [System.Serializable]
    public class ColorCollidersDictionary : SerializableDictionary<PlayerColor, GameObject> { }
    [System.Serializable]
    public class ScreenObjectsDictionary : SerializableDictionary<Window, WindowAddressableObject> { }
}