using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace TBQuestGame
{
    //Code by VladL accessed Sunday April 29th 2018 https://stackoverflow.com/questions/15025626/playing-a-mp3-file-in-a-winform-application
    public static class NAudio
    {

        public static IWavePlayer waveOutDevice = new WaveOut();
        public static AudioFileReader audioFileReader;

        public static void PlayFile(String url)
        {

            if (url != "" && url != null)
            {
                url = @System.IO.Directory.GetCurrentDirectory() + url;
                if (NAudio.audioFileReader == null)
                {
                    audioFileReader = new AudioFileReader(url);
                    //waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(Loop);
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
                else if (url != NAudio.audioFileReader.FileName)
                {
                    waveOutDevice.Stop();
                    NAudio.audioFileReader.Dispose();
                    audioFileReader = new AudioFileReader(url);
                    //waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(Loop);
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
            }
            else if (NAudio.audioFileReader != null)
            {
                waveOutDevice.Stop();
                NAudio.audioFileReader = null;
            }
        }

        public static void KillAudio()
        {
            waveOutDevice.Stop();
            if(audioFileReader != null)
                audioFileReader.Dispose();
            waveOutDevice.Dispose();
        }

        //public static void Loop(object sender, StoppedEventArgs e)
        //{
        //    if (NAudio.audioFileReader != null)
        //    {
        //        //Console.WriteLine("We're in here!!!!");
        //        //Console.ReadLine();
        //        //string url = NAudio.audioFileReader.FileName;
        //        //waveOutDevice.Stop();
        //        audioFileReader.Position = 0;
        //        //NAudio.audioFileReader.Dispose();
        //        //waveOutDevice.Dispose();
        //        //waveOutDevice = new WaveOut();
        //        //audioFileReader = new AudioFileReader(url);
        //        waveOutDevice.Init(audioFileReader);
        //        waveOutDevice.Play();
        //        waveOutDevice.PlaybackStopped += new EventHandler<StoppedEventArgs>(Loop);
        //    }
        //}
    }

    /// <summary>
    /// Stream for looping playback
    /// </summary>
    public class LoopStream : WaveStream
    {
        WaveStream sourceStream;

        /// <summary>
        /// Creates a new Loop stream
        /// </summary>
        /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        /// or else we will not loop to the start again.</param>
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        /// <summary>
        /// Use this to turn looping on or off
        /// </summary>
        public bool EnableLooping { get; set; }

        /// <summary>
        /// Return source stream's wave format
        /// </summary>
        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        /// <summary>
        /// LoopStream simply returns
        /// </summary>
        public override long Length
        {
            get { return sourceStream.Length; }
        }

        /// <summary>
        /// LoopStream simply passes on positioning to source stream
        /// </summary>
        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
    }
}
