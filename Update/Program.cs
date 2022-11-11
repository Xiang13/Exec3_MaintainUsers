using CRUD_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"UPDATE Users_table SET Name=@Name, Account=@Account, Password=@Password,
												  DateOfBirthd=@DateOfBirthd, Height=@Height
												  WHERE Id = @Id";
			var dbHelpers = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder().AddNVarchar("Name", 50, "Judy")
															  .AddNVarchar("Account", 50, "3344")
															  .AddNVarchar("Password", 50, "dsaddadasd")
															  .AddDateTime("DateOfBirthd", new DateTime(2000, 01, 01))
															  .AddInt("Height", 190)
															  .AddInt("Id", 2)
															  .Build();
				dbHelpers.ExecuteNonQuery(sql, parameters);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因是 {ex.Message}");
			}
		}
	}
}
