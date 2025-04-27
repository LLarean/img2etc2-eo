using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class TextureItemsTests
    {
        [Test]
        public void Constructor_WithNullPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new TextureItems(null));
        }
        
        [Test]
        public void Content_WithNullPath_ListCount0()
        {
            var textureItems = new TextureItems(null);
            var content = textureItems.Content();
            Assert.AreEqual(content.Count, 0);
        }
    }
}