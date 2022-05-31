using System.Collections.Generic;
using System.Linq;

using MainProject.Contracts.Entities.ValueObjects;
using MainProject.Enums;

namespace MainProject.Services
{
    internal static class ItemSizeManager
    {
        public static SizeType GetSizeType(VolumeWeightData data)
        {
            var allSize = new long[]
                { data.Height, data.Length, data.Width, data.PackagedHeight, data.PackagedLength, data.PackagedWidth };

            long maxSize = allSize[0];
            for (int i = 1; i < allSize.Length; i++)
            {
                if (allSize[i] > maxSize)
                {
                    maxSize = allSize[i];
                }
            }

            if (maxSize > 100)
            {
                return SizeType.Max;
            }

            if (data.PackagedWeight > 10000 || data.Weight > 10000)
            {
                return SizeType.Max;
            }

            long packagedVolume = data.PackagedHeight * data.PackagedLength * data.PackagedWidth;
            long volume = data.Height * data.Length * data.Width;

            long minVolume = packagedVolume < volume ? packagedVolume : volume;

            if (minVolume < 10000)
            {
                return SizeType.Small;
            }

            if (minVolume < 30000)
            {
                return SizeType.Medium;
            }

            return SizeType.Max;
        }
    }
}