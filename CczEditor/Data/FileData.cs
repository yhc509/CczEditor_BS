#region using List

using System;
using System.IO;
using System.Text;

using CczEditor.CompressionAlgorithms;

#endregion

namespace CczEditor.Data
{
	public class FileData
	{
		public FileData() { }

		public FileData(string fileName)
		{
			try
			{
				CurrentFile = new FileInfo(fileName);
				CurrentStream = CurrentFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
			}
			catch (Exception ex)
			{
				Utils.ShowError(ex.Message);
				CurrentStream = null;
				return;
			}
		}

        public bool IsExist => CurrentFile != null && CurrentStream != null;

		public FileInfo CurrentFile;

		public FileStream CurrentStream;

		private Ls11IndexInfoCollection _indexList;

		/// <summary>
		/// ls파일 색인나열
		/// </summary>
		public Ls11IndexInfoCollection IndexList
		{
			get
			{
				if (_indexList == null)
				{
					IndexListInit();
				}
				return _indexList;
			}
			set { _indexList = value; }
		}

		/// <summary>
		/// ls파일 여는가?
		/// </summary>
		public bool IsLsFile
		{
			get
			{
				if (CurrentStream == null || !CurrentStream.CanRead)
				{
					return false;
				}
				var fileType = new byte[4];
				CurrentStream.Read(fileType, 0, 4);
				return Encoding.Default.GetString(fileType, 0, 4).ToLower() == "ls12";
			}
		}

		public void IndexListInit()
		{
			if (CurrentStream == null || !CurrentStream.CanRead)
			{
				_indexList = null;
				return;
			}
			try
			{
				_indexList = new Ls11IndexInfoCollection();
				CurrentStream.Seek(0x110, SeekOrigin.Begin);
				Ls11IndexInfo index;
				var temp = new byte[4];
				while (true)
				{
					index = new Ls11IndexInfo();
					CurrentStream.Read(temp, 0, 4);
					index.Length1 = Ls11.Convert(temp);
					if (index.Length1 == 0)
					{
						break;
					}
					CurrentStream.Read(temp, 0, 4);
					index.Length2 = Ls11.Convert(temp);
					CurrentStream.Read(temp, 0, 4);
					index.Offset = Ls11.Convert(temp);
					_indexList.Add(index);
				}
			}
			catch (Exception)
			{
				_indexList = null;
				return;
			}
		}

		public void Decompression()
		{
			try
			{
				var dec = new Ls11();
				dec.Decode(CurrentStream);
				Utils.HintUser("파일 해독 성공!");
				IndexListInit();
			}
			catch (Exception)
			{
				Utils.ShowError("파일 해독 실패!");
				return;
			}
		}

		public bool IsCompression
		{
			get { return IndexList == null ? false : IndexList.IsCompression; }
		}

		public FileStream OpenRead()
		{
			return CurrentFile == null ? null : CurrentFile.OpenRead();
		}

		public FileStream OpenWrite()
		{
			return CurrentFile == null ? null : CurrentFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
		}

		public FileStream Open(FileAccess access)
		{
			return CurrentFile == null ? null : CurrentFile.Open(FileMode.Open, access, FileShare.ReadWrite);
		}

		public FileStream Open(FileShare share)
		{
			return CurrentFile == null ? null : CurrentFile.Open(FileMode.Open, FileAccess.ReadWrite, share);
		}

		public FileStream Open(FileAccess access, FileShare share)
		{
			return CurrentFile == null ? null : CurrentFile.Open(FileMode.Open, access, share);
		}
	}
}