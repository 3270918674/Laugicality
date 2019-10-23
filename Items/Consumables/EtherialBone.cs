﻿using Laugicality.Items.Loot;
using Laugicality.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Projectiles.Special;

namespace Laugicality.Items.Consumables
{
	public class EtherialBone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Etherial Crown");
            Tooltip.SetDefault("Summons Skeletron");
        }

        public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 20;
			item.rare = ItemRarityID.Blue;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			//item.UseSound = SoundID.Item44;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<GeneralBossSpawn>(), NPCID.SkeletronHead, knockBack, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (!Main.dayTime && LaugicalityWorld.downedEtheria && NPC.CountNPCS(NPCID.SkeletronHead) < 1);
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 3);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
			recipe.AddRecipe();
        }
	}
}