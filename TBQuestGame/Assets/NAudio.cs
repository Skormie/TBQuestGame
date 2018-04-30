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
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
                else if (url != NAudio.audioFileReader.FileName)
                {
                    NAudio.audioFileReader.Dispose();
                    audioFileReader = new AudioFileReader(url);
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
            }
            else if (NAudio.audioFileReader.FileName != null)
            {
                waveOutDevice.Stop();
            }
        }

    }
}
