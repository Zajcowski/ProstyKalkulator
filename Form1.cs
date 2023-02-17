namespace Kalkulator
{
    public enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        None,
    }
    public partial class form1 : Form
    {
        private string FirstValue;
        private string SecondValue;
        private Operation CurrentOperation = Operation.None;
        private bool isTheResultOnTheScreen = false;
        public form1()
        {
            InitializeComponent();
            tbWynik.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OnBtnNumberClick(object sender, EventArgs e)
        {
            var clickedValue = (sender as Button).Text;

            if(tbWynik.Text == "0" || isTheResultOnTheScreen)
            {
                tbWynik.Text = String.Empty;
                isTheResultOnTheScreen =false;
            }
                

            if(CurrentOperation != Operation.None)
            {
                SecondValue += clickedValue;
            }
            tbWynik.Text += clickedValue;
        }

        private void OnBtnResultClick(object sender, EventArgs e)
        {
            var firstNumber = double.Parse(FirstValue);
            var secondNumber = double.Parse(SecondValue);

            var result = 0d;

            switch (CurrentOperation)
            {
                case Operation.Addition:
                    result = firstNumber + secondNumber;
                    break;
                case Operation.Subtraction:
                    result = firstNumber - secondNumber;
                    break;
                case Operation.Multiplication:
                    result = firstNumber * secondNumber;
                    break;
                case Operation.Division:
                    if(secondNumber == 0)
                    {
                        MessageBox.Show("Nie mo¿na dzieliæ przez 0!");
                        result = 0;
                    }
                    result = firstNumber / secondNumber;
                    break;
                case Operation.None:
                    result = firstNumber;
                    break;
            }

            tbWynik.Text = result.ToString();
            SecondValue = string.Empty;
            CurrentOperation = Operation.None;
            isTheResultOnTheScreen = true;
        }

        private void OnBtnOperationClick(object sender, EventArgs e)
        {
            FirstValue = tbWynik.Text;
            var operation = (sender as Button).Text;

            CurrentOperation = operation switch
            {
                "+" => Operation.Addition,
                "-" => Operation.Subtraction,
                "/" => Operation.Division,
                "*" => Operation.Multiplication,
                _ => Operation.None,
            };

            tbWynik.Text += operation;
        }

        private void OnBtnDelClick(object sender, EventArgs e)
        {
            tbWynik.Text = "0";
            FirstValue = String.Empty;
            SecondValue = String.Empty;
            CurrentOperation = Operation.None;
        }
    }
}