using CRUD_Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace READ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var dbHelpers = new SqlDbHelper("default");
			string sql = "SELECT Id, Name, Height, DateOfBirthd FROM Users_table WHERE Id > @Id";
			
			try
			{
				var parameters = new SqlParameterBuilder().AddInt("Id", 0).Build();

				DataTable data = dbHelpers.Select(sql, parameters);
				foreach (DataRow row in data.Rows)
				{
					int id = row.Field<int>("Id");
					string Name = row.Field<string>("Name");
					int Height = row.Field<int>("Height");
					DateTime DateOfBirthd = row.Field<DateTime>("DateOfBirthd");
					Console.WriteLine($"{id}, {Name}, {Height}, {DateOfBirthd}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗, 原因是 {ex.Message}");
			}
		}
	}
}
