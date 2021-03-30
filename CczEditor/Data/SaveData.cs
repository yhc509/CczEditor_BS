#region using List

using System;
using System.Collections.Generic;
using System.IO;

#endregion

namespace CczEditor.Data
{
    /*
	public class SaveData : FileData
	{
		public const int SAVE_UNIT_LENGTH = Program.SAVE_UNIT_LENGTH;

		public SaveData(string fileName) : base(fileName) { }

		public int Gold
		{
			get
			{
				var offset = Program.CurrentConfig.Offsets["Save_Gold_Offset"];
				var value = new byte[4];
				CurrentStream.Seek(offset, SeekOrigin.Begin);
				CurrentStream.Read(value, 0, 4);
				return BitConverter.ToInt32(value, 0);
			}
			set
			{
				var offset = Program.CurrentConfig.Offsets["Save_Gold_Offset"];
				CurrentStream.Seek(offset, SeekOrigin.Begin);
				CurrentStream.Write(BitConverter.GetBytes(value), 0, 4);
			}
		}

		public byte LoyalTreacherousValue
		{
			get
			{
				var offset = Program.CurrentConfig.Offsets["Save_LoyalTreacherousValue_Offset"];
				CurrentStream.Seek(offset, SeekOrigin.Begin);
				return (byte)CurrentStream.ReadByte();
			}
			set
			{
				var offset = Program.CurrentConfig.Offsets["Save_LoyalTreacherousValue_Offset"];
				CurrentStream.Seek(offset, SeekOrigin.Begin);
				CurrentStream.WriteByte(value);
			}
		}

		public List<string> ItemEquipmentNameList
		{
			get
			{
				var offset = Program.CurrentConfig.Offsets["Save_ItemEquipment_Offset"];
				Program.LoadGameData();
				var itemNames = Program.GameData.ItemNameList(true);
				var list = new List<string>();
				const int length = 0x3, count = Program.SAVE_ITEM_EQUIPMENT_COUNT;
				var data = new byte[length*count];
				CurrentStream.Seek(offset, SeekOrigin.Begin);
				CurrentStream.Read(data, 0, length*count);
				for (var i = 0; i < count; i++)
				{
					if (data[length*i] == 0xFF)
					{
						list.Add(string.Format(Program.FORMATSTRING_SAVEEQUIPMENT, i, "없음"));
					}
					else
					{
						list.Add(string.Format(Program.FORMATSTRING_SAVEEQUIPMENT, i, itemNames[data[length*i]]));
					}
				}
				return list;
			}
		}

		public byte[] ItemEquipmentGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Save_ItemEquipment_Offset"];
			const int length = 0x3;
			var item = new byte[length];
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Read(item, 0, length);
			return item;
		}

		public void ItemEquipmentSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Save_ItemEquipment_Offset"];
			const int length = 0x3;
			CurrentStream.Seek(offset+index*length, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, length);
		}

		public byte ItemAmountGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Save_ItemAmount_Offset"];
			CurrentStream.Seek(offset+index, SeekOrigin.Begin);
			return (byte)CurrentStream.ReadByte();
		}

		public void ItemAmountSet(int index, byte value)
		{
			var offset = Program.CurrentConfig.Offsets["Save_ItemAmount_Offset"];
			CurrentStream.Seek(offset+index, SeekOrigin.Begin);
			CurrentStream.WriteByte(value);
		}

		public byte[] UnitGet(int index)
		{
			var offset = Program.CurrentConfig.Offsets["Save_Unit_Offset"];
			var unit = new byte[SAVE_UNIT_LENGTH];
			CurrentStream.Seek(offset+index*SAVE_UNIT_LENGTH, SeekOrigin.Begin);
			CurrentStream.Read(unit, 0, SAVE_UNIT_LENGTH);
			return unit;
		}

		public void UnitSet(int index, byte[] value)
		{
			var offset = Program.CurrentConfig.Offsets["Save_Unit_Offset"];
			CurrentStream.Seek(offset+index*SAVE_UNIT_LENGTH, SeekOrigin.Begin);
			CurrentStream.Write(value, 0, SAVE_UNIT_LENGTH);
		}
	}*/
}