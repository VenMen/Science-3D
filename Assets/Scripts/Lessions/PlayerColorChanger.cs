using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    public static Action<Color> OnLevelStarted;
}
