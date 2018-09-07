using AssemblySoft.DevOps.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblySoft.WonkaTasks.UnitTests
{
    [TestFixture]
    public class CoreTests
    {
        const string SOURCE_DEPENDENCIES = "Source-Dependencies";

        [Test]
        public void CanCopyAssetDependenciesToTarget()
        {
            //Arrange                         
            System.Environment.SetEnvironmentVariable(SOURCE_DEPENDENCIES, ConfigurationManager.AppSettings["sourceTaskDefinitionPath"], EnvironmentVariableTarget.User);
            var tempPath = Path.GetTempPath();


            var targetPath = Path.Combine(tempPath, Constants.ASSETS);

            if (Directory.Exists(targetPath))
                throw new Exception("test directory already exists");

            //Act
            var wonkaCore = new WonkaCore();
            wonkaCore.CopyAssets(targetPath);


            //Assert
            Assert.True(Directory.Exists(targetPath));


            //Cleanup
            Directory.Delete(targetPath, true);

        }

    }
}
