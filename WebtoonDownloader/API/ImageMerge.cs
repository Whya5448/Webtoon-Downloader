﻿using System;
using System.Drawing;
using System.IO;

namespace WebtoonDownloader.API
{
	static class ImageMerge
	{
		public static void Merge( string dir )
		{
			string[ ] files = Directory.GetFiles( dir + @"\이미지\", "image_*.jpg" );

			Array.Sort( files, new Sort.NaturalStringComparer( ) );

			int maxW = 0;
			int totalH = 0;

			foreach ( string i in files )
			{
				Image img = Image.FromFile( i );

				totalH += img.Size.Height;

				if ( maxW < img.Size.Width )
				{
					maxW = img.Size.Width;
				}
			}

			Bitmap bmap = new Bitmap( maxW, totalH );
			Graphics g = Graphics.FromImage( bmap );

			int y = 0;
			foreach ( string i in files )
			{
				Image img = Image.FromFile( i );

				g.DrawImage( img, 0, y );

				y += img.Size.Height;
			}

			bmap.Save( dir + @"\합체.jpg", System.Drawing.Imaging.ImageFormat.Jpeg );
		}
	}
}
