using Murder;
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
            ItemListBox.Items.Clear();

            using (var context = new ItsOnlyHeroesEntities())
            {
                items = context.Items.Where(x => x.Active == true)
                    .Include(x => x.ItemType)
                    .Include(x => x.Stat)
                    .Include(x => x.CurrencyType)
                    .ToList();
            }

            ItemListBox.DisplayMember = "Name";
            ItemListBox.ValueMember = "ItemId";
            ItemListBox.Items.AddRange(items.ToArray());
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
            typeDescriptionTextBox.Text = "";
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

            UpdateItemListValues(item);

            //I know this looks stupid. It didn't work the way I thought it would. If you know a better way, lmk. - WH
            var curType = currencyTypes.Where(i => i.CurrencyTypeId == item.BuyCurrencyId).FirstOrDefault();
            currencyTypeComboBox.SelectedIndex = currencyTypeComboBox.Items.IndexOf(curType);

            var itemType = itemTypes.Where(i => i.ItemTypeId == item.ItemTypeId).FirstOrDefault();
            ItemTypeComboBox.SelectedIndex = ItemTypeComboBox.Items.IndexOf(itemType);

            costNumericUpDown.Value = item.BuyValue ?? 0;
            sellValueNumericUpDown.Value = item.SellValue ?? 0;

            typeDescriptionTextBox.Text = item.ItemType.ItemTypeDescription;
        }

        void UpdateItemListValues(Item item)
        {
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
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var itemToSave = (Item)ItemListBox.SelectedItem;
            if (itemToSave == null)
                return;

            using (var context = new ItsOnlyHeroesEntities())
            {
                Item item = new Item();

                if (itemToSave.ItemId > 0)
                {
                    item = context.Items.Find(itemToSave.ItemId);
                }
                else
                {
                    context.Items.Add(item);
                }

                var updatedItem = GetItemFromView();
                item.Name = updatedItem.Name;
                item.Stat = updatedItem.Stat;
                item.SellValue = updatedItem.SellValue;
                item.BuyValue = updatedItem.BuyValue;
                item.BuyCurrencyId = updatedItem.BuyCurrencyId;
                item.ItemTypeId = updatedItem.ItemTypeId;
                item.Active = updatedItem.Active;

                context.SaveChanges();
            }

            //probably not the best way to do this.
            GetItems();
            ItemListBox.SelectedItem = ItemListBox.Items.OfType<Item>()
                                        .Where(i => i.ItemId == itemToSave.ItemId)
                                        .FirstOrDefault();
        }

        private Item GetItemFromView()
        {
            Item item = NewItemBuilder();

            item.Name = itemNameTextBox.Text;

            item.Stat.Strength = (int)StrNumericUpDown.Value;
            item.Stat.Dexterity = (int)DexNumericUpDown.Value;
            item.Stat.Agility = (int)AgiNumericUpDown.Value;
            item.Stat.Wisdom = (int)WisNumericUpDown.Value;
            item.Stat.Intelligence = (int)IntNumericUpDown.Value;
            item.Stat.Charisma = (int)ChaNumericUpDown.Value;
            item.Stat.Constitution = (int)conNumericUpDown.Value;
            item.Stat.ElectricBonus = (int)eleNumericUpDown.Value;
            item.Stat.WaterBonus = (int)wtrNumericUpDown.Value;
            item.Stat.FireBonus = (int)firNumericUpDown.Value;
            item.Stat.EarthBonus = (int)earNumericUpDown.Value;
            item.Stat.HolyBonus = (int)hlyNumericUpDown.Value;
            item.Stat.DarkBonus = (int)drkNumericUpDown.Value;
            item.Stat.Armor = (int)armNumericUpDown.Value;
            item.Stat.MagicResist = (int)magNumericUpDown.Value;
            item.Stat.MagicPenetration = (int)apenNumericUpDown.Value;
            item.Stat.ArmorPenetration = (int)mpenNumericUpDown.Value;

            item.SellValue = (int)sellValueNumericUpDown.Value;
            item.BuyValue = (int)costNumericUpDown.Value;
            item.BuyCurrencyId = ((CurrencyType)currencyTypeComboBox.SelectedItem).CurrencyTypeId;
            item.ItemTypeId = ((ItemType)ItemTypeComboBox.SelectedItem).ItemTypeId;

            return item;
        }

        Item NewItemBuilder()
        {
            //something something dependency injection.
            Item item = new Item();
            item.Stat = new Stat();
            //these are always set to a default.
            item.ItemType = new ItemType();
            item.ItemTypeId = 1;
            item.CurrencyType = new CurrencyType();
            item.BuyCurrencyId = 1;
            item.Active = true;

            return item;
        }

        private void newItemButton_Click(object sender, EventArgs e)
        {
            Item item = NewItemBuilder();

            item.Name = "New Item";
            ItemListBox.Items.Add(item);
            ItemListBox.SelectedIndex = ItemListBox.Items.IndexOf(item);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var itemToDelete = (Item)ItemListBox.SelectedItem;
            if (itemToDelete == null)
                return;

            using (var context = new ItsOnlyHeroesEntities())
            {
                var item = context.Items.Find(itemToDelete.ItemId);
                if (item != null)
                {
                    item.Active = false;
                    context.SaveChanges();
                }

            }
        }

        private void addCurrencyTypeButton_Click(object sender, EventArgs e)
        {

            var newType = ItemTypeComboBox.Text;
            bool exists = ItemTypeComboBox.Items.OfType<ItemType>()
                                            .Where(i => i.ItemTypeName == newType).Any();

            if (exists) //if it exists, we should update it.
                return;

            var newItemType = new ItemType();
            newItemType.ItemTypeName = newType;
            newItemType.ItemTypeDescription = typeDescriptionTextBox.Text;

            using (var context = new ItsOnlyHeroesEntities())
            {
                context.ItemTypes.Add(newItemType);
                context.SaveChanges();
            }
        }
    }
}
