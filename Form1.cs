namespace Exec_Game1A2B
{
    public partial class Form1 : Form
    {
		private Game1A2B game;
		public Form1()
        {
            InitializeComponent();
			game = new Game1A2B();
			label1.Text = String.Empty;
			label2.Text = String.Empty;
		}

        private void button2_Click(object sender, EventArgs e)
        {
            game.NewGame();
			//label2.Text = game.DisplayGameSet();
		}

		private void button1_Click(object sender, EventArgs e)
        {
			int[] input = new int[4];
			try
			{
				input[0] = SetNumber1();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				input[1] = SetNumber2();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				input[2] = SetNumber3();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				input[3] = SetNumber4();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			game.SetInput(input);
			game.Check();
			label1.Text = game.Result();
		}
		private int SetNumber1()
		{
			TextBox txt = textBox1;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int SetNumber2()
		{
			TextBox txt = textBox2;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int SetNumber3()
		{
			TextBox txt = textBox3;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int SetNumber4()
		{
			TextBox txt = textBox4;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int GetInt(TextBox txt, string input)
		{
			string value = txt.Text;
			bool Isint = int.TryParse(value, out int number);
			return Isint ? number : throw new Exception($"{input}必須要填值");
		}
	}
	public class Game1A2B
	{
		private int[] answer = new int[4];
		private int[] userinput = new int[4];
		private int countforsame = 0;
		private int countforposition = 0;
		private int winningnumber = 0;
		public void NewGame()
		{
			Random rnd = new Random();
			for (int i = 0; i < answer.Length; i++)
			{
				answer[i] = rnd.Next(0, 10);

				for (int j = 0; j < i; j++)
				{
					while (answer[j] == answer[i])
					{
						j = 0;
						answer[i] = rnd.Next(0, 10);
					}
				}
			}
		}
		public string DisplayGameSet()
		{
			return $"{answer[0]} - {answer[1]} - {answer[2]} - {answer[3]}";
		}
		public void SetInput(int[] set)
		{
			for (int i = 0; i < set.Length; i++)
			{
				userinput[i] = set[i];
			}
		}
		public void Check()
		{
			countforposition = 0;
			countforsame = 0;
			for (int i = 0; i < answer.Length; i++)
			{
				for (int j = 0; j < answer.Length; j++)
				{
					if (userinput[i] == answer[j])
					{
						countforsame++;
						break;
					}
				}
			}

			for (int i = 0; i < answer.Length; i++)
			{
				if (userinput[i] == answer[i]) countforposition++;
			}
		}
		public string Result()
		{
			if (countforposition == 4) return "數字正確";

			return $"{countforposition}A-{countforsame - countforposition}B";
		}
		public bool Winning()
		{
			if (winningnumber == 4) return true;
			else return false;
		}
	}
}