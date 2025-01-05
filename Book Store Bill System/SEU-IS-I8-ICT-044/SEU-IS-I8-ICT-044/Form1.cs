using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEU_IS_I8_ICT_044
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        public class Book
        {
            public string Name { get; set; }
            public int AvailableQuantity { get; set; }
            public decimal Price { get; set; }

            public Book(string name, int availableQuantity, decimal price)
            {
                Name = name;
                AvailableQuantity = availableQuantity;
                Price = price;
            }
        }
        List<Book> books = new List<Book>
        {
            new Book("The Lord of the Rings", 25, 19.99m),
            new Book("Harry Potter and the Sorcerer's Stone", 30, 12.99m),
            new Book("To Kill a Mockingbird", 15, 8.99m),
            new Book("The Great Gatsby", 20, 11.99m),
            new Book("The Catcher in the Rye", 18, 9.99m),
            new Book("1984", 22, 10.99m),
            new Book("The Hitchhiker's Guide to the Galaxy", 10, 7.99m),
            new Book("The Alchemist", 12, 14.99m),
            new Book("The Silent Patient", 15, 12.99m)
         };

        private void label14_Click(object sender, EventArgs e)
        {

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            //Quantity.Text = {books.Capacity};


            // Validate inputs
            if (comboBoxBook.SelectedIndex == -1 || string.IsNullOrEmpty(txtQuantity.Text) || comboBoxMembership.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string selectedBook = comboBoxBook.SelectedItem.ToString();
            int quantity = int.Parse(txtQuantity.Text);
            string membership = comboBoxMembership.SelectedItem.ToString();

            // Find the selected book
            Book book = books.FirstOrDefault(b => b.Name == selectedBook);

            if (book == null)
            {
                MessageBox.Show("Book not found.");
                return;
            }

            if (quantity > book.AvailableQuantity)
            {
                MessageBox.Show("Quantity exceeds available stock.");
                return;
            }

            // Calculate total price
            decimal totalPrice = book.Price * quantity;

            // Apply discounts
            decimal discount = 0;

            // Bulk Purchase Discount
            if (totalPrice >= 50 && membership != "Club Member")
            {
                discount = totalPrice * 0.10m;
            }
            else
            {
                // Membership Discount
                if (membership == "Club Member")
                {
                    discount = totalPrice * 0.10m;
                }

                // Other Discounts
                if (selectedBook == "Harry Potter and the Sorcerer's Stone")
                {
                    discount += totalPrice * 0.12m;
                }
                else if (selectedBook == "The Hitchhiker's Guide to the Galaxy" || selectedBook == "The Alchemist")
                {
                    discount += totalPrice * 0.15m;
                }

                // Ensure no more than 2 discounts are applied
                discount = Math.Min(discount, totalPrice * 0.27m); // Max 27% discount
            }

            decimal finalPrice = totalPrice - discount;

            Price1.Text = $"{book.Price}";
            Quantity.Text = $"{book.AvailableQuantity}";

            // Display breakdown
            lblBreakdown.Text = $"Book Name: {book.Name}\n" +
                                $"Quantity: {quantity}\n" +
                                $"Price per item: {book.Price:C}\n" +
                                $"Total Price (Before Discount): {totalPrice:C}\n" +
                                $"Discount Applied: {discount:C}\n" +
                                $"Total Price (After Discount): {finalPrice:C}";


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //foreach (var book in books)
            //{
            //    comboBoxBook.Items.Add(book.Name);
            //}
            //comboBoxMembership.Items.Add("Club Member");
            //comboBoxMembership.Items.Add("Non-Member");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBoxBook.SelectedIndex = -1;
            txtQuantity.Clear();
            comboBoxMembership.SelectedIndex = -1;
            lblBreakdown.Text = "";
        }

        private void comboBoxMembership_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
