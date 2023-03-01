namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            string inputText = RepeatCounter.readFile(fileName).Replace(" ", "");
            var a = RepeatCounter.getRepeatsByCode(inputText);
            richTextBox1.Text = RepeatCounter.dictToString(a);
            RepeatCounter.writeFile(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text;
            string inputText = RepeatCounter.readFile(fileName).Replace(" ", "");
            var a = RepeatCounter.getRepeatsByOccurrence(inputText);
            richTextBox1.Text = RepeatCounter.dictToString(a);
            RepeatCounter.writeFile(a);
        }
    }
}