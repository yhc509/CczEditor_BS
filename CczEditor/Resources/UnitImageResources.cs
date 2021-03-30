#region using List

using System.Collections.Generic;
using System.Drawing;

#endregion

namespace CczEditor.Resources
{
    public class UnitImageResources : ImageResources
    {
        protected UnitImageResources(string fileName) : base(fileName) { }

        protected const int IMAGEINDEX_GENERALTHREETURN = 0;
        protected const int IMAGEINDEX_GENERALONETURN = 181;
        protected const int IMAGEINDEX_SPECIALTHREETURN = 240;
        protected const int IMAGEINDEX_SPECIALONETURN = 336;
        protected const int IMAGEINDEX_OTHER = 308;

        public int GetImageLength()
        {
            var count = GetLength();
            return count - IMAGEINDEX_OTHER + 4;
        }

        public KeyValuePair<int, Image>[] GetImages(int parm1, int parm2, int parm3)
        {
            int index;
            switch (parm1)
            {
                case 0:
                    {
                        switch (parm2)
                        {
                            case 0:
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                            case 6:
                            case 7:
                            case 8:
                            case 9:
                            case 10:
                            case 11:
                            case 12:
                            case 13:
                            case 14:
                            case 15:
                            case 16:
                            case 17:
                            case 18:
                            case 19:
                                {
                                    index = IMAGEINDEX_GENERALTHREETURN + parm2 * 9 + parm3;
                                    return new[]
							       {
							       	new KeyValuePair<int, Image>(index, GetImage(index)),
							       	new KeyValuePair<int, Image>(index+3, GetImage(index+3)),
							       	new KeyValuePair<int, Image>(index+6, GetImage(index+6))
							       };
                                }
                            case 20:
                            case 21:
                            case 22:
                            case 23:
                            case 24:
                            case 25:
                            case 26:
                            case 27:
                            case 28:
                            case 29:
                            case 30:
                            case 31:
                            case 32:
                            case 33:
                            case 34:
                            case 35:
                            case 36:
                            case 37:
                            case 38:
                            case 39:
                                {
                                    index = IMAGEINDEX_GENERALONETURN + (parm2 - 20) * 3 + parm3 - 1;
                                    return new[]
							       {
							       	new KeyValuePair<int, Image>(index, GetImage(index)),
							       	//new KeyValuePair<int, Image>(index+1, GetImage(index+1)),
							       	//new KeyValuePair<int, Image>(index+2, GetImage(index+2))
							       };
                                }
                            default:
                                break;
                        }
                        return null;
                    }
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                    {
                        index = IMAGEINDEX_SPECIALTHREETURN + (parm1 - 1) * 3;
                        return new[]
					       {
					       	new KeyValuePair<int, Image>(index, GetImage(index)),
					       	new KeyValuePair<int, Image>(index+1, GetImage(index+1)),
					       	new KeyValuePair<int, Image>(index+2, GetImage(index+2))
					       };
                    }
                default:
                    {
                        index = IMAGEINDEX_SPECIALONETURN + (parm1-33);
                        return new[]
					       {
					       	new KeyValuePair<int, Image>(index, GetImage(index))
					       };
                    }
            }
        }
    }
}