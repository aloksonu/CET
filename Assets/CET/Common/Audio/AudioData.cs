﻿using UnityEngine;

namespace Audio.CET
{
    [CreateAssetMenu(fileName = "AudioData_", menuName = "Audio/AudioData", order = 1)]
    public class AudioData : ScriptableObject
    {
        public AudioElement[] data;
    }
}