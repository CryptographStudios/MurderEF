﻿using Murder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace ItemCreationTool
{
    public partial class Form1 : Form
    {
        private List<Item> items;
        private List<ItemType> itemTypes;
        private List<CurrencyType> currencyTypes;

        public Form1()
        {
            //This is generated code. Don't fuck with it.
            InitializeComponent();

            //May the fuckery begin.
            //ItemList.Items.Add("Sword");
            GetItems();
            GetItemTypes();
            GetCurrencyTypes();
        }

        private void GetItems()
        {
            using (var context = new ItsOnlyHeroesEntities())
            {
                items = context.Items.Include(x => x.ItemType)
                    .Include(x=>x.Stat) 
                    .Include(x=>x.CurrencyType)
                    .ToList();         
            }

            ItemList.DisplayMember = "Name";
            ItemList.ValueMember = "ItemId";
            ItemList.Items.AddRange(items.ToArray());
        }

        private void GetItemTypes()
        {
            using (var context = new ItsOnlyHeroesEntities())
            {
                itemTypes = context.ItemTypes.ToList();
            }

            ItemTypeComboBox.DisplayMember = "ItemTypeName";
            ItemTypeComboBox.ValueMember = "ItemTypeId";
            ItemTypeComboBox.Items.AddRange(itemTypes.ToArray());
        }

        private void GetCurrencyTypes()
        {
            using (var context = new ItsOnlyHeroesEntities())
            {
                currencyTypes = context.CurrencyTypes.ToList();
            }
            currencyTypeComboBox.DisplayMember = "CurrencyTypeName";
            currencyTypeComboBox.ValueMember = "CurrencyTypeId";
            currencyTypeComboBox.Items.AddRange(currencyTypes.ToArray());
            var really = currencyTypeComboBox.Items.Contains(currencyTypes[0]);

        }

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (Item)(((ListBox)sender).SelectedItem);

            if (item == null)
                return;

            itemNameTextBox.Text = item.Name;
            StrNumericUpDown.Value = item.Stat.Strength;
            DexNumericUpDown.Value = item.Stat.Dexterity;
            AgiNumericUpDown.Value = item.Stat.Agility;
            WisNumericUpDown.Value = item.Stat.Wisdom;
            IntNumericUpDown.Value = item.Stat.Intelligence;
            ChaNumericUpDown.Value = item.Stat.Charisma;
            conNumericUpDown.Value = item.Stat.Constitution;
            eleNumericUpDown.Value = item.Stat.ElectricBonus;
            wtrNumericUpDown.Value = item.Stat.WaterBonus;
            firNumericUpDown.Value = item.Stat.FireBonus;
            earNumericUpDown.Value = item.Stat.EarthBonus;
            hlyNumericUpDown.Value = item.Stat.HolyBonus;
            drkNumericUpDown.Value = item.Stat.DarkBonus;
            armNumericUpDown.Value = item.Stat.Armor;
            magNumericUpDown.Value = item.Stat.MagicResist;
            apenNumericUpDown.Value = item.Stat.MagicPenetration;
            mpenNumericUpDown.Value = item.Stat.ArmorPenetration;

            //I know this looks stupid. It didn't work the way I thought it would. If you know a better way, lmk. - WH
            var curType = currencyTypes.Where(i => i.CurrencyTypeId == item.BuyCurrencyId).FirstOrDefault();
            currencyTypeComboBox.SelectedIndex = currencyTypeComboBox.Items.IndexOf(curType);

            var itemType = itemTypes.Where(i => i.ItemTypeId == item.ItemTypeId).FirstOrDefault();
            ItemTypeComboBox.SelectedIndex = ItemTypeComboBox.Items.IndexOf(itemType);

            costNumericUpDown.Value = item.BuyValue ?? 0;
            sellValueNumericUpDown.Value = item.SellValue ?? 0;
        }
    }
}