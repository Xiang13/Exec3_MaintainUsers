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
			string sql = @"UPDATE Users_table SET Name=@Name, Password=@Password
											WHERE Id = @Id";
			var dbHelpers = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder().AddNVarchar("Name", 50, "Chu")
															  .AddNVarchar("Password", 50, "11111")
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
