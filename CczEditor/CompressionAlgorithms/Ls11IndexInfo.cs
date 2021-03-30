namespace CczEditor.CompressionAlgorithms
{
	public class Ls11IndexInfo
	{
		public int Length1 { get; set; }

		public int Length2 { get; set; }

		public int Offset { get; set; }

		public bool IsCompression
		{
			get
			{
				return Length1 != 0 && Length2 != 0 && Length1 != Length2;
			}
		}
	}
}