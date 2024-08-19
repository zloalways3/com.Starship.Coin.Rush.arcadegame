using System;
using UnityEngine;


namespace ZeroSDK.UIBuilder.Config
{
    [Serializable]
    public class CanvasConfig
    {
        public RenderMode RenderMode = RenderMode.ScreenSpaceCamera;
        public float PlaneDistance = 5;


        public void SetFor(Canvas canvas)
        {
            canvas.renderMode = RenderMode;
            canvas.planeDistance = PlaneDistance;
        }
    }
}