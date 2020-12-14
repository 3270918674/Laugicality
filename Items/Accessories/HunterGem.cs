using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class HunterGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shows the location of enemies\nUse to toggle this effect in higher tier gems.");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = Item.sellPrice(silver: 50);
            item.rare = ItemRarityID.Green;
            item.accessory = true;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.detectCreature = true;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer.Get(player).hunter = !LaugicalityPlayer.Get(player).hunter;
            Main.NewText(LaugicalityPlayer.Get(player).hunter.ToString(), 250, 250, 0);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(304, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}