using Cysharp.Threading.Tasks;
using ZeroSDK.GameCore.Interfaces;
using ZeroSDK.Utility.Singleton;


namespace ZeroSDK.GameCore.Manager
{
    public abstract class SingleManager<T> : SingleScript<T>, IInitable where T : SingleScript<T>
    {
        public abstract void Init();
    }
}