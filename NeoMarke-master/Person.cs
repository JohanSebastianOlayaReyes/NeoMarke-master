using System;
using System.collections.Generic;
using System.Ling;
using System.Text;
using System.Threading.Tasks

	namespace Entity.Model
	{
		public class Person
		{
			public int Id { get; set; }
			public string First_Name { get; set; } = string.Empty;
			public string Last_Name { get; set; } = string.Empty;
			public string Email {  get; set; } = string.Empty;
			public int Phone { get; set; } = string.Empty;
			public TypeIdentification Type { get; set; }
			public int number_identification { get; set; }
			public bool status { get; set; }
			public int IdUser { get; set; }
			public required User User { get; set; }

     }
	}
