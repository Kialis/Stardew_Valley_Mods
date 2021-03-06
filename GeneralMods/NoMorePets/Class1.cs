﻿using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;

namespace Omegasis.NoMorePets
{
    public class Class1 :Mod
    {
        bool game_loaded;
        public override void Entry(IModHelper helper)
        {
            StardewModdingAPI.Events.GameEvents.UpdateTick += GameEvents_UpdateTick;
            StardewModdingAPI.Events.SaveEvents.AfterLoad += PlayerEvents_LoadedGame;
        }

        public void PlayerEvents_LoadedGame(object sender, EventArgs e)
        {
            game_loaded = true;
        }


        public void GameEvents_UpdateTick(object sender, EventArgs e)
        {
            if (game_loaded == false) return;
            List<NPC> my_npc_list = new List<NPC>();
            if (Game1.player == null) return;
            string pet_name = Game1.player.getPetName();
            if (Game1.player.currentLocation.name == "Farm")
            {
                foreach(NPC npc in Game1.player.currentLocation.characters)
                {
                  
                    if (npc.name == pet_name) my_npc_list.Add(npc);
                }
               foreach(var location in Game1.locations)
                {
                    if (location.name == "Farm" || location.name == "farm") StardewValley.Game1.removeCharacterFromItsLocation(pet_name);
                }
            }
        }
    }
}
