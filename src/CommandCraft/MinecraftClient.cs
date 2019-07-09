using System;
using System.Net;
using System.Threading.Tasks;
using CommandCraft.Commands;
using CoreRCON;



namespace CommandCraft
{
    /// <summary>
    /// Provides Minecraft command client.
    /// </summary>
    public sealed class MinecraftClient
    {
        #region Properties
        /// <summary>
        /// Gets RCON connection.
        /// </summary>
        private RCON Connection { get; }
        #endregion


        #region Constructors
        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="endpoint">Server endpoint</param>
        /// <param name="rconPassword">RCON protocol password</param>
        public MinecraftClient(IPEndPoint endpoint, string rconPassword = null)
        {
            if (endpoint == null)
                throw new ArgumentNullException(nameof(endpoint));
            this.Connection = new RCON(endpoint, rconPassword);
        }


        /// <summary>
        /// Creates instance.
        /// </summary>
        /// <param name="ipAddress">Server IP address</param>
        /// <param name="rconPort">RCON protocol access port</param>
        /// <param name="rconPassword">RCON protocol password</param>
        public MinecraftClient(IPAddress ipAddress, ushort rconPort = 25575, string rconPassword = null)
        {
            if (ipAddress == null)
                throw new ArgumentNullException(nameof(ipAddress));
            this.Connection = new RCON(ipAddress, rconPort, rconPassword);
        }
        #endregion


        #region Command execution
        /// <summary>
        /// Execute raw command.
        /// </summary>
        /// <param name="command">Command string</param>
        /// <returns></returns>
        public Task<string> ExecuteAsync(string command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            return this.Connection.SendCommandAsync(command);
        }


        /// <summary>
        /// Execute defined command.
        /// </summary>
        /// <param name="command">command</param>
        /// <returns></returns>
        public Task<string> ExecuteAsync<T>(T command)
            where T : struct, IMinecraftCommand
            => this.ExecuteAsync(command.Build());
        #endregion
    }
}
