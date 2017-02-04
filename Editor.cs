using System;
using System.Drawing;
using System.Windows.Forms;

namespace PicrossEditor
{
    public partial class Editor : Form
    {
        public int[] pixels;

        public Editor(int width, int height)
        {
            InitializeComponent();

            //Build buttons
            int buttonBaseTop     = 100;
            int buttonBaseLeft    = 150;

            pixels = new int[width*height];

            int top = buttonBaseTop;
            int left = buttonBaseLeft;
            int counter = 0;
            int size = 30;
            int spacing = 1;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {//set up button
                    Button button = new Button();

                    button.Left = left;
                    button.Top = top;
                    button.Size = new Size(size, size);
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = System.Drawing.Color.White;

                    //this represents the button in the "pixels" array
                    button.Tag = counter;
                    
                    button.Click += pixelClick; //function

                    this.Controls.Add(button);

                    //set horizontal position for the next button
                    left += size + spacing;
                    //set counter for the next Tag
                    counter++;
                    
                }
                //set vertical position for the next button
                left = buttonBaseLeft;
                top += size + spacing;
            }

            
            saveText();



        }
        public void saveText()
        {//write out the array as list of numbers seperated by ,
            code.Text = "";

            Boolean first = true;

            foreach (int pixel in pixels)
            {
                //needed for avoiding starting with ,
                if (first)
                {
                    code.Text += pixel.ToString();
                    first = false;
                }
                else
                {
                    code.Text += "," + pixel.ToString();
                }

            }
        }

        public void pixelClick(object sender, EventArgs e)
        {//when you click a generated button
            Button thisOne = sender as Button;

            //the Tag represents the position of the button
            int thisTag = Int32.Parse(thisOne.Tag.ToString());

            //we change the "pixels" array values based on the color of the button 
            if (thisOne.BackColor == Color.Black)
            {//if it is black change it to white
                thisOne.BackColor = Color.WhiteSmoke;
                pixels[thisTag] = 0;         
            }
            else
            {//if it is white change it to black
                thisOne.BackColor = Color.Black;
                pixels[thisTag] = 1;
            }

            saveText();


        }

        private void Editor_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
        }

        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mainForm = new Form1();
            mainForm.Show();
        }

        
    }
}
