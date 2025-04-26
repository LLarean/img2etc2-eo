using System;
using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class TextureItemsTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Constructor_WithNullPath_DoesNotThrow(bool includeSubfolders)
        {
            Assert.DoesNotThrow(() => new TextureItems(null, includeSubfolders));
        }
        
        [Test]
        public void Content_WithNullPath_ListCount0()
        {
            var textureItems = new TextureItems(null);
            var content = textureItems.Content();
            Assert.AreEqual(content.Count, 0);
        }
        
        [Test]
        public void Content_WithEmptyPath_ListCount0()
        {
            var textureItems = new TextureItems(String.Empty);
            var content = textureItems.Content();
            Assert.AreEqual(content.Count, 0);
        }
    }
}