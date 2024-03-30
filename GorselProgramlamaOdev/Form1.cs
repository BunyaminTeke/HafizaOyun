using System.CodeDom.Compiler;

namespace GorselProgramlamaOdev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Button> buttons = new List<Button>();
        Random random = new Random();
        Queue<Button> queue = new Queue<Button>();
        int parlamaSayisi = 1;
        int flag = 0;
        List<Button> temp = new List<Button>();
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button item in this.Controls)
            {
                buttons.Add(item);
            }
            Shuffle(buttons);
            Parlat();
        }
        private void Parlat()
        {
            
            for (int i = 0; i < parlamaSayisi; i++)
            {
                temp.Add(buttons[i]);
                queue.Enqueue(buttons[i]);
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == temp.Count)
            {
                if (flag == 1 || flag is int)
                {
                    temp[flag - 1].BackColor = Color.FromArgb(74, 87, 102);
                }
                timer1.Stop();
                parlamaSayisi++;
            }
            else
            {
                if (flag != 0)
                {
                    temp[flag - 1].BackColor = Color.FromArgb(74, 87, 102);

                }
                temp[flag].BackColor = Color.Yellow;
                flag++;
            }
        }

        private void button84_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                if (clickedButton.Name == queue.Peek().Name)
                {
                    queue.Dequeue();
                    this.BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    
                    if (queue.Count == 0)
                    {
                        Parlat();
                    }
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Kaybettiniz");
                }
            }

        }

        private void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
