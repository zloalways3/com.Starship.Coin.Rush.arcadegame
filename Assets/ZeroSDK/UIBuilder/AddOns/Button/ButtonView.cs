using ZeroSDK.UIBuilder.Core;


namespace ZeroSDK.UIBuilder.AddOns.Button
{
    public class  ButtonView : ClickableView
    {
#if UNITY_EDITOR
	    protected override void LoadDefaultConfig()
        {
            base.LoadDefaultConfig();
            pointerDownAnimator = UIManager.I.Config.AddOns.ButtonDefaultDownAnimator;
            pointerUpAnimator = UIManager.I.Config.AddOns.ButtonDefaultUpAnimator;
        }	    
#endif
    }
}