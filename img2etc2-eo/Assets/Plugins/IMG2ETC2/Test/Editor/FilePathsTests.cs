using NUnit.Framework;

namespace LLarean.IMG2ETC2.Test.Editor
{
    public class FilePathsTests
    {
        [Test]
        public void Constructor_WithNullFolderPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new FilePaths(null));
        }
        
        [Test]
        public void Constructor_WithEmptyFolderPath_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => new FilePaths(string.Empty));
        }
    }
}
