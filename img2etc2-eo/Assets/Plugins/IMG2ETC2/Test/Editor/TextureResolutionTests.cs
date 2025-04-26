using NUnit.Framework;
using UnityEngine;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class TextureResolutionTests
    {
        [Test]
        [TestCase(2, 2)]
        [TestCase(5, 5)]
        public void Current_PassingTexture_ResolutionAreEqualPassedTexture(int width, int height)
        {
            var texture2D = new Texture2D(width, height);
            var textureResolution = new TextureResolution(texture2D);
            
            Assert.AreEqual(textureResolution.Current(), $"{width}x{height}");
        }

        [Test]
        [TestCase(4, 4)]
        [TestCase(8, 8)]
        public void CrunchStatus_PassNumbersMultiples4_ResolutionStatusIsCorrect(int width, int height)
        {
            var texture2D = new Texture2D(width, height);
            var textureResolution = new TextureResolution(texture2D);
            
            Assert.AreEqual(textureResolution.CrunchStatus(), ResolutionStatus.Correct);
        }

        [Test]
        [TestCase(5, 5)]
        [TestCase(9, 9)]
        public void CrunchStatus_PassNumbersNotMultiples4_ResolutionStatusIsWrong(int width, int height)
        {
            var texture2D = new Texture2D(width, height);
            var textureResolution = new TextureResolution(texture2D);
            
            Assert.AreEqual(textureResolution.CrunchStatus(), ResolutionStatus.Wrong);
        }
        
        [Test]
        [TestCase(2, 2)]
        public void Previous_SizeTextureNotChange_PreviousAreEqualCurrent(int width, int height)
        {
            var texture2D = new Texture2D(width, height);
            var textureResolution = new TextureResolution(texture2D);
            
            Assert.AreEqual(textureResolution.Previous(), textureResolution.Current());
        }

        [Test]
        [TestCase(2, 2)]
        public void Previous_SizeTextureChange_PreviousAreNotEqualCurrent(int width, int height)
        {
            var texture2D = new Texture2D(width, height);
            var textureResolution = new TextureResolution(texture2D);
            var current = textureResolution.Current();
            
            width++;
            height++;
            texture2D = new Texture2D(width, height);
            textureResolution = new TextureResolution(texture2D, current);

            
            Assert.AreNotEqual(textureResolution.Previous(), textureResolution.Current());
        }
    }
}
