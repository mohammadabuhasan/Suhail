using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suhail.Models
{
	public class Parcel
	{
		public long ID { get; set; }
		public string BlockNumber { get; set; }
		public string Neighbourhood { get; set; }
		public string SubdivisionNumber { get; set; }
		public LandUseGroups LandUseGroup { get; set; }
		public decimal PriceOfMeter { get; set; }
		public string Description { get; set; }
		public List<Broker> OwnerBrokers { get; set; }
	}
}
