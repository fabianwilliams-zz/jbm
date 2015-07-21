using System;

namespace jbm
{
	public class Beer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public double Abv { get; set; }
		public double Ibu { get; set; }
		public string Taste { get; set; }
		public string ProName { get; set; }
		public string Smu {get; set;}
	}

	public class RootBeers
	{
		public Beer[] rbeers { get; set; }
	}

}

