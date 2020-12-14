using Laugicality.Buffs;
using Laugicality.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Items.Consumables.Potions
{
	public class IllusionPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+100% Mystic Duration\n5 minute duration");
        }
        public override void SetDefaults()
		{
			item.width = 24;
			item.height = 24;
			item.maxStack = 30;
			item.rare = ItemRarityID.Blue;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
            item.value = Item.sellPrice(silver: 2);
        }
        

        public override bool UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<IllusionBoost>(), 5*60*60, true);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "AlbusDust", 1);
            recipe.AddIngredient(null, "RegisDust", 1);
            recipe.AddIngredient(null, "MagmaSnapper", 1);
            recipe.AddIngredient(ModContent.ItemType<LavaGemItem>(), 1);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}