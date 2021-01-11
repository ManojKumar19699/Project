using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriFarmProj.ViewModel
{
	public class InsuranceApp
	{
		public string FarmerId { get; set; }
		public string CompanyName { get; set; }
		public string Season { get; set; }
		public string Year { get; set; }
		public string CropName { get; set; }
		public int SumAssured { get; set; }
		public int SumAssuredPerHec { get; set; }
		public int Area { get; set; }
		public int Premium { get; set; }

	}
}