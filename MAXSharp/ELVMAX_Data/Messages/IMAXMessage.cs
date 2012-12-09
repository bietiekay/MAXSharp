using System;

namespace MAXSharp
{
	public interface IMAXMessage
	{
		MAXMessageType MessageType { get; }
	}
}

