using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        RightPanel rightPanel;

        InputModifierReceiver inputModifierReceiver;

        OperationHandlerReceiver operationHandlerReceiver;


        public MainWindow()
        {
            InitializeComponent();

            rightPanel = new RightPanel(GridCalcButtons);

            inputModifierReceiver = 
                new InputModifierReceiver(Output2);

            operationHandlerReceiver = 
                new OperationHandlerReceiver(inputModifierReceiver, Output1);
        }

        private void AdditionPanel_Click(object sender, RoutedEventArgs e)
        {
            rightPanel.ShowHidePanel();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputOne(inputModifierReceiver));
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputTwo(inputModifierReceiver));
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputThree(inputModifierReceiver));
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputFour(inputModifierReceiver));
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputFive(inputModifierReceiver));
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputSix(inputModifierReceiver));
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputSeven(inputModifierReceiver));
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputEight(inputModifierReceiver));
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputNine(inputModifierReceiver));
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputCE(inputModifierReceiver));
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            Output1.Text = "";

            Output2.Text = "0";

            inputModifierReceiver =
                new InputModifierReceiver(Output2);

            operationHandlerReceiver =
                new OperationHandlerReceiver(inputModifierReceiver, Output1);
        }

        private void DeleteLast_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputDeleteLast(inputModifierReceiver));
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationDivide(operationHandlerReceiver));
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationMultiply(operationHandlerReceiver));
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationMinus(operationHandlerReceiver));
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationPlus(operationHandlerReceiver));
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationAre(operationHandlerReceiver));
        }

        private void ZeroDouble_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputZeroDouble(inputModifierReceiver));
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputZero(inputModifierReceiver));
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputDot(inputModifierReceiver));
        }

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputPi(inputModifierReceiver));
        }

        private void E_Click(object sender, RoutedEventArgs e)
        {
            InputControlInvoker.
                ModifyInput(new InputE(inputModifierReceiver));
        }

        private void SquareRoot_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationSquareRoot(operationHandlerReceiver));
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationPower(operationHandlerReceiver));
        }

        private void Ln_Click(object sender, RoutedEventArgs e)
        {
            OperationControlInvoker.
                ExecuteOperation
                (new OperationNaturalLogarithm(operationHandlerReceiver));
        }
    }
}
