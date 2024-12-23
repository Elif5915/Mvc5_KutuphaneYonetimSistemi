using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc5_KutuphaneYonetimSistemi.Models.Entity;

namespace Mvc5_KutuphaneYonetimSistemi.Models.Classes
{
	public class Class1
	{
		//IEnumerable tek bir page oluşan viewde birden fazla tablodan verileri alıp onları tek sf üzerinde göstermek ve kullanmamıza yarayan yapıdır.
		public IEnumerable<Kitap> Deger1 { get; set; }
		public IEnumerable<Hakkimizda> Deger2 { get; set; }
	}
}