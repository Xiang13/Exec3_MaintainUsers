using CRUD_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = "INSERT INTO Users_table(Name, Account, Password, DateOfBirthd, Height)" +
										"VALUES(@Name, @Account, @Password, @DateOfBirthd, @Height)";
			var dbHelpers = new SqlDbHelper("default");
			try
			{
				var parameters = new SqlParameterBuilder().AddNVarchar("Name", 50, "Hu")
															.AddNVarchar("Account", 50, "cbi")
															.AddNVarchar("Password", 50, "789")
															.AddInt("Height", 180)
															.AddDateTime("DateOfBirthd", new DateTime(1998, 05, 25, 6, 30, 15))
															.Build();

				dbHelpers.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("紀錄已新增");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因是 {ex.Message}");
			}
		}
	}
}
