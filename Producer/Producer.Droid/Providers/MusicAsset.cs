using System;
using Producer.Domain;

namespace Producer.Droid
{
	public class MusicAsset
	{
		public string Id => Music.Id;

		public AvContent Music { get; private set; }

		//public AVUrlAsset UrlAsset { get; private set; }
		public Uri UrlAsset { get; private set; }

		public MusicAsset (AvContent music, Uri urlAsset)
		{
			Music = music;
			UrlAsset = urlAsset;
		}


		public MusicAsset (AvContent music, string urlAsset)
			: this (music, new Uri (urlAsset))
		{
		}


		public override bool Equals (object obj)
		{
			var item = obj as MusicAsset;

			return item != null && Id.Equals (item.Id);
		}

		public override int GetHashCode () => Id.GetHashCode ();
	}


	public enum MusicAssetDownloadState
	{
		NotDownloaded,
		Downloading,
		Downloaded
	}


	public class MusicAssetDownloadStateChangeArgs
	{
		public AvContent Music { get; private set; }

		public MusicAssetDownloadState State { get; set; }

		public MusicAssetDownloadStateChangeArgs (AvContent music)
		{
			Music = music;
		}

		public MusicAssetDownloadStateChangeArgs (AvContent music, MusicAssetDownloadState state)
		{
			Music = music;
			State = state;
		}
	}


	public class MusicAssetDownloadProgressChangeArgs
	{
		public AvContent Music { get; private set; }

		public double Progress { get; set; }

		public MusicAssetDownloadProgressChangeArgs (AvContent music, double progress)
		{
			Music = music;
			Progress = progress;
		}
	}
}