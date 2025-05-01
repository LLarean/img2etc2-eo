using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class ResolutionInfoTests
    {
        [Test]
        [TestCase("10x10", "10x10")]
        public void Value_CurrentAndPreviousAreEqual_ColorIsGreen(string currentResolution, string previousResolution)
        {
            var resolutionInfo = new ResolutionInfo(currentResolution, previousResolution);
            var resolutionText = $"<color=white>Resolution: {currentResolution}</color>";
            Assert.AreEqual(resolutionInfo.Value(), resolutionText);
        }
        
        [Test]
        [TestCase("10x10", "8x8")]
        public void Value_CurrentAndPreviousAreNotEqual_ColorIsGreen(string currentResolution, string previousResolution)
        {
            var resolutionInfo = new ResolutionInfo(currentResolution, previousResolution);
            var resolutionText = $"<color=white>Resolution: {previousResolution} => {currentResolution}</color>";
            Assert.AreEqual(resolutionInfo.Value(), resolutionText);
        }
    }
}