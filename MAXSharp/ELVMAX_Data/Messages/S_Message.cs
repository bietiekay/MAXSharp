using System;

namespace MAXSharp
{
	public class S_Message : IMAXMessage
	{
		#region IMAXMessage implementation
		public MAXMessageType MessageType {
			get {
				return MAXSharp.MAXMessageType.S;
			}
		}
		#endregion



	}
}

