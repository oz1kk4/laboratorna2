using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Lab3
{
    internal static class OperationControlInvoker
    {
        public static void ExecuteOperation(OperationDo operationDo)
        {
            operationDo.PassOperation();
        }
    }

    internal interface OperationDo
    {
        void PassOperation();
    }

    internal class OperationDivide : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationDivide(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("/");
        }
    }

    internal class OperationMultiply : OperationDo
    {

        private OperationHandlerReceiver operationReceiver;

        public OperationMultiply(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("*");
        }
    }

    internal class OperationMinus : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationMinus(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("-");
        }
    }

    internal class OperationPlus : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationPlus(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("+");
        }
    }

    internal class OperationSquareRoot : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationSquareRoot(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("Sqrt");
        }
    }

    internal class OperationPower : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationPower(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("Pow");
        }
    }

    internal class OperationAre : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationAre(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("=");
        }
    }

    internal class OperationNaturalLogarithm : OperationDo
    {
        private OperationHandlerReceiver operationReceiver;

        public OperationNaturalLogarithm(OperationHandlerReceiver operationReceiver)
        {
            this.operationReceiver = operationReceiver;
        }

        public void PassOperation()
        {
            operationReceiver.PassOperation("Ln");
        }
    }

    internal class OperationHandlerReceiver
    {
        InputModifierReceiver inputModifierReceiver;
        TextBlock textBlock;

        public OperationHandlerReceiver
            (InputModifierReceiver inputModifierReceiver,
            TextBlock textBlock)
        {
            this.inputModifierReceiver = inputModifierReceiver;
            this.textBlock = textBlock;
            Register = 0;
        }

        private bool isOperationSet = false;
        private string operationPrevious;

        public double Register { get; set; }

        public void PassOperation(string operationUnit)
        {
            if (isOperationSet) // обчислити попередню операцію та додати поточну до пам'яті
            {
                ApplyPreviousOperation(operationPrevious);

                ApplyCurrentOperation(operationUnit);
            }
            else // додати поточну операцію до пам'яті
            {
                ApplyCurrentOperation(operationUnit);
            }
        }

        private void ApplyPreviousOperation(string operation)
        {
            switch (operation)
            {
                case "+":
                    this.Register += double.Parse(inputModifierReceiver.Register);
                    break;
                case "-":
                    this.Register -= double.Parse(inputModifierReceiver.Register);
                    break;
                case "*":
                    this.Register *= double.Parse(inputModifierReceiver.Register);
                    break;
                case "/":
                    this.Register /= double.Parse(inputModifierReceiver.Register);
                    break;
                case "Pow":
                    this.Register = Math.Pow(this.Register, double.Parse(inputModifierReceiver.Register));
                    break;
            }

            inputModifierReceiver.Register = this.Register.ToString();
        }

        private void ApplyCurrentOperation(string operation)
        {
            switch (operation)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                    operationPrevious = operation;
                    isOperationSet = true;
                    this.Register = double.Parse(inputModifierReceiver.Register);
                    textBlock.Text = inputModifierReceiver.Register;
                    textBlock.Text += " " + operationPrevious;
                    inputModifierReceiver.EditRegister("CE");
                    break;
                case "Pow":
                    operationPrevious = operation;
                    isOperationSet = true;
                    this.Register = double.Parse(inputModifierReceiver.Register);
                    textBlock.Text = inputModifierReceiver.Register;
                    textBlock.Text += " " + "^";
                    inputModifierReceiver.EditRegister("CE");
                    break;
                case "Sqrt":
                    Register = Math.Sqrt(double.Parse(inputModifierReceiver.Register));
                    isOperationSet = false;
                    inputModifierReceiver.Register = Register.ToString();
                    textBlock.Text = "";
                    break;
                case "Ln":
                    this.Register = Math.Log(double.Parse(inputModifierReceiver.Register));
                    isOperationSet = false;
                    inputModifierReceiver.Register = this.Register.ToString();
                    textBlock.Text = "";
                    break;
                case "=":
                    inputModifierReceiver.Register = this.Register.ToString();
                    isOperationSet = false;
                    textBlock.Text = "";
                    break;
            }
        }
    }
}

