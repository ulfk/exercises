using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bruchrechnen;

namespace BruchrechnenUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void KeyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (   !char.IsControl(e.KeyChar) 
                && !char.IsDigit(e.KeyChar) 
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (   e.KeyChar == '.' 
                && (sender as TextBox)?.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxZaehlerLinks_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressOnlyNumbers(sender, e);
        }

        private void textBoxNennerLinks_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressOnlyNumbers(sender, e);
        }

        private void textBoxZaehlerRechts_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressOnlyNumbers(sender, e);
        }

        private void textBoxNennerRechts_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyPressOnlyNumbers(sender, e);
        }

        private void Calculate()
        {
            if (CanCalculate())
            {
                var bruchLinks = new Bruch(GetIntValue(textBoxZaehlerLinks.Text), GetIntValue(textBoxNennerLinks.Text));
                var bruchRechts = new Bruch(GetIntValue(textBoxZaehlerRechts.Text), GetIntValue(textBoxNennerRechts.Text));
                var calcOperation = comboBoxCalcSelector.SelectedItem.ToString()[0];
                switch (calcOperation)
                {
                    case '+':
                        SetResult(bruchLinks + bruchRechts);
                        break;
                    case '-':
                        SetResult(bruchLinks - bruchRechts);
                        break;
                    case '*':
                        SetResult(bruchLinks * bruchRechts);
                        break;
                    case '/':
                        SetResult(bruchLinks / bruchRechts);
                        break;
                }
            }
            else
            {
                SetResult();
            }
        }

        private void SetResult(Bruch bruch = null)
        {
            var zaehler = "";
            var nenner = "";
            if (bruch != null)
            {
                zaehler = bruch.Zaehler.ToString();
                nenner = bruch.Nenner.ToString();
            }

            textBoxZaehlerErgebnis.Text = zaehler;
            textBoxNennerErgebnis.Text = nenner;
        }

        private bool CanCalculate()
        {
            return    IsValidValueAndNotZero(textBoxNennerLinks.Text)
                   && IsValidValueAndNotZero(textBoxNennerRechts.Text)
                   && IsValidValue(textBoxZaehlerLinks.Text)
                   && IsValidValue(textBoxZaehlerRechts.Text)
                   && IsCalcOperationSelected();
        }

        private bool IsCalcOperationSelected()
        {
            return comboBoxCalcSelector.SelectedItem != null;
        }

        private bool IsValidValueAndNotZero(string value)
        {
            return IsValidValue(value) && IsIntValueAndNotZero(value);
        }

        private bool IsValidValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && IsIntValue(value);
        }

        private bool IsIntValueAndNotZero(string value)
        {
            return int.TryParse(value, out int intValue) && intValue != 0;
        }

        private bool IsIntValue(string value)
        {
            return int.TryParse(value, out _);
        }

        private int GetIntValue(string value)
        {
            return int.Parse(value);
        }

        private void textBoxZaehlerLinks_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBoxNennerLinks_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBoxZaehlerRechts_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBoxNennerRechts_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBoxCalcSelector_SelectedValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
