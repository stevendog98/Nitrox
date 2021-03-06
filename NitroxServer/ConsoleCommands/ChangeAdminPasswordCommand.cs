﻿using System;
using System.Collections.Generic;
using System.Linq;
using NitroxModel.DataStructures;
using NitroxModel.DataStructures.Util;
using NitroxModel.Logger;
using NitroxModel.Packets;
using NitroxServer.ConsoleCommands.Abstract;
using NitroxServer.GameLogic;
using NitroxServer.GameLogic.Entities;
using NitroxModel.DataStructures.GameLogic;
using NitroxServer.ConfigParser;

namespace NitroxServer.ConsoleCommands
{
    internal class ChangeAdminPasswordCommand : Command
    {
        private readonly PlayerManager playerManager;
        private readonly ServerConfig serverConfig;

        public ChangeAdminPasswordCommand(PlayerManager playerManager, ServerConfig serverConfig) : base("changepassword", Perms.ADMIN, "<password>", "Change the admin password")
        {
            this.playerManager = playerManager;
            this.serverConfig = serverConfig;
        }

        public override void RunCommand(string[] args, Optional<Player> player)
        {
            try
            {
                string playerName = player.Get().Name;
                ChangePassword(args, playerName);
            }
            catch (Exception ex)
            {
                Log.Error("Error attempting to change password: " + args[0], ex);
            }
        }

        public override bool VerifyArgs(string[] args)
        {
            return args.Length >= 1;
        }

        private void ChangePassword(string[] args, string player)
        {
            Log.Info("Server Password changed to: " + serverConfig.ChangeServerAdminPassword(args[0]) + " By:" + player);
        }
    }
}
