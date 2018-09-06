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

namespace ItemCreationTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //This is generated code. Don't fuck with it.
            InitializeComponent();

            //May the fuckery begin.
            //ItemList.Items.Add("Sword");
            GetItems();
            GetItemTypes();
        }

        private void GetItems()
        {
            var itemsDto = new List<Item>();

            using (var context = new ItsOnlyHeroesEntities())
            {
                itemsDto = context.Items.ToList();            
            }

            ItemList.DisplayMember = "Name";
            ItemList.ValueMember = "ItemId";
            ItemList.Items.AddRange(itemsDto.ToArray());
        }

        private void GetItemTypes()
        {
            var itemTypes = new List<ItemType>();
            using (var context = new ItsOnlyHeroesEntities())
            {
                itemTypes = context.ItemTypes.ToList();
            }

            ItemTypeComboBox.DisplayMember = "ItemTypeName";
            ItemTypeComboBox.ValueMember = "ItemTypeId";
            ItemTypeComboBox.Items.AddRange(itemTypes.ToArray());
        }

    }
}
