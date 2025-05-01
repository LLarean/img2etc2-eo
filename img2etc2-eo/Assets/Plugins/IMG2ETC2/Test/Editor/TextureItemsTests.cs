using System;
using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class TextureItemsTests
    {
        [Test]
        public void Constructor_WithEmptyFilePath_DoesNotThrow()
        {
            var filePaths = new FilePaths(String.Empty);
            Assert.DoesNotThrow(() => new TextureItems(filePaths));
        }
    }
}