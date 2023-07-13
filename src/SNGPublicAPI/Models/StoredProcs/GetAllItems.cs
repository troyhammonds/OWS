﻿using System;

namespace SNGPublicAPI.Models.StoredProcs
{
    public class GetAllItems
    {
        public GetAllItems()
        {

        }

        public Guid CustomerGuid { get; set; }
        public int ItemId { get; set; }
        public int ItemTypeId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemWeight { get; set; }
        public bool ItemCanStack { get; set; }
        public short ItemStackSize { get; set; }
        public bool ItemIsUsable { get; set; }
        public bool? ItemIsConsumedOnUse { get; set; }
        public string CustomData { get; set; }
        public int DefaultNumberOfUses { get; set; }
        public int ItemValue { get; set; }
        public string ItemMesh { get; set; }
        public string MeshToUseForPickup { get; set; }
        public string TextureToUseForIcon { get; set; }
        public int PremiumCurrencyPrice { get; set; }
        public int FreeCurrencyPrice { get; set; }
        public int ItemTier { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCode { get; set; }
        public int ItemDuration { get; set; }
        public bool? CanBeDropped { get; set; }
        public bool CanBeDestroyed { get; set; }
        public string WeaponActorClass { get; set; }
        public string StaticMesh { get; set; }
        public string SkeletalMesh { get; set; }
        public short ItemQuality { get; set; }
        public int IconSlotWidth { get; set; }
        public int IconSlotHeight { get; set; }
        public int ItemMeshID { get; set; }
        public string ItemTypeDesc { get; set; }
    }
}
