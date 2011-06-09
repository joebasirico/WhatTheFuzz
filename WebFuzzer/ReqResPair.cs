using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebFuzzer
{
	class ReqResPair
	{
		public string Request = "";
		public string Response = "";
		public string Host = "";
		public string Proxy = "";
		string _attackStr = "";
		string _name = "";

		public ReqResPair(string name, string attackStr)
		{
			_name = name;
			_attackStr = attackStr;
		}

		public override string ToString()
		{
			return _name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public string AttackString
		{
			get
			{
				return _attackStr;
			}
			set
			{
				_attackStr = value;
			}
		}
	}
}
