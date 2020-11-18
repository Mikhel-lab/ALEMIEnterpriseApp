using System;
using System.Collections.Generic;
using System.Text;

namespace ALEMI.Services
{
	public interface INationalInsuranceContributionService
	{
		decimal NIContribution(decimal totalAmount);
	}
}
