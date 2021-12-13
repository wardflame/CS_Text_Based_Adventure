using CLADII_TextBasedAdventure.EntityContent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CLADII_TextBasedAdventure.SaveSystem
{
    class SaveData
    {

        // NEED SAVE OBJECT WITH ALL INFORMATION STORED IN IT.
        public static void Directories(HumanEntity player)
        {
            if (!Directory.Exists($"Saves\\{player.name}"))
            {
                Directory.CreateDirectory($"Saves\\{player.name}");
            }
        }

        public static void Save(HumanEntity player)
        {
            string save = JsonConvert.SerializeObject(player);
            int saveCount = Directory.GetFiles("Saves").Length;
            File.WriteAllText($"Saves\\{player.name}\\{player.name} {saveCount + 1}.json", save);
        }

        public static EntityData Load()
        {
            return JsonConvert.DeserializeObject<HumanEntity>(File.ReadAllText("Saves\\save"));
        }
    }
}
