using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CalculatorProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //so that the user cannot change the size of the window
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

        }

        public String user = "";

        //number 7
        private void button1_Click(object sender, EventArgs e)
        {
            user += button1.Text;
            label1.Text = user;
        }

        //number 8

        private void button2_Click(object sender, EventArgs e)
        {
            user += button2.Text;
            label1.Text = user;
        }


        //number 9
        private void button3_Click(object sender, EventArgs e)
        {
            user += button3.Text;
            label1.Text = user;
        }


        //number 6
        private void button7_Click(object sender, EventArgs e)
        {
            user += button7.Text;
            label1.Text = user;
        }


        //number 5
        private void button6_Click(object sender, EventArgs e)
        {
            user += button6.Text;
            label1.Text = user;

        }
        //number 4
        private void button5_Click(object sender, EventArgs e)
        {
            user += button5.Text;
            label1.Text = user;
        }

        //number 3
        private void button11_Click(object sender, EventArgs e)
        {
            user += button11.Text;
            label1.Text = user;
        }

        //number 2
        private void button10_Click(object sender, EventArgs e)
        {
            user += button10.Text;
            label1.Text = user;
        }

        //number 1
        private void button9_Click(object sender, EventArgs e)
        {
            user += button9.Text;
            label1.Text = user;
        }

        //number 0
        private void button12_Click(object sender, EventArgs e)
        {
            user += button12.Text;
            label1.Text = user;
        }

        //oper -
        private void button4_Click(object sender, EventArgs e)
        {
            if (evaluateOperator(user, true))
            {
                user += button4.Text;
                label1.Text = user;
            }
        }

        //oper +
        private void button8_Click(object sender, EventArgs e)
        {
            if (evaluateOperator(user, false))
            {
                user += button8.Text;
                label1.Text = user;
            }
        }

        //oper *
        private void button14_Click(object sender, EventArgs e)
        {
            if (evaluateOperator(user, false))
            {
                user += button14.Text;
                label1.Text = user;
            }
        }

        //oper .
        private void button15_Click(object sender, EventArgs e)
        {
            if (evaluateOperator(user, false))
            {
                user += button15.Text;
                label1.Text = user;
            }
        }

        //result
        private void button13_Click(object sender, EventArgs e)
        {


            try
            {
                user = evaluate(user).ToString();
                label1.Text = user;
            }//For unexcpected behavior
            catch (Exception)
            {
                user = "";
                label1.Text = "Error";
            }
        }

        //method that evaluates whether an operator is valid in that position
        public bool evaluateOperator(String input, bool minus)
        {
            if (input.Length == 0 && minus) return true;
            else if (input.Length == 0) return false;


            if (input[input.Length - 1] != '+' && input[input.Length - 1] != '-' && input[input.Length - 1] != '*' && input[input.Length - 1] != '/' && input[input.Length - 1] != '.')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //method that evaluates the user string input
        public double evaluate(String input)
        {

            String current = "";
            String prevValue = "";

            bool second = false;
            char firstOper = ' ';

            char[] letters = input.ToCharArray();

            int count = 0;
            int index = 0;

            foreach (char c in letters)
            {
                //if you find an operator
                if ((c == '-' || c == '/' || c == '*' || c == '+') && !(letters[0] == '-' && index == 0))
                {

                    //assign the currect to the prev value
                    if (!second)
                    {
                        prevValue = current;
                        firstOper = c;
                    }
                    else
                    {
                        try
                        {
                            double next = evaluate(current, prevValue, firstOper);
                            prevValue = next.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }


                    }

                    //reset the current
                    current = "";
                    second = !second;

                    count++;
                }
                else
                {
                    current += c;
                }

                index++;
            }

            if (prevValue.Length == 0)
            {
                return 0;
            }
            if (count == 1 || current != "")
            {
                try
                {
                    return evaluate(current, prevValue, firstOper);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return double.Parse(prevValue);
            }
        }

        public double evaluate(String a, String b, char oper)
        {
            try
            {
                switch (oper)
                {
                    case '+':

                        return double.Parse(a) + double.Parse(b);

                    case '-':
                        return double.Parse(b) - double.Parse(a);
                    case '*':
                        return double.Parse(a) * double.Parse(b);
                    case '/' when (double.Parse(a) == 0 || double.Parse(a) == 0): return double.Parse(b);
                    case '/':
                        return double.Parse(b) / double.Parse(a);
                    default:
                        return double.Parse(a) + double.Parse(b);
                }
            }
            catch (Exception e)
            {
                label1.Text = e.Message;
                throw;
            }
        }

        //oper /
        private void button16_Click(object sender, EventArgs e)
        {
            if (evaluateOperator(user, false))
            {
                user += button16.Text;
                label1.Text = user;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            user = "";
            label1.Text = user;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            String newUser = "";
            for (int i = 0; i < user.Length - 1; i++)
            {
                newUser += user[i];
            }

            user = newUser;
            label1.Text = user;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.BackColor = Color.FromArgb(21, 23, 60);
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.BackColor = Color.FromArgb(249, 84, 76);
        }

     
    }
}
