using System;
using UnityEngine;
using UnityEngine.UI;


namespace ZeroSDK.UIBuilder.Config
{
    [Serializable]
    public class CanvasScalerConfig
    {
        public CanvasScaler.ScaleMode ScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        public Vector2 ReferenceResolution = new Vector2(1080, 1920);
        public float MatchWidthOrHeight = 0.5f;
        public float ReferencePixelsPerUnit = 100;


        public void SetFor(CanvasScaler cs)
        {
            cs.uiScaleMode = ScaleMode;
            cs.referenceResolution = ReferenceResolution;
            cs.matchWidthOrHeight = MatchWidthOrHeight;
            cs.referencePixelsPerUnit = ReferencePixelsPerUnit;
        }
    }
}