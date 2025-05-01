using System;
using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class ScrollViewTests
    {
        [Test]
        public void Constructor_EmptyTextureItems_DoesNotThrow()
        {
            var textureItems = new TextureItems(new FilePaths(String.Empty));
            Assert.DoesNotThrow(() => new ScrollView(new TextureScrollViewTest(), textureItems));
        }
        
        [Test]
        public void Content_EmptyTextureItems_DoesNotThrow()
        {
            var textureItems = new TextureItems(new FilePaths(String.Empty));
            Assert.DoesNotThrow(() => new ScrollView(new TextureScrollViewTest(), textureItems).Content());
        }
    }
    
    public record TextureScrollViewTest : IScrollView
    {
        public void Begin() { }

        public void End() { }
    }
}