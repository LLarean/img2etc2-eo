using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class StatusColorTests
    {
        [Test]
        [TestCase(ResolutionStatus.Correct)]
        public void Value_ResolutionStatusIsCorrect_ColorIsGreen(ResolutionStatus resolutionStatus)
        {
            Assert.AreEqual(new StatusColor(resolutionStatus).Value(), StatusColors.green.ToString());
        }
        
        [Test]
        [TestCase(ResolutionStatus.Wrong)]
        public void Value_ResolutionStatusIsWrong_ColorIsYellow(ResolutionStatus resolutionStatus)
        {
            Assert.AreEqual(new StatusColor(resolutionStatus).Value(), StatusColors.yellow.ToString());
        }
    }
}
