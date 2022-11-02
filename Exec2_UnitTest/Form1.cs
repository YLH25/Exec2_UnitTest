using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exec2_UnitTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				string input = textBox1.Text;
				Open datetime = new Open();
				DateTime dateTime = Open.StringInput(input);

				TaiwanStockSystem taiwanStockSystem = new TaiwanStockSystem();
				bool canTrade = taiwanStockSystem.IsOpening(dateTime, 09, 00, 13, 30);
				if (canTrade)
				{
					MessageBox.Show("可以交易");
				}
				else
				{
					MessageBox.Show("不可以交易");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
	public class Open
	{
		public static DateTime StringInput(string input)
		{
			bool IsTrueTime = DateTime.TryParse(input, out DateTime result);
			if (IsTrueTime)
			{
				return result;
			}
			else
			{
				throw new Exception("請輸入正確時間格式,參考yyyy/MM/dd HH:mm:00");
			}
		}
	}
	public class TaiwanStockSystem
	{
		public bool IsOpening(DateTime dateTime, int openingHour, int openingMinute, int ClosingHour, int ClosingMinute)
		{
			int weeknum = (int)dateTime.DayOfWeek;
			string stringOpeningTime = dateTime.ToString($"yyyy/MM/dd {openingHour}:{openingMinute}:00");
			string stringClosingTime = dateTime.ToString($"yyyy/MM/dd {ClosingHour}:{ClosingMinute}:00");
			DateTime OpeningTime = Convert.ToDateTime(stringOpeningTime);
			DateTime ClosingTime = Convert.ToDateTime(stringClosingTime);
			if (weeknum == 0 || weeknum == 6 || dateTime < OpeningTime || dateTime > ClosingTime)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
