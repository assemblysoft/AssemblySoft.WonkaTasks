using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AssemblySoft.DevOps;
using AssemblySoft.DevOps.Common;
using AssemblySoft.IO;

namespace AssemblySoft.WonkaTasks
{
    public class WonkaCore : NotifyTask
    {
        const string SOURCE_DEPENDENCIES = "Source-Dependencies";

        /// <summary>
        /// Simple console ping
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public async Task<DevOpsTaskStatus> Ping(string rootPath)
        {
            var args = string.Empty;

            try
            {
                Console.Write("Ping: {0}", rootPath);
            }
            catch (Exception e)
            {
                RaiseOutputEvent(string.Format("An error has occured: {0}", e.Message));
                return DevOpsTaskStatus.Terminated;
            }

            return DevOpsTaskStatus.Completed;
        }

        /// <summary>
        /// Copies Assets from source to target
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public async Task<DevOpsTaskStatus> CopyAssets(string rootPath)
        {
            try
            {
                var sourcePath = Path.Combine(Environment.GetEnvironmentVariable(SOURCE_DEPENDENCIES, EnvironmentVariableTarget.User), Constants.ASSETS);
                if (!Directory.Exists(sourcePath))
                {
                    RaiseOutputEvent(string.Format("Assets source directory does not exist: {0}", sourcePath));
                    return DevOpsTaskStatus.Terminated;
                }

                var targetPath = Path.Combine(rootPath, Constants.ASSETS);
                RaiseOutputEvent(string.Format("Copy assets from: {0} to: {1}", sourcePath, targetPath));
                DirectoryClient.DirectoryCopy(sourcePath, targetPath, true);


            }
            catch (IOException e)
            {
                RaiseOutputEvent(string.Format("An error has occured: {0}", e.Message));
                return DevOpsTaskStatus.Terminated;
            }

            return DevOpsTaskStatus.Completed;
        }

        /// <summary>
        /// Copies Tasks from source to target
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public async Task<DevOpsTaskStatus> CopyTasks(string rootPath)
        {
            try
            {
                var sourcePath = Path.Combine(Environment.GetEnvironmentVariable(SOURCE_DEPENDENCIES, EnvironmentVariableTarget.User), Constants.TASKS);
                if (!Directory.Exists(sourcePath))
                {
                    RaiseOutputEvent(string.Format("Tasks source directory does not exist: {0}", sourcePath));
                    return DevOpsTaskStatus.Terminated;
                }

                var targetPath = Path.Combine(rootPath, Constants.TASKS);
                RaiseOutputEvent(string.Format("Copy tasks from: {0} to: {1}", sourcePath, targetPath));
                DirectoryClient.DirectoryCopy(sourcePath, targetPath, true);


            }
            catch (IOException e)
            {
                RaiseOutputEvent(string.Format("An error has occured: {0}", e.Message));
                return DevOpsTaskStatus.Terminated;
            }

            return DevOpsTaskStatus.Completed;
        }

        /// <summary>
        /// Copies Scripts from source to target
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public async Task<DevOpsTaskStatus> CopyScripts(string rootPath)
        {
            try
            {
                var sourcePath = Path.Combine(Environment.GetEnvironmentVariable(SOURCE_DEPENDENCIES, EnvironmentVariableTarget.User), Constants.SCRIPTS);
                if (!Directory.Exists(sourcePath))
                {
                    RaiseOutputEvent(string.Format("scripts source directory does not exist: {0}", sourcePath));
                    return DevOpsTaskStatus.Terminated;
                }

                var targetPath = Path.Combine(rootPath, Constants.SCRIPTS);
                RaiseOutputEvent(string.Format("Copy scripts from: {0} to: {1}", sourcePath, targetPath));
                DirectoryClient.DirectoryCopy(sourcePath, targetPath, true);

            }
            catch (IOException e)
            {
                RaiseOutputEvent(string.Format("An error has occured: {0}", e.Message));
                return DevOpsTaskStatus.Terminated;
            }

            return DevOpsTaskStatus.Completed;
        }

    }
}
