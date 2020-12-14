using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Accessories
{
    public class MagmaCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Crystal");
            Tooltip.SetDefault("Provides immunity to lava \nYou can walk on liquids");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 28;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Orange;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            if (modPlayer.ww)
                player.waterWalk = true;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WaterWalkingGem", 1);
            recipe.AddIngredient(null, "ObsidianSkinGem", 1);
            recipe.AddTile(null, "CrystalineInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}