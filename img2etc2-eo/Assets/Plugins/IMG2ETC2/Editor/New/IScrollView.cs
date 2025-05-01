#if UNITY_EDITOR
namespace LLarean.IMG2ETC2
{
    public interface IScrollView
    {
        void Begin();
        void DrawItem(string itemInfo);
        void End();
    }
}
#endif