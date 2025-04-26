using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class ScrollViewTests
    {
        [Test]
        public void Constructor_WithNullList_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new ScrollView(null));
        }
        
        [Test]
        public void Content_WithNullList_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new ScrollView(null).Content());
        }
    }
}