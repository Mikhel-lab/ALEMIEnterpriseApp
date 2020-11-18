using System;
using System.Collections.Generic;
using System.Text;

namespace ALEMI.Services
{
	public interface ITaxService
	{
		decimal TaxAmount(decimal totalAmount);
	}
}
