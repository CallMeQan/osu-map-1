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
    public class Flash : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public string FlashPath = "sb/flash.png";

        [Configurable]
        public int FadeDuration = 50;

        [Configurable]
        public bool UseBeatColor = false;

        public override void Generate()
        {
            var bitmap = GetMapsetBitmap(FlashPath);
		    var hitobjectLayer = GetLayer("");
            
            foreach(OsuHitObject hitobject in Beatmap.HitObjects)
            {
                if ((StartTime != 0 || EndTime != 0) && (hitobject.StartTime < StartTime - 5 || EndTime - 5 <= hitobject.StartTime)) continue;
                foreach (int bookmark in Beatmap.Bookmarks)
                {
                    if(!(hitobject.StartTime - 5 < bookmark && bookmark < hitobject.EndTime + 5)) continue;
                    
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
