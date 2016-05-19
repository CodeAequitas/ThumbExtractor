using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog;

namespace ThumbExtractor.Engine
{
    public class Core
    {
        private byte[] _startSequence = { 0xff, 0xd8 };
        private byte[] _endSequence = { 0xff, 0xd9 };

        public Logger Log { get; }
        
        public int Count { get; private set; }

        public EventHandler<string> OnStatusUpdate;
        public EventHandler OnStatusFinished; 

        public Core()
        {
            Log = LogManager.GetCurrentClassLogger();
            Count = 0;
        }

        public Task Process(Options options, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    OnStatusUpdate?.Invoke(this, "[INFO] Reading input file...");

                    var data = File.ReadAllBytes(options.ThumbDB);

                    var start = 0;
                    Count = 0;

                    OnStatusUpdate?.Invoke(this, "[INFO] Starting extraction process...");

                    while (true)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            GC.Collect();
                            cancellationToken.ThrowIfCancellationRequested();
                            break;
                        }

                        var index = SearchPattern(data, _startSequence, start);

                        if (index < 0)
                            break;

                        var offset = SearchPattern(data, _endSequence, index);

                        Count += 1;

                        OnStatusUpdate?.Invoke(this, $"[INFO] Found image - total images found {Count}");

                        var imageData = data.Skip(index).Take((offset + 1) - index).ToArray();
                        var imageName = Path.Combine(options.OutputDirectory, $"extracted_{Count:D3}.jpg");

                        try
                        {
                            using (var fileStream = new FileStream(imageName, FileMode.Create, FileAccess.Write))
                            {
                                fileStream.Write(imageData, 0, imageData.Length);
                            }
                        }
                        catch (Exception e)
                        {
                            OnStatusUpdate?.Invoke(this, $"[ERROR] Error writing image data for image {Count}");
                            Log.Error(e, "Error writing image data for '{0}' at index {1} and offset {2}", imageName, index, offset);
                        }

                        start = offset + 2;
                    }

                    OnStatusUpdate?.Invoke(this, $"[INFO] Extraction process finished - {Count} images found.");
                    OnStatusFinished?.Invoke(this, null);
                }
                catch (Exception e)
                {
                    Log.Error(e, "Error extracting image data from thumbs database.");
                    OnStatusUpdate?.Invoke(this, "[ERROR] Error extracting image data from thumbnails.");
                    return;
                }
            }, cancellationToken);
        }


        /// <summary>
        /// Searches for a pattern inside a data array and returns the starting index
        /// </summary>
        /// <param name="data">Data to search through</param>
        /// <param name="pattern">Pattern to search for</param>
        /// <param name="start">Starting offset</param>
        /// <returns>Index of the first recognized matching pattern</returns>
        private int SearchPattern(byte[] data, byte[] pattern, int start = 0)
        {
            var found = -1;

            if (data.Length <= 0 || pattern.Length <= 0 || start > (data.Length - pattern.Length) || data.Length < pattern.Length)
                return found;

            for (var i = start; i <= data.Length - pattern.Length; i++)
            {
                // Only compare bytes if we have a match at the start
                if (data[i] != pattern[0])
                    continue;

                // Compare data with search pattern byte by byte
                var matched = true;
                for (var j = 1; j <= pattern.Length - 1; j++)
                {
                    // Data still matches pattern, continue
                    if (data[i + j] == pattern[j])
                        continue;

                    // We no langer have matches with the pattern, end search
                    matched = false;
                    break;
                }

                // If we dont have a match yet, keep searching in data
                if (!matched)
                    continue;

                // Everything matched up, we found our index
                found = i;
                break;
            }

            return found;
        }
    }
}
