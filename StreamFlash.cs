using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class StreamFlash : StoryboardObjectGenerator
    {   
        [Configurable]
        public String FlashPath = "sb/flash.png";

        [Configurable]
        public double Opacity = 0.2;

        [Configurable]
        public int FadeDuration = 50;

        [Configurable]
        public bool UseBeatColor = false;

        private Dictionary<int, int> StartEndTime = new Dictionary<int, int>(){
            {276006, 276381},
            {285756, 285980}
        };
        public override void Generate()
        {
            var bitmap = GetMapsetBitmap(FlashPath);
            var hitobjectLayer = GetLayer("");
            foreach (KeyValuePair<int, int> item in StartEndTime)
            {
                int StartTime = item.Key;
                int EndTime = item.Value;
                foreach (var hitobject in Beatmap.HitObjects)
                {
                    if ((StartTime != 0 || EndTime != 0) && 
                        (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime))
                        continue;

                    var fSprite = hitobjectLayer.CreateSprite(FlashPath, OsbOrigin.Centre);
                    fSprite.Scale(hitobject.StartTime, hitobject.EndTime + FadeDuration, 480.0f / bitmap.Height, 480.0f / bitmap.Height);
                    fSprite.Fade(OsbEasing.Out, hitobject.StartTime, hitobject.EndTime + FadeDuration, 1, 0);
                    fSprite.Additive(hitobject.StartTime, hitobject.EndTime + FadeDuration);

                    if (UseBeatColor) fSprite.Color(hitobject.StartTime, hitobject.Color);
                }
            }
        }
    }
}
