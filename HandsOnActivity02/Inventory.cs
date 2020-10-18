using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandsOnActivity02
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private int _Quantity;
        private double _SellPrice;

        BindingSource showProductList = new BindingSource();

        bool isValid = true;
        
        public string Product_Name(string name)
        {
            try
            {
                if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    _ProductName = name;
                }
                else 
                {
                    isValid = false;
                    throw new StringFormatException("Invalid input of product name.");
                }
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show("Number Format: " + ex.Message);
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show("String Format: " + ex.Message);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show("Currency Format: " + ex.Message);
            }

            return _ProductName;
        }

        public int Quantity(string qty)
        {
            try
            {
                if (Regex.IsMatch(qty, @"^[0-9]"))
                {
                    _Quantity = Convert.ToInt32(qty);
                }
                else
                {
                    isValid = false;
                    throw new NumberFormatException("Invalid input of quantity.");
                }
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show("Number Format: " + ex.Message);
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show("String Format: " + ex.Message);
            }
            catch (CurrencyFormatException ex) 
            {
                MessageBox.Show("Currency Format: " + ex.Message);
            }

            return _Quantity;
        }

        public double SellingPrice(string price)
        {
            try
            {
                if (Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                {
                    _SellPrice = Convert.ToDouble(price);
                }
                else
                {
                    isValid = false;
                    throw new CurrencyFormatException("Invalid input of sell price.");
                }
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show("Number Format: " + ex.Message);
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show("String Format: " + ex.Message);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show("Currency Format: " + ex.Message);
            }

            return _SellPrice;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            if (isValid == true) 
            {
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            
        }

        public frmAddProduct()
        {
            InitializeComponent();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[] 
            {
                "Beverages", "Bread/Bakery", "Canned/Jarred Goods", "Dairy", "Frozen Goods",
                "Meat", "Personal Care", "Other"
            };
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }
    }
}
