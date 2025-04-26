using System;
using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class TextureItemTests
    {
        [Test]
        public void Constructor_WithNullPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new TextureItem(null));
        }
        
        [Test]
        public void Constructor_WithEmptyPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new TextureItem(String.Empty));
        }
    }
}
