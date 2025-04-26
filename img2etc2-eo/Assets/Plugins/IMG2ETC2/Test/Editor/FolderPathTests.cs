using System;
using System.IO;
using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class FolderPathTests
    {
        [Test]
        public void Constructor_WithNullPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new FolderPath(null));
        }
        
        [Test]
        public void Constructor_WithEmptyPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new FolderPath(string.Empty));
        }
        
        [Test]
        public void Value_WithNullPath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FolderPath(null).Value());
        }
        
        [Test]
        public void Value_WithEmptyPath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FolderPath(string.Empty).Value());
        }
        
        [Test]
        public void Value_PathNotExist_DirectoryNotFoundException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => new FolderPath("./not-exist").Value());
        }
        
        [Test]
        public void Value_InvalidPathChars_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FolderPath("<>\"|?*#$%^&*()@").Value());
        }
        
        [Test]
        public void Value_DiskCPath_ReferenceEquals()
        {
            Assert.AreEqual(new FolderPath("C:\\").Value(), "C:\\");
        }
    }
}