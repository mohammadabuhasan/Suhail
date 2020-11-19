using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suhail.Models
{
	public class Broker
	{

		public long ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public BrokerTypes Type { get; set; }
		public string PhoneNumer { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
		public string Bio { get; set; }
	}
}
