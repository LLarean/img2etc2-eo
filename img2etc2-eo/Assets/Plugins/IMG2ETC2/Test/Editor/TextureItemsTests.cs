using NUnit.Framework;
using UnityEngine;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class TextureItemsTests
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void Constructor_WithNullPath_DoesNotThrow(bool includeSubfolders)
        {
            Assert.DoesNotThrow(() => new TextureItems(includeSubfolders, null));
        }
        
        [Test]
        public void Content_WithNullPath_ListCount0()
        {
            var textureItems = new TextureItems(false, null);
            var content = textureItems.Content();
            Assert.AreEqual(content.Count, 0);
        }
    }
}