using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Controls;
using System.Windows.Input;


namespace Lab3
{
    internal class InputControlInvoker
    {
        public static void ModifyInput(InputDo inputDo)
        {
            inputDo.PassInput();
        }
    }

    internal interface InputDo
    {
        void PassInput();
    }


    internal class InputOne : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputOne(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("1");
        }
    }

    internal class InputTwo : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputTwo(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("2");
        }
    }

    internal class InputThree : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputThree(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("3");
        }
    }

    internal class InputFour : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputFour(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("4");
        }
    }

    internal class InputFive : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputFive(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("5");
        }
    }

    internal class InputSix : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputSix(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("6");
        }
    }

    internal class InputSeven : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputSeven(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("7");
        }
    }

    internal class InputEight : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputEight(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("8");
        }
    }

    internal class InputNine : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputNine(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("9");
        }
    }

    internal class InputCE : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputCE(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("CE");
        }
    }

    internal class InputDeleteLast : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputDeleteLast(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("⟵");
        }
    }

    internal class InputZeroDouble : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputZeroDouble(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("00");
        }
    }

    internal class InputZero : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputZero(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("0");
        }
    }

    internal class InputDot : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputDot(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister(",");
        }
    }

    internal class InputPi : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputPi(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("Pi");
        }
    }

    internal class InputE : InputDo
    {
        private InputModifierReceiver inputReceiver;

        public InputE(InputModifierReceiver inputReceiver)
        {
            this.inputReceiver = inputReceiver;
        }

        public void PassInput()
        {
            inputReceiver.EditRegister("e");
        }
    }

    internal class InputModifierReceiver
    {
        private bool isDotSet = false;
        private TextBlock outputTextBlock;

        public InputModifierReceiver(TextBlock textBlock)
        {
            outputTextBlock = textBlock;
            Register = "0";
            EditOutputBlockText();
        }

        private string register;

        public string Register
        {
            get
            {
                return register;
            }
            set
            {
                register = value;
                outputTextBlock.Text = value;
            }
        }

        public void EditRegister(string inputUnit)
        {
            switch (inputUnit)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (Register != "0")
                    {
                        Register += inputUnit;
                    }
                    else
                    {
                        Register = inputUnit;
                    }
                    break;
                case "CE":
                    Register = "0";
                    isDotSet = false;
                    break;
                case "0":
                case "00":
                    if (Register != "0")
                    {
                        Register += inputUnit;
                    }
                    break;
                case ",":
                    if (!isDotSet)
                    {
                        Register += inputUnit;
                        isDotSet = true;
                    }
                    break;
                case "⟵":
                    if (Register != "0")
                    {
                        if (Register[^1].ToString() == ",")
                        {
                            Register = Register[..^1];
                            isDotSet = false;
                        }
                        else
                        {
                            if (Register.Length == 1)
                            {
                                Register = "0";
                            }
                            else
                            {
                                Register = Register[..^1];
                            }
                        }
                    }
                    break;
                case "Pi":
                    Register = Math.PI.ToString();
                    isDotSet = true;
                    break;
                case "e":
                    Register = Math.E.ToString();
                    isDotSet = true;
                    break;
            }

            /*if (double.Parse(Register) % (int)(double.Parse(Register)) != 0)
                isDotSet = true;*/


            EditOutputBlockText();
        }

        private void EditOutputBlockText()
        {
            outputTextBlock.Text = Register;
        }
    }
}
