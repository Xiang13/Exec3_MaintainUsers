using CRUD_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delete
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"DELETE FROM Users_table WHERE Id = @Id";
			var dbHelpers = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder().AddInt("Id", 6).Build();
				dbHelpers.ExecuteNonQuery(sql, parameters);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因是 {ex.Message}");
			}
		}
	}
}
