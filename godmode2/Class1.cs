using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;
using TShockAPI.Hooks;

namespace GodMode2
{
    [ApiVersion(2, 1)]
    public class GodMode2 : TerrariaPlugin
    {
        private static Timer update;
        /// <summary>
        /// Gets the author(s) of this plugin
        /// </summary>
        public override string Author => "一维";

        /// <summary>
        /// Gets the description of this plugin.
        /// A short, one lined description that tells people what your plugin does.
        /// </summary>
        public override string Description => "GodMode For players";

        /// <summary>
        /// Gets the name of this plugin.
        /// </summary>
        public override string Name => "GodMode2";

        /// <summary>
        /// Gets the version of this plugin.
        /// </summary>
        public override Version Version => new Version(1, 1, 0, 0);

        public string[] HelpDesc { get; private set; }

        /// <summary>
        /// Initializes a new instance of the TestPlugin class.
        /// This is where you set the plugin's order and perfrom other constructor logic
        /// </summary>
        public GodMode2(Main game) : base(game)
        {

        }

        // Token: 0x06000015 RID: 21 RVA: 0x000029F8 File Offset: 0x00000BF8
        public override void Initialize()
        {
            ServerApi.Hooks.GameInitialize.Register(this, OnInitialize);
            update = new Timer { Interval = 1000, AutoReset = true, Enabled = true };
            update.Elapsed += OnElapsed;
        }

        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ServerApi.Hooks.GameInitialize.Deregister(this, OnInitialize);
            }
            base.Dispose(disposing);

        }

        // Token: 0x06000016 RID: 22 RVA: 0x00002A54 File Offset: 0x00000C54

        private void OnInitialize(EventArgs e)

        {
            Commands.ChatCommands.Add(new Command("godmode2", Cmd, "godmode2"));
        }    

        private void Cmd(CommandArgs args) => args.Player.SetBuff(10, 10000000, false);
    }
}
