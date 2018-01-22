namespace FPOW.Droid.GameClasses
{
    internal static class GameImages
    {
        public static int[] GetGameImages(int level)
        {
            switch (level)
            {
                case 1:
                    return new int[] { Resource.Drawable.img1_1,
                        Resource.Drawable.img1_2,
                        Resource.Drawable.img1_3,
                        Resource.Drawable.img1_4 };
                case 2:
                    return new int[] { Resource.Drawable.img4_1,
                        Resource.Drawable.img4_2,
                        Resource.Drawable.img4_3,
                        Resource.Drawable.img4_4};
                case 3:
                    return new int[] { Resource.Drawable.img3_1,
                        Resource.Drawable.img3_2,
                        Resource.Drawable.img3_3,
                        Resource.Drawable.img3_4 };
                case 4:
                    return new int[] { Resource.Drawable.img2_1,
                        Resource.Drawable.img2_2,
                        Resource.Drawable.img2_3,
                        Resource.Drawable.img2_4 };
                case 5:
                    return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
                case 6:
                    return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
                case 7:
                    return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
                case 8:
                    return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
                case 9:
                    return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
                case 10:
                    return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
            }

            return new int[] { Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon,
                        Resource.Drawable.Icon };
        }
    }
}