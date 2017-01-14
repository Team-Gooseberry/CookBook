﻿using CookBook.Common;
using CookBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookBook.Engine
{
    public partial class StartScreen : Form
    {
        protected Recipes Collection { get; set; }

        public StartScreen(Recipes collection)
        {
            InitializeComponent();
            this.Collection = collection;
            RecipesDisplay.Text = Collection.ToString();
            RecipesDisplay.ReadOnly = true;

            var types = Enum.GetNames(typeof(RecipeType)).ToList();
            types.Insert(0, String.Empty);
            TypeComboBox.DataSource = types;

            var recipeNames =
                from item in this.Collection.SortByTypeThenbyName().TheRecipes
                select item.Name;
            var recipeNamesList = recipeNames.Distinct().ToList();
            recipeNamesList.Insert(0, "");
            nameComboBox.DataSource = recipeNamesList;
        }



        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (productTextBox.Text!=null)
            {
                RecipesDisplay.Text = Collection.ByProduct(productTextBox.Text).ToString();
            }
        }
    }
}
