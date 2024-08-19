using System;
using UnityEngine;
using ZeroSDK.UIBuilder.Core;


// using UnityEngine;


namespace ZeroSDK.UIBuilder.Config
{

    [Serializable]
    public class CameraConfig
    {
        // [BoxGroup("URP Data")] public CameraRenderType RendererType = CameraRenderType.Overlay;
        // [BoxGroup("URP Data")] public bool RenderShadows = false;

        public int depth = -1;
        public CameraClearFlags clearFlags = CameraClearFlags.Color;
        public float farClipPlane = 10f;
        public bool orthographic = true;
        public bool OcclusionCulling = true;


        public void SetFor(Camera camera)
        {
            // var urpCameraData = camera.GetUniversalAdditionalCameraData();
            // urpCameraData.renderType = RendererType;
            // urpCameraData.renderShadows = RenderShadows;

            camera.depth = depth;
            camera.clearFlags = clearFlags;
            camera.orthographic = orthographic;
            camera.farClipPlane = farClipPlane;
            camera.cullingMask = 1 << UIManager.I.Config.Layer;
            camera.useOcclusionCulling = OcclusionCulling;
        }
    }
}