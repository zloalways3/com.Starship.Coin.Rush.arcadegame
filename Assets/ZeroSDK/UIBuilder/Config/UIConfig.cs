using UnityEngine;


namespace ZeroSDK.UIBuilder.Config
{
    public class UIConfig : ScriptableObject
    {
        public NamesConfig Names = new NamesConfig();
        public CameraConfig Camera = new CameraConfig();
        public CanvasConfig Canvas = new CanvasConfig();
        public CanvasScalerConfig CanvasScaler = new CanvasScalerConfig();
        public AnimationConfig Animation = new AnimationConfig();
        public AddOnsConfig AddOns = new AddOnsConfig();


        public LayerMask Layer => LayerMask.NameToLayer(Names.uiLayer);
    }
}