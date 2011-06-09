using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace WebFuzzer
{
	class AcceptAllCertificatePolicy : ICertificatePolicy
	{
		public AcceptAllCertificatePolicy()
		{
		}

		public bool CheckValidationResult(ServicePoint sPoint,
		   X509Certificate cert, WebRequest wRequest, int certProb)
		{
			// Always accept
			return true;
		}
	}
}
